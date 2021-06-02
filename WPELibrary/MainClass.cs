using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPELibrary
{
    public class MainClass : IEntryPoint
    {
        public MainClass(RemoteHooking.IContext context, string channelName)
        {

        }

        public void Run(RemoteHooking.IContext context, string channelName)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DLL_Form());
        }
    }
}
