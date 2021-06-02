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

        private void lvProcessList_DoubleClick(object sender, EventArgs e)
        {
            this.bSelected_Click(sender, e);
        }

        private void lvProcessList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.bSelected_Click(sender, e);
            }
        }

        public void GetProcess()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProcessName", typeof(string));
            table.Columns.Add("PID", typeof(int));
            table.Columns.Add("RAM", typeof(long));
            this.lvProcessList.Items.Clear();
            Process[] processes = Process.GetProcesses();
            int length = processes.Length;
            foreach (Process process in processes)
            {
                DataRow row = table.NewRow();
                row[0] = process.ProcessName;
                row[1] = process.Id;
                row[2] = process.PrivateMemorySize64;
                table.Rows.Add(row);
            }
            DataView defaultView = table.DefaultView;
            defaultView.Sort = "ProcessName";
            foreach (DataRow row in defaultView.ToTable().Rows)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = row[0].ToString(),
                    SubItems = {
                        row[1].ToString(),
                        row[2].ToString()
                    }
                };
                this.lvProcessList.Items.Add(item);
            }
            this.lProcessCNT.Text = "进程数：" + length.ToString();
        }
    }
}
