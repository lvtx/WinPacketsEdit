using EasyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class SocketSend_Form : Form
    {
        private int SendPacketCNT = 0;
        private int Send_Success_CNT = 0;
        private int Send_Fail_CNT = 0;
        private WinSockHook ws = new WinSockHook();
        private SocketOperation so = new SocketOperation();
        public string Send_Index;
        public string Send_Socket;
        public string Send_Len;
        public string Send_IPTo;
        public byte[] Send_Byte;

        public SocketSend_Form()
        {
            InitializeComponent();
        }

        private void SocketSend_Form_Load(object sender, EventArgs e)
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            int currentProcessId = RemoteHooking.GetCurrentProcessId();
            this.Text = $"发送封包 -【 序号 {this.Send_Index} 】- {processName} [{currentProcessId.ToString()}] by RNShinoa";
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
            this.InitSendSocketInfo();
            this.ShowStepValue();
        }

        private void tSend_Tick(object sender, EventArgs e)
        {
            this.tlSendPacket_CNT.Text = this.SendPacketCNT.ToString();
            this.tlSend_Success_CNT.Text = this.Send_Success_CNT.ToString();
            this.tlSend_Fail_CNT.Text = this.Send_Fail_CNT.ToString();
        }

        private void nudStepIndex_ValueChanged(object sender, EventArgs e)
        {
            this.ShowStepValue();
        }

        private void nudStepLen_ValueChanged(object sender, EventArgs e)
        {
            this.ShowStepValue();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (this.cbStep.Checked)
            {
                string sIndex = this.lStepIndex.Text.Trim();
                string sLen = this.lStepLen.Text.Trim();
                if (string.IsNullOrEmpty(sIndex) || string.IsNullOrEmpty(sLen))
                {
                    MessageBox.Show("请正确设置递进位置!");
                    return;
                }
            }
            this.bSend.Enabled = false;
            this.bSendStop.Enabled = true;
            this.SendPacketCNT = 0;
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

        private void cmsSocketSend_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Equals("添加到发送列表"))
            {
                string socket = this.txtSend_Socket.Text.Trim();
                string length = this.txtSend_Len.Text.Trim();
                string data = this.rtbSocketSend_Data.Text.Trim();
                string count = this.txtSend_CNT.Text.Trim();
                string times = this.txtSend_Int.Text.Trim();
                byte[] buffer = this.so.Hex_To_Byte(data);
                DataRow row = SocketSend.dtSocketBatchSend.NewRow();
                row[0] = int.Parse(this.Send_Index);
                row[1] = int.Parse(socket);
                row[2] = this.Send_IPTo;
                row[3] = buffer.Length;
                row[4] = data;
                row[5] = buffer;
                SocketSend.dtSocketBatchSend.Rows.Add(row);
                if (!SocketSend.bHasBatchSendForm)
                {
                    new SocketBatchSend_Form().Show();
                }
            }
        }

        private void bgwSendPacket_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendPacket();
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
        }

        private void InitSendSocketInfo()
        {
            try
            {
                this.txtSend_Socket.Text = this.Send_Socket;
                this.txtSend_Len.Text = this.Send_Len;
                this.txtSend_IP.Text = this.Send_IPTo.Split(':')[0];
                this.txtSend_Port.Text = this.Send_IPTo.Split(':')[1];
                this.rtbSocketSend_Data.Text = this.so.Byte_To_Hex(this.Send_Byte);
            }
            catch (Exception)
            {
            }
        }

        public void SendPacket()
        {
            int number = int.Parse(this.txtSend_CNT.Text.Trim());
            int times = int.Parse(this.txtSend_Int.Text.Trim());
            string data = this.rtbSocketSend_Data.Text;

            for (int i = 0; i < number; i++)
            {
                if (this.bgwSendPacket.CancellationPending) break;

                try
                {
                    int socket = int.Parse(this.txtSend_Socket.Text.Trim());
                    int len = int.Parse(this.txtSend_Len.Text.Trim());
                    if (this.cbStep.Checked)
                    {
                        int iIndex = int.Parse(this.nudStepIndex.Value.ToString()) - 1;
                        int iLen = int.Parse(this.nudStepLen.Value.ToString());
                        data = this.so.ReplaceValueByIndexAndLen_HEX(data, iIndex, iLen);
                        if (string.IsNullOrEmpty(data))
                        {
                            this.Send_Fail_CNT++;
                            break;
                        }
                    }
                    byte[] source = this.so.Hex_To_Byte(data);
                    IntPtr buffer = Marshal.AllocHGlobal(source.Length);
                    Marshal.Copy(source, 0, buffer, source.Length);

                    if (socket > 0 && (source.Length != 0))
                    {
                        if (this.ws.SendPacket(socket, buffer, source.Length))
                        {
                            this.Send_Success_CNT++;
                        }
                        else
                        {
                            this.Send_Fail_CNT++;
                        }
                        int cnt = number - this.SendPacketCNT;
                        if (cnt > 0)
                        {
                            this.txtSend_CNT.Text = cnt.ToString();
                        }
                        Thread.Sleep(times);
                    }
                }
                catch
                {
                    this.Send_Fail_CNT++;
                }
                this.SendPacketCNT++;
            }
        }

        private void ShowStepValue()
        {
            int iIndex = int.Parse(this.nudStepIndex.Value.ToString()) - 1;
            int iLen = int.Parse(this.nudStepLen.Value.ToString());
            string sHex = this.rtbSocketSend_Data.Text.Trim();
            string sIndex = this.so.GetValueByIndex_HEX(sHex, iIndex);
            string sLen = this.so.GetValueByLen_HEX(sIndex, iLen);
            this.lStepIndex.Text = sIndex;
            this.lStepLen.Text = sLen;
        }
    }
}
