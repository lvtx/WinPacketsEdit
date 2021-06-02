using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessInjector
{
    public partial class ProcessList_Form : Form
    {
        public ProcessList_Form()
        {
            InitializeComponent();
            this.GetProcess();
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            this.GetProcess();
        }

        private void lvProcessList_DoubleClick(object sender, EventArgs e)
        {
            this.bSelected_Click(sender, e);
        }

        private void bSelected_Click(object sender, EventArgs e)
        {
            if (this.lvProcessList.SelectedItems.Count == 1)
            {
                Program.PID = int.Parse(this.lvProcessList.SelectedItems[0].SubItems[1].Text.ToString().Trim());
                Program.PNAME = this.lvProcessList.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                base.Close();
            }
            else
            {
                MessageBox.Show("请选择一个进程！");
            }
        }

        public void GetProcess()
        {
            this.lvProcessList.Items.Clear();
            Process[] processes = Process.GetProcesses();
            int length = processes.Length;
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = process.ProcessName,
                    SubItems = {
                        process.Id.ToString(),
                        process.PrivateMemorySize64.ToString()
                    }
                };
                this.lvProcessList.Items.Add(item);
            }
            this.lProcessCNT.Text = "进程数：" + length.ToString();
        }
    }
}
