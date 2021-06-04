using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPELibrary
{
    class SocketInfo
    {
        private int socket;
        private byte[] buffer;
        private int length;
        private string type;
        private DLL_Form.sockaddr saddr;

        public SocketInfo()
        {

        }

        public SocketInfo(int socket, byte[] buffer, int length, string type, DLL_Form.sockaddr saddr)
        {
            this.socket = socket;
            this.buffer = buffer;
            this.length = length;
            this.type = type;
            this.saddr = saddr;
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
        /// 十六进制转字节
        /// </summary>
        /// <param name="hexString">十六进制字符串</param>
        /// <returns>字节数据</returns>
        public byte[] Hex_To_Byte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
            {
                hexString += " ";
            }
            byte[] buffer = new byte[hexString.Length / 2];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return buffer;
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

        public int Socket
        {
            get
            {
                return socket;
            }

            set
            {
                socket = value;
            }
        }

        public byte[] Buffer
        {
            get
            {
                return buffer;
            }

            set
            {
                buffer = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public DLL_Form.sockaddr Saddr
        {
            get
            {
                return saddr;
            }

            set
            {
                saddr = value;
            }
        }
    }
}
