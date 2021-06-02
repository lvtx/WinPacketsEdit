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
