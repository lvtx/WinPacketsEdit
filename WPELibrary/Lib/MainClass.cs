using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPELibrary.Lib
{
    public class MainClass : IEntryPoint
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        public MainClass(RemoteHooking.IContext context, string channelName)
        {

        }

        public void Run(RemoteHooking.IContext context, string channelName)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DLL_Form());
        }
    }
}
