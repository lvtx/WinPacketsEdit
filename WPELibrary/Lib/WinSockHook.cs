using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPELibrary.Lib
{
    public class WinSockHook
    {
        public Queue<SocketPacket> _SocketQueue = new Queue<SocketPacket>();
        public bool Interecept_Recv;
        public bool Interecept_RecvFrom;
        public bool Interecept_Send;
        public bool Interecept_SendTo;
        public bool Display_Recv;
        public bool Display_RecvFrom;
        public bool Display_Send;
        public bool Display_SendTo;
        public bool Reset_CNT;
        public int Interecept_CNT = 0;
        public int Recv_CNT = 0;
        public int Send_CNT = 0;
        private LocalHook lhSend = null;
        private LocalHook lhSendTo = null;
        private LocalHook lhRecv = null;
        private LocalHook lhRecvFrom = null;

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int send(int socket, IntPtr buffer, int length, int flags);

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int sendto(int socket, IntPtr buffer, int length, int flags, ref SocketPacket.sockaddr To, ref int toLenth);

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int recv(int socket, IntPtr buffer, int length, int flags);

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int recvfrom(int socket, IntPtr buffer, int length, int flags, ref SocketPacket.sockaddr from, ref int fromLen);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int RecvFromHook(int socket, IntPtr buffer, int length, int flags, ref SocketPacket.sockaddr from, ref int fromLen);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int RecvHook(int s, IntPtr buf, int length, int flags);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int SendHook(int s, IntPtr buf, int length, int flags);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int SendToHook(int socket, IntPtr buffer, int length, int flags, ref SocketPacket.sockaddr To, ref int toLenth);

        private int Send_Hook(int s, IntPtr buf, int length, int flags)
        {
            int iLen = 0;
            if (this.Interecept_Send)
            {
                if (length > 0)
                {
                    this.Interecept_CNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = send(s, buf, length, flags);
            }
            if ((iLen > 0) && this.Display_Send)
            {
                this.Send_CNT++;
                this.SocketEnqueue(s, buf, iLen, "S", new SocketPacket.sockaddr());
            }
            return iLen;
        }

        private int SendTo_Hook(int socket, IntPtr buffer, int length, int flags, ref SocketPacket.sockaddr To, ref int toLenth)
        {
            int iLen = 0;
            if (this.Interecept_SendTo)
            {
                if (length > 0)
                {
                    this.Interecept_CNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = sendto(socket, buffer, length, flags, ref To, ref toLenth);
            }
            if ((iLen > 0) && this.Display_SendTo)
            {
                this.Send_CNT++;
                this.SocketEnqueue(socket, buffer, iLen, "ST", To);
            }
            return iLen;
        }

        private int Recv_Hook(int s, IntPtr buf, int length, int flags)
        {
            int iLen = 0;
            if (this.Interecept_Recv)
            {
                if (length > 0)
                {
                    this.Interecept_CNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = recv(s, buf, length, flags);
            }
            if ((iLen > 0) && this.Display_Recv)
            {
                this.Recv_CNT++;
                this.SocketEnqueue(s, buf, iLen, "R", new SocketPacket.sockaddr());
            }
            return iLen;
        }
        private int RecvFrom_Hook(int socket, IntPtr buffer, int length, int flags, ref SocketPacket.sockaddr from, ref int fromLen)
        {
            int iLen = 0;
            if (this.Interecept_RecvFrom)
            {
                if (length > 0)
                {
                    this.Interecept_CNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = recvfrom(socket, buffer, length, flags, ref from, ref fromLen);
            }
            if ((iLen > 0) && this.Display_RecvFrom)
            {
                this.Recv_CNT++;
                this.SocketEnqueue(socket, buffer, iLen, "RF", from);
            }
            return iLen;
        }

        private void ResetCNT()
        {
            if (this.Reset_CNT)
            {
                this.Interecept_CNT = 0;
                this.Recv_CNT = 0;
                this.Send_CNT = 0;
                this._SocketQueue.Clear();
            }
        }

        public bool SendPacket(int socket, IntPtr buffer, int length)
        {
            return send(socket, buffer, length, 0) > 0;
        }

        private void SocketEnqueue(int iSocket, IntPtr ipBuff, int iLen, string sType, SocketPacket.sockaddr sAddr)
        {
            byte[] destination = new byte[iLen];
            Marshal.Copy(ipBuff, destination, 0, iLen);
            SocketPacket item = new SocketPacket(sType, iSocket, iLen, destination, sAddr);
            this._SocketQueue.Enqueue(item);
        }

        public void StartHook()
        {
            this.ResetCNT();
            this.lhRecv = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "recv"), new RecvHook(this.Recv_Hook), this);
            this.lhRecv.ThreadACL.SetExclusiveACL(new int[1]);
            this.lhRecvFrom = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "recvfrom"), new RecvFromHook(this.RecvFrom_Hook), this);
            this.lhRecvFrom.ThreadACL.SetExclusiveACL(new int[1]);
            this.lhSend = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "send"), new SendHook(this.Send_Hook), this);
            this.lhSend.ThreadACL.SetExclusiveACL(new int[1]);
            this.lhSendTo = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "sendto"), new SendToHook(this.SendTo_Hook), this);
            this.lhSendTo.ThreadACL.SetExclusiveACL(new int[1]);
        }

        public void StopHook()
        {
            this.lhRecv.Dispose();
            this.lhSend.Dispose();
            this.lhRecvFrom.Dispose();
            this.lhSendTo.Dispose();
        }
    }
}
