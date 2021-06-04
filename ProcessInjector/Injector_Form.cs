using EasyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessInjector
{
    public partial class Injector_Form : Form
    {
        private string Version = "";
        private string ProcessName = "";
        private int ProcessID = -1;
        private ComputerInfo ci = new ComputerInfo();

        public Injector_Form()
        {
            InitializeComponent();
            this.Text = "进程注入器（x86, x64自适应）by RNShinoa";
            this.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.ShowLog("当前内核版本：" + this.Version);
        }

        private void bSelectProcess_Click(object sender, EventArgs e)
        {
            new ProcessList_Form().ShowDialog();
            if ((Program.PID != -1) && (Program.PNAME != string.Empty))
            {
                this.tbProcessID.Text = Program.PNAME + " [" + Program.PID.ToString() + "]";
            }
        }

        private void bInject_Click(object sender, EventArgs e)
        {
            this.rtbLog.Clear();
            this.ProcessID = Program.PID;
            this.ProcessName = Program.PNAME;
            string library = "WPELibrary.dll";
            try
            {
                if (this.ProcessID > -1)
                {
                    this.ShowLog(string.Format("目标进程是{0}位程序，已自动调用{0}位的注入模块!",
                        this.IsWin64Process(this.ProcessID) ? 64 : 32));
                    this.ShowLog("开始注入目标进程 =>> " + this.ProcessName);
                    object[] inPassThruArgs = new object[] { "" };
                    RemoteHooking.Inject(
                        this.ProcessID,
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), library),
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), library),
                        inPassThruArgs);
                    this.ShowLog($"已成功注入目标进程 =>> {this.ProcessName}[{this.ProcessID}]");
                    this.ShowLog("注入完成，可关闭当前注入器.");
                    this.bInject.Enabled = false;
                }
                else
                {
                    MessageBox.Show("请先选择要注入的进程！");
                }
            }
            catch (Exception ex)
            {
                this.ShowLog("出现错误：" + ex.Message);
            }
        }

        private bool IsWin64Process(int ProcessID)
        {
            bool retVal = false;
            Process process = Process.GetProcessById(ProcessID);

            if (process != null)
            {
                if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || 
                    Environment.OSVersion.Version.Major > 5)
                {
                    IsWow64Process(process.Handle, out retVal);
                    return !retVal;
                }
            }
            return retVal;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);

        private void ShowLog(string ShowInfo)
        {
            this.rtbLog.AppendText(ShowInfo + "\n");
        }
    }
}
