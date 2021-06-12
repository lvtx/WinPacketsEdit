using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPELibrary.Lib
{
    public class SocketOperation
    {
        public bool Filter_Size = false;
        public bool Filter_Socket = false;
        public bool Filter_IP = false;
        public bool Filter_Packet = false;
        public string Filter_Size_From = string.Empty;
        public string Filter_Size_To = string.Empty;
        public string Filter_Socket_txt = string.Empty;
        public string Filter_IP_txt = string.Empty;
        public string Filter_Packet_txt = string.Empty;

        [DllImport("ws2_32.dll")]
        private static extern IntPtr inet_ntoa(SocketPacket.in_addr a);
        [DllImport("ws2_32.dll")]
        private static extern ushort ntohs(ushort netshort);

        [DllImport("ws2_32.dll")]
        private static extern int getsockname(int s, ref SocketPacket.sockaddr Address, ref int namelen);
        [DllImport("ws2_32.dll")]
        private static extern int getpeername(int s, ref SocketPacket.sockaddr Address, ref int namelen);

        /// <summary>
        /// 字节转二进制
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>二进制字符串</returns>
        public string Byte_To_Bin(byte[] buffer)
        {
            string strResult = string.Empty;
            foreach (byte bytes in buffer)
            {
                string strTemp = Convert.ToString(bytes, 2);
                strTemp = strTemp.Insert(0, new string('0', 8 - strTemp.Length));
                strResult += strTemp + " ";
            }
            strResult.Trim();
            return strResult;
        }

        /// <summary>
        /// 字节转十进制
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>十进制字符串</returns>
        public string Byte_To_Dec(byte[] buffer)
        {
            string strResult = string.Empty;
            foreach (byte bytes in buffer)
            {
                strResult += bytes.ToString("D3") + " ";
            }
            return strResult;
        }

        /// <summary>
        /// 字节转字符
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>字符串</returns>
        public string Byte_To_Default(byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);
        }

        /// <summary>
        /// 字节转GB2312
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>GB2312字符串</returns>
        public string Byte_To_GB2312(byte[] buffer)
        {
            return Encoding.GetEncoding("gb2312").GetString(buffer);
        }

        /// <summary>
        /// 字节转十六进制
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>十六进制字符串</returns>
        public string Byte_To_Hex(byte[] buffer)
        {
            string strResult = string.Empty;
            foreach (byte bytes in buffer)
            {
                strResult += bytes.ToString("X2") + " ";
            }
            strResult.Trim();
            return strResult;
        }

        /// <summary>
        /// 字节转UNICODE
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>UNICODE字符串</returns>
        public string Byte_To_Unicode(byte[] buffer)
        {
            return Encoding.GetEncoding("utf-16").GetString(buffer);
        }

        /// <summary>
        /// 字节转UTF-8
        /// </summary>
        /// <param name="buffer">字节数据</param>
        /// <returns>UTF-8字符串</returns>
        public string Byte_To_UTF8(byte[] buffer)
        {
            return Encoding.GetEncoding("utf-8").GetString(buffer);
        }

        private bool DoFilter_IP(string sIP_From, string sIP_To)
        {
            if (this.Filter_IP)
            {
                try
                {
                    string[] strArray = this.Filter_IP_txt.Split(';');
                    foreach (string str in strArray)
                    {
                        if ((sIP_From.IndexOf(str) >= 0) || (sIP_To.IndexOf(str) >= 0))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                }
            }
            return false;
        }

        private bool DoFilter_Packet(string sPacket)
        {
            if (this.Filter_Packet)
            {
                try
                {
                    string[] strArray = this.Filter_Packet_txt.Split(';');
                    foreach (string str in strArray)
                    {
                        if (sPacket.IndexOf(str) >= 0)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                }
            }
            return false;
        }

        private bool DoFilter_Size(int iLength)
        {
            bool flag = false;
            if (this.Filter_Size)
            {
                try
                {
                    int num = int.Parse(this.Filter_Size_From);
                    int num2 = int.Parse(this.Filter_Size_To);
                    if ((iLength >= num) && (iLength <= num2))
                    {
                        return false;
                    }
                    flag = true;
                }
                catch
                {
                }
            }
            return flag;
        }

        private bool DoFilter_Socket(int iSocket)
        {
            if (this.Filter_Socket)
            {
                try
                {
                    string[] strArray = this.Filter_Socket_txt.Split(';');
                    foreach (string str in strArray)
                    {
                        int num2 = int.Parse(str);
                        if (iSocket == num2)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                }
            }
            return false;
        }

        public bool Filter(SocketPacket s)
        {
            int socket = s.Socket;
            byte[] buffer = s.Buffer;
            int length = s.Length;
            string socketIP = this.GetSocketIP(socket, "F");
            string str2 = this.GetSocketIP(socket, "T");
            if (this.DoFilter_Size(length))
            {
                return false;
            }
            if (this.DoFilter_Socket(socket))
            {
                return false;
            }
            if (this.DoFilter_IP(socketIP, str2))
            {
                return false;
            }
            string sPacket = this.Byte_To_Hex(buffer);
            if (this.DoFilter_Packet(sPacket))
            {
                return false;
            }
            return true;
        }

        public bool Filter_Default(SocketPacket s)
        {
            int socket = s.Socket;
            string socketIP = this.GetSocketIP(socket, "F");
            string str2 = this.GetSocketIP(socket, "T");
            if (socketIP.Equals("0.0.0.0:0") || str2.Equals("0.0.0.0:0"))
            {
                return false;
            }
            return true;
        }

        private string GetAddr_IP(SocketPacket.in_addr in_Addr)
        {
            return Marshal.PtrToStringAnsi(inet_ntoa(in_Addr));
        }

        private string GetAddr_Port(ushort NetPort)
        {
            return ntohs(NetPort).ToString();
        }

        public string GetSocketIP(int iSocket, string sIP_Type)
        {
            string str2 = "";
            string str3 = "";
            SocketPacket.sockaddr structure = new SocketPacket.sockaddr();
            int namelen = Marshal.SizeOf(structure);
            if (sIP_Type.Equals("F"))
            {
                getsockname(iSocket, ref structure, ref namelen);
            }
            else if (sIP_Type.Equals("T"))
            {
                getpeername(iSocket, ref structure, ref namelen);
            }
            str2 = this.GetAddr_IP(structure.sin_addr);
            str3 = this.GetAddr_Port(structure.sin_port);
            return (str2 + ":" + str3);
        }

        public string GetSocketIP(SocketPacket.in_addr in_Addr, ushort NetPort)
        {
            string str2 = "";
            string str3 = "";
            str2 = this.GetAddr_IP(in_Addr);
            str3 = this.GetAddr_Port(NetPort);
            return (str2 + ":" + str3);
        }

        public byte[] Hex_To_Byte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
            {
                hexString = hexString + " ";
            }
            byte[] buffer = new byte[hexString.Length / 2];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 0x10);
            }
            return buffer;
        }
    }
}
