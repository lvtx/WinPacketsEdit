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

        private void bClear_Click(object sender, EventArgs e)
        {
            SocketSend.dtSocketBatchSend.Rows.Clear();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            this.bSend.Enabled = false;
            this.bSendStop.Enabled = true;
            this.SendBatchCNT = 0;
            this.Send_Success_CNT = 0;
            this.Send_Fail_CNT = 0;
            if (!this.bgwSendPacket.IsBusy)
            {
                this.bgwSendPacket.RunWorkerAsync();
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
            if (e.ClickedItem.Text.Equals("从列表中移除") && (this.dgBatchSend.SelectedRows.Count == 1))
            {
                int index = this.dgBatchSend.SelectedRows[0].Index;
                SocketSend.dtSocketBatchSend.Rows[index].Delete();
            }
        }

        private void bgwSendPacket_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendPacket();
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
        }

        private void tSend_Tick(object sender, EventArgs e)
        {
            this.tlSendBatch_CNT.Text = this.SendBatchCNT.ToString();
            this.tlSend_Success_CNT.Text = this.Send_Success_CNT.ToString();
            this.tlSend_Fail_CNT.Text = this.Send_Fail_CNT.ToString();
        }

        private void InitBatchSendSocketInfo()
        {
            this.dgBatchSend.DataSource = SocketSend.dtSocketBatchSend;
        }

        public void SendPacket()
        {
            try
            {
                int num = int.Parse(this.txtSend_CNT.Text.Trim());
                int millisecondsTimeout = int.Parse(this.txtSend_Int.Text.Trim());
                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < SocketSend.dtSocketBatchSend.Rows.Count; j++)
                    {
                        if (this.bgwSendPacket.CancellationPending)
                        {
                            return;
                        }
                        int socket = int.Parse(SocketSend.dtSocketBatchSend.Rows[j]["套接字"].ToString());
                        int num7 = int.Parse(SocketSend.dtSocketBatchSend.Rows[j]["长度"].ToString());
                        byte[] source = (byte[])SocketSend.dtSocketBatchSend.Rows[j]["字节"];
                        if ((socket > 0) && (source.Length != 0))
                        {
                            IntPtr destination = Marshal.AllocHGlobal(source.Length);
                            Marshal.Copy(source, 0, destination, source.Length);
                            if (this.ws.SendPacket(socket, destination, source.Length))
                            {
                                this.Send_Success_CNT++;
                            }
                            else
                            {
                                this.Send_Fail_CNT++;
                            }
                            Thread.Sleep(millisecondsTimeout);
                        }
                    }
                    this.SendBatchCNT++;
                    int num4 = num - this.SendBatchCNT;
                    if (num4 > 0)
                    {
                        this.txtSend_CNT.Text = num4.ToString();
                    }
                }
            }
            catch
            {
            }
        }
    }
}
