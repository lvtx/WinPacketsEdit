using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPELibrary.Lib
{
    public class SocketEvent
    {
        public delegate void SocketPacketReceived(SocketInfo si);
    }
}
