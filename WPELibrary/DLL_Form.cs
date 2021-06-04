using EasyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPELibrary
{
    public partial class DLL_Form : Form
    {
        private Queue<SocketInfo> _SocketQueue = new Queue<SocketInfo>();
        private SocketInfo Socket_Info = new SocketInfo();
        private DataTable dtSocketInfo = new DataTable();
        private LocalHook lhSend = null;
        private LocalHook lhSendTo = null;
        private LocalHook lhRecv = null;
        private LocalHook lhRecvFrom = null;
        private int Select_Index = -1;
        private int SendCNT = 0;
        private int RecvCNT = 0;
        private int FilterCNT = 0;
        private int IntereceptCNT = 0;
        private bool bDebug = true;

        [StructLayout(LayoutKind.Sequential)]
        public struct in_addr
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] sin_addr;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct sockaddr
        {
            public short sin_family;
            public ushort sin_port;
            public DLL_Form.in_addr sin_addr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] sin_zero;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int RecvFromHook(int socket, IntPtr buffer, int length, int flags, ref DLL_Form.sockaddr from, ref int fromLen);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int RecvHook(int s, IntPtr buf, int length, int flags);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int SendHook(int s, IntPtr buf, int length, int flags);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
        private delegate int SendToHook(int socket, IntPtr buffer, int length, int flags, ref DLL_Form.sockaddr To, ref int toLenth);

        public DLL_Form()
        {
            InitializeComponent();
            try
            {
                this.Text = "封包拦截器（无需代理）by RNShinoa";
                this.tlSystemInfo.Text = $"已注入目标进程 {Process.GetCurrentProcess().ProcessName} [{RemoteHooking.GetCurrentProcessId()}]";
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
            this.bStartHook.Enabled = true;
            this.bStopHook.Enabled = false;
            this.tSocketInfo.Enabled = true;
            this.dtSocketInfo.Columns.Add("字节", typeof(byte[]));
            this.InitAllInfo();
        }

        private void DLL_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LocalHook.Release();
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
        }

        private void tSocketInfo_Tick(object sender, EventArgs e)
        {
            this.tlQueue_CNT.Text = this._SocketQueue.Count.ToString();
            this.tlALL_CNT.Text = (this.RecvCNT + this.SendCNT).ToString();
            this.tlRecv_CNT.Text = this.RecvCNT.ToString();
            this.tlSend_CNT.Text = this.SendCNT.ToString();
            this.tlFilter_CNT.Text = this.FilterCNT.ToString();
            this.tlInterecept_CNT.Text = this.IntereceptCNT.ToString();
            if (!this.bgwSocketInfo.IsBusy && (this._SocketQueue.Count > 0))
            {
                this.bgwSocketInfo.RunWorkerAsync();
            }
        }

        private void bgwSocketInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ShowSocketInfo();
        }

        private void bStartHook_Click(object sender, EventArgs e)
        {
            this.InitAllInfo();
            this.bStartHook.Enabled = false;
            this.bStopHook.Enabled = true;
            this.lhRecv = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "recv"), new RecvHook(this.Recv_Hook), this);
            this.lhRecv.ThreadACL.SetExclusiveACL(new int[1]);
            this.lhRecvFrom = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "recvfrom"), new RecvFromHook(this.RecvFrom_Hook), this);
            this.lhRecvFrom.ThreadACL.SetExclusiveACL(new int[1]);
            this.lhSend = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "send"), new SendHook(this.Send_Hook), this);
            this.lhSend.ThreadACL.SetExclusiveACL(new int[1]);
            this.lhSendTo = LocalHook.Create(LocalHook.GetProcAddress("ws2_32.dll", "sendto"), new SendToHook(this.SendTo_Hook), this);
            this.lhSendTo.ThreadACL.SetExclusiveACL(new int[1]);
        }

        private void bStopHook_Click(object sender, EventArgs e)
        {
            this.bStartHook.Enabled = true;
            this.bStopHook.Enabled = false;
            try
            {
                this.lhRecv.Dispose();
                this.lhSend.Dispose();
                this.lhRecvFrom.Dispose();
                this.lhSendTo.Dispose();
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
        }

        private void cmsSocketInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string text = e.ClickedItem.Text;
            try
            {
                if (text.Equals("发送") && (((this.Select_Index > -1) && (this.lvSocketInfo.SelectedItems.Count > 0)) && (this.dtSocketInfo.Rows.Count > 0)))
                {
                    new SocketSend_Form
                    {
                        Send_Index = (this.Select_Index + 1).ToString(),
                        Send_Socket = this.lvSocketInfo.Items[this.Select_Index].SubItems[2].Text.Trim(),
                        Send_Len = this.lvSocketInfo.Items[this.Select_Index].SubItems[5].Text.Trim(),
                        Send_IPTo = this.lvSocketInfo.Items[this.Select_Index].SubItems[4].Text.Trim(),
                        Send_Byte = (byte[])this.dtSocketInfo.Rows[this.Select_Index]["字节"]
                    }.Show();
                }
            }
            catch (Exception exception)
            {
                this.ShowDebug(exception.Message);
            }
        }

        private void lvSocketInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvSocketInfo.SelectedItems.Count == 1)
            {
                this.Select_Index = this.lvSocketInfo.SelectedItems[0].Index;
                this.ShowPacketInfo();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string str = this.txtSearch.Text.Trim();
            if (!str.Equals(""))
            {
                for (int i = 0; i < this.lvSocketInfo.Items.Count; i++)
                {
                    if (this.lvSocketInfo.Items[i].SubItems[6].Text.IndexOf(str) >= 0)
                    {
                        this.lvSocketInfo.Items[i].Selected = true;
                        this.lvSocketInfo.EnsureVisible(i);
                        break;
                    }
                }
            }
        }

        private void InitAllInfo()
        {
            if (this.cbCleanSocket.Checked)
            {
                this.RecvCNT = 0;
                this.SendCNT = 0;
                this.FilterCNT = 0;
                this.IntereceptCNT = 0;
                this.dtSocketInfo.Rows.Clear();
                this._SocketQueue.Clear();
                this.lvSocketInfo.Items.Clear();
                this.rtbHEX.Clear();
                this.rtbDEC.Clear();
                this.rtbBIN.Clear();
                this.rtbUNICODE.Clear();
                this.rtbUTF8.Clear();
                this.rtbGB2312.Clear();
                this.rtbDEBUG.Clear();
            }
        }

        private bool Filter(SocketInfo s)
        {
            try
            {
                int socket = s.Socket;

                if (this.Filter_Size(s.Length)) return false;
                if (this.Filter_Socket(socket)) return false;
                if (this.Filter_IP(this.GetSocketIP(socket, "F"), this.GetSocketIP(socket, "T"))) return false;
                if (this.Filter_Packet(this.Socket_Info.Byte_To_Hex(s.Buffer))) return false;
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
            return true;
        }

        private bool Filter_Default(SocketInfo s)
        {
            try
            {
                int socket = s.Socket;

                if (this.GetSocketIP(socket, "F").Equals("0.0.0.0 : 0") ||
                    this.GetSocketIP(socket, "T").Equals("0.0.0.0 : 0"))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
            return true;
        }

        private bool Filter_IP(string sIP_From, string sIP_To)
        {
            if (this.cbFilter_IP.Checked)
            {
                try
                {
                    string[] ips = this.txtFilter_IP.Text.Trim().Split(new char[] { ';' });
                    foreach (string ip in ips)
                    {
                        if (sIP_From.IndexOf(ip) >= 0 || sIP_To.IndexOf(ip) >= 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.ShowDebug(ex.Message);
                }
            }
            return false;
        }

        private bool Filter_Packet(string sPacket)
        {
            if (this.cbFilter_Packet.Checked)
            {
                try
                {
                    string[] packets = this.txtFilter_Packet.Text.Trim().Split(new char[] { ';' });
                    foreach (string packet in packets)
                    {
                        if (sPacket.IndexOf(packet) >= 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.ShowDebug(ex.Message);
                }
            }
            return false;
        }

        private bool Filter_Size(int iLength)
        {
            bool flag = false;
            if (this.cbFilter_Size.Checked)
            {
                try
                {
                    if (iLength >= int.Parse(this.txtFilter_Size_From.Text.Trim()) &&
                        iLength <= int.Parse(this.txtFilter_Size_To.Text.Trim()))
                    {
                        return false;
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                    this.ShowDebug(ex.Message);
                }
            }
            return flag;
        }

        private bool Filter_Socket(int iSocket)
        {
            if (this.cbFilter_Socket.Checked)
            {
                try
                {
                    string[] sockets = this.txtFilter_Socket.Text.Trim().Split(new char[] { ';' });
                    foreach (string socket in sockets)
                    {
                        if (iSocket == int.Parse(socket))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.ShowDebug(ex.Message);
                }
            }
            return false;
        }

        [DllImport("ws2_32.dll")]
        public static extern int getsockname(int s, ref sockaddr Address, ref int namelen);
        [DllImport("ws2_32.dll")]
        public static extern int getpeername(int s, ref sockaddr Address, ref int namelen);
        [DllImport("ws2_32.dll")]
        public static extern IntPtr inet_ntoa(in_addr a);
        [DllImport("ws2_32.dll")]
        public static extern ushort ntohs(ushort netshort);
        private string GetSocketIP(int iSocket, string sIP_Type)
        {
            string address = string.Empty;
            try
            {
                sockaddr sAddr = new sockaddr();
                int addrlen = Marshal.SizeOf(sAddr);
                if (sIP_Type.Equals("F"))
                {
                    getsockname(iSocket, ref sAddr, ref addrlen);
                }
                else if (sIP_Type.Equals("T"))
                {
                    getpeername(iSocket, ref sAddr, ref addrlen);
                }

                address = Marshal.PtrToStringAnsi(inet_ntoa(sAddr.sin_addr)) + " : " + ntohs(sAddr.sin_port).ToString();
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
            return address;
        }

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int recv(int socket, IntPtr buffer, int length, int flags);
        private int Recv_Hook(int s, IntPtr buf, int length, int flags)
        {
            int iLen = 0;
            if (this.cbInterecept_Recv.Checked)
            {
                if (length > 0)
                {
                    this.IntereceptCNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = recv(s, buf, length, flags);
            }

            if (iLen > 0 && this.cbType_Recv.Checked)
            {
                sockaddr sAddr = new sockaddr();
                this.SocketEnqueue(s, buf, iLen, "R", sAddr);
            }
            return iLen;
        }

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int recvfrom(int socket, IntPtr buffer, int length, int flags, ref sockaddr from, ref int fromLen);
        private int RecvFrom_Hook(int socket, IntPtr buffer, int length, int flags, ref sockaddr from, ref int fromLen)
        {
            int iLen = 0;
            if (this.cbInterecept_RecvFrom.Checked)
            {
                if (length > 0)
                {
                    this.IntereceptCNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = recvfrom(socket, buffer, length, flags, ref from, ref fromLen);
            }

            if (iLen > 0 && this.cbType_RecvFrom.Checked)
            {
                this.SocketEnqueue(socket, buffer, iLen, "RF", from);
            }
            return iLen;
        }

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int send(int socket, IntPtr buffer, int length, int flags);
        private int Send_Hook(int s, IntPtr buf, int length, int flags)
        {
            int iLen = 0;
            if (this.cbInterecept_Send.Checked)
            {
                if (length > 0)
                {
                    this.IntereceptCNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = send(s, buf, length, flags);
            }

            if (iLen > 0 && this.cbType_Send.Checked)
            {
                sockaddr sAddr = new sockaddr();
                this.SocketEnqueue(s, buf, iLen, "S", sAddr);
            }
            return iLen;
        }

        [DllImport("ws2_32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int sendto(int socket, IntPtr buffer, int length, int flags, ref sockaddr To, ref int toLenth);
        private int SendTo_Hook(int socket, IntPtr buffer, int length, int flags, ref sockaddr To, ref int toLenth)
        {
            int iLen = 0;
            if (this.cbInterecept_SendTo.Checked)
            {
                if (length > 0)
                {
                    this.IntereceptCNT++;
                }
                iLen = length;
            }
            else
            {
                iLen = sendto(socket, buffer, length, flags, ref To, ref toLenth);
            }

            if ((iLen > 0) && this.cbType_SendTo.Checked)
            {
                this.SocketEnqueue(socket, buffer, iLen, "ST", To);
            }
            return iLen;
        }

        private void ShowDebug(string sLog)
        {
            if (this.bDebug)
            {
                this.rtbDEBUG.AppendText(sLog + "\n");
            }
        }

        private void ShowPacketInfo()
        {
            if (this.dtSocketInfo.Rows.Count > 0)
            {
                try
                {
                    byte[] buffer = (byte[])this.dtSocketInfo.Rows[this.Select_Index]["字节"];
                    this.rtbHEX.Text = this.Socket_Info.Byte_To_Hex(buffer);
                    this.rtbDEC.Text = this.Socket_Info.Byte_To_Dec(buffer);
                    this.rtbBIN.Text = this.Socket_Info.Byte_To_Bin(buffer);
                    this.rtbUNICODE.Text = this.Socket_Info.Byte_To_Unicode(buffer);
                    this.rtbUTF8.Text = this.Socket_Info.Byte_To_UTF8(buffer);
                    this.rtbGB2312.Text = this.Socket_Info.Byte_To_GB2312(buffer);
                }
                catch (Exception exception)
                {
                    this.ShowDebug(exception.Message);
                }
            }
        }

        private void ShowSocketInfo()
        {
            try
            {
                if (this._SocketQueue.Count > 0)
                {
                    SocketInfo s = this._SocketQueue.Dequeue();
                    if (this.Filter_Default(s))
                    {
                        if (this.Filter(s))
                        {
                            int count = this.dtSocketInfo.Rows.Count + 1;
                            int socket = s.Socket;
                            string sType = "";
                            string sIP_From = "";
                            string sIP_To = "";
                            byte[] buffer = s.Buffer;
                            int length = s.Length;
                            string sHex = this.Socket_Info.Byte_To_Hex(buffer);
                            if (s.Type.Equals("R"))
                            {
                                sType = "接收";
                                sIP_From = this.GetSocketIP(socket, "T");
                                sIP_To = this.GetSocketIP(socket, "F");
                            }
                            else if (s.Type.Equals("S"))
                            {
                                sType = "发送";
                                sIP_From = this.GetSocketIP(socket, "F");
                                sIP_To = this.GetSocketIP(socket, "T");
                            }
                            else if (s.Type.Equals("ST"))
                            {
                                sType = "发送到";
                                sockaddr saddr = s.Saddr;
                                string str6 = ntohs(saddr.sin_port).ToString();
                                sIP_From = this.GetSocketIP(socket, "F");
                                sIP_To = Marshal.PtrToStringAnsi(inet_ntoa(saddr.sin_addr)) + " : " + str6;
                            }
                            else if (s.Type.Equals("RF"))
                            {
                                sType = "接收自";
                                sockaddr saddr = s.Saddr;
                                string str8 = ntohs(saddr.sin_port).ToString();
                                sIP_From = Marshal.PtrToStringAnsi(inet_ntoa(saddr.sin_addr)) + " : " + str8;
                                sIP_To = this.GetSocketIP(socket, "F");
                            }
                            DataRow row = this.dtSocketInfo.NewRow();
                            row["字节"] = buffer;
                            this.dtSocketInfo.Rows.Add(row);
                            ListViewItem item = new ListViewItem
                            {
                                Text = count.ToString(),
                                SubItems = {
                                    sType.ToString(),
                                    socket.ToString(),
                                    sIP_From.ToString(),
                                    sIP_To.ToString(),
                                    length.ToString(),
                                    sHex.ToString()
                                }
                            };
                            this.lvSocketInfo.Items.Add(item);
                        }
                    }
                    else
                    {
                        this.FilterCNT++;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
        }

        private void SocketEnqueue(int iSocket, IntPtr ipBuff, int iLen, string sType, sockaddr sAddr)
        {
            try
            {
                Queue<SocketInfo> queue = this._SocketQueue;
                lock (queue)
                {
                    byte[] destination = new byte[iLen];
                    Marshal.Copy(ipBuff, destination, 0, iLen);
                    this._SocketQueue.Enqueue(new SocketInfo(iSocket, destination, iLen, sType, sAddr));
                }
                if (sType.Equals("R") || sType.Equals("RF"))
                {
                    this.RecvCNT++;
                }
                else if (sType.Equals("S") || sType.Equals("ST"))
                {
                    this.SendCNT++;
                }
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
        }
    }
}
