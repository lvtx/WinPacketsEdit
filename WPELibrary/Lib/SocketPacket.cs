using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPELibrary.Lib
{
    public class SocketPacket
    {
        private string type;
        private int socket;
        private int length;
        private byte[] buffer;
        private sockaddr addr;

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
            public SocketPacket.in_addr sin_addr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] sin_zero;
        }

        public SocketPacket(string type, int socket, int length, byte[] buffer, sockaddr addr)
        {
            this.type = type;
            this.socket = socket;
            this.length = length;
            this.buffer = buffer;
            this.Addr = addr;
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

        public sockaddr Addr
        {
            get
            {
                return addr;
            }

            set
            {
                addr = value;
            }
        }
    }
}
