using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPELibrary.Lib
{
    public class SocketInfo
    {
        private int index;
        private string type;
        private int socket;
        private string from;
        private string to;
        private int length;
        private string data;
        private byte[] buffer;

        public SocketInfo(int index, string type, int socket, string from, string to, int length, string data, byte[] buffer)
        {
            this.Index = index;
            this.Type = type;
            this.Socket = socket;
            this.From = from;
            this.To = to;
            this.Length = length;
            this.Data = data;
            this.Buffer = buffer;
        }

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
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

        public string From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
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

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
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
    }
}
