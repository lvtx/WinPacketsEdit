using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPELibrary.Lib;

namespace WPELibrary
{
    public partial class SocketBatchSend_Form : Form
    {
        private WinSockHook ws = new WinSockHook();
        private SocketOperation so = new SocketOperation();
        private int SendBatchCNT = 0;
        private int Send_Success_CNT = 0;
        private int Send_Fail_CNT = 0;

        public SocketBatchSend_Form()
        {
            InitializeComponent();
        }

        private void SocketBatchSend_Form_Load(object sender, EventArgs e)
        {
            SocketSend.bHasBatchSendForm = false;
        }

        private void SocketBatchSend_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            SocketSend.bHasBatchSendForm = true;
            this.dgBatchSend.AutoGenerateColumns = false;
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
            this.InitBatchSendSocketInfo();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (this.cbUseSocket.Checked)
            {
                string str = this.txtUseSocket.Text.Trim();
                if (string.IsNullOrEmpty(str))
                {
                    flag = false;
                }
                else
                {
                    try
                    {
                        if (int.Parse(str) <= 0)
                        {
                            flag = false;
                        }
                    }
                    catch
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                this.bSend.Enabled = false;
                this.bSendStop.Enabled = true;
                this.cbUseSocket.Enabled = false;
                this.txtUseSocket.Enabled = false;
                this.SendBatchCNT = 0;
                this.Send_Success_CNT = 0;
                this.Send_Fail_CNT = 0;
                if (!this.bgwSendPacket.IsBusy)
                {
                    this.bgwSendPacket.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("请正确设置套接字！");
            }
        }

        private void bSendStop_Click(object sender, EventArgs e)
        {
            this.bgwSendPacket.CancelAsync();
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
        }

        private void cmsBatchSend_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string text = e.ClickedItem.Text;
            if (text.Equals("从列表中移除"))
            {
                if (this.dgBatchSend.SelectedRows.Count == 1)
                {
                    int index = this.dgBatchSend.SelectedRows[0].Index;
                    SocketSend.dtSocketBatchSend.Rows[index].Delete();
                }
            }
            else if (text.Equals("清空发送列表"))
            {
                SocketSend.dtSocketBatchSend.Rows.Clear();
            }
        }

        private void bgwSendPacket_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendPacket();
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
            this.cbUseSocket.Enabled = true;
            this.txtUseSocket.Enabled = true;
        }

        private void tSend_Tick(object sender, EventArgs e)
        {
            this.tlSendBatch_CNT.Text = this.SendBatchCNT.ToString();
            this.tlSend_Success_CNT.Text = this.Send_Success_CNT.ToString();
            this.tlSend_Fail_CNT.Text = this.Send_Fail_CNT.ToString();
        }

        private void InitBatchSendSocketInfo()
        {
            if (SocketSend.iUseSocket > 0)
            {
                this.txtUseSocket.Text = SocketSend.iUseSocket.ToString();
            }
            this.dgBatchSend.DataSource = SocketSend.dtSocketBatchSend;
        }

        public void SendPacket()
        {
            try
            {
                int number = int.Parse(this.txtSend_CNT.Text.Trim());
                int times = int.Parse(this.txtSend_Int.Text.Trim());
                for (int i = 0; i < number; i++)
                {
                    for (int j = 0; j < SocketSend.dtSocketBatchSend.Rows.Count; j++)
                    {
                        if (this.bgwSendPacket.CancellationPending)
                        {
                            return;
                        }
                        int socket = 0;
                        if (this.cbUseSocket.Checked)
                        {
                            socket = int.Parse(this.txtUseSocket.Text.Trim());
                        }
                        else
                        {
                            socket = int.Parse(SocketSend.dtSocketBatchSend.Rows[j]["套接字"].ToString());
                        }
                        int len = int.Parse(SocketSend.dtSocketBatchSend.Rows[j]["长度"].ToString());
                        byte[] buffer = (byte[])SocketSend.dtSocketBatchSend.Rows[j]["字节"];
                        if ((socket > 0) && (buffer.Length != 0))
                        {
                            IntPtr destination = Marshal.AllocHGlobal(buffer.Length);
                            Marshal.Copy(buffer, 0, destination, buffer.Length);
                            if (this.ws.SendPacket(socket, destination, buffer.Length))
                            {
                                this.Send_Success_CNT++;
                            }
                            else
                            {
                                this.Send_Fail_CNT++;
                            }
                            Thread.Sleep(times);
                        }
                    }
                    this.SendBatchCNT++;
                    int cnt = number - this.SendBatchCNT;
                    if (cnt > 0)
                    {
                        this.txtSend_CNT.Text = cnt.ToString();
                    }
                }
            }
            catch
            {
            }
        }
    }
}
