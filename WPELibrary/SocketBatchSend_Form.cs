using EasyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            string processName = Process.GetCurrentProcess().ProcessName;
            int currentProcessId = RemoteHooking.GetCurrentProcessId();
            this.Text = $"发送列表 - {processName} [{currentProcessId.ToString()}] by RNShinoa";
            SocketSend.bHasBatchSendForm = true;
            this.dgBatchSend.AutoGenerateColumns = false;
            this.bSend.Enabled = true;
            this.bSendStop.Enabled = false;
            this.InitBatchSendSocketInfo();
        }

        private void SocketBatchSend_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            SocketSend.bHasBatchSendForm = false;
        }

        private void bLoadSocket_Click(object sender, EventArgs e)
        {
            int success = 0;
            int fail = 0;
            try
            {
                this.ofdLoadSocket.ShowDialog();
                string fileName = this.ofdLoadSocket.FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    string[] send_list = File.ReadAllLines(fileName, Encoding.Default);
                    SocketSend.dtSocketBatchSend.Rows.Clear();
                    foreach (string packet in send_list)
                    {
                        try
                        {
                            string[] send_data = packet.Split('|');
                            string index = send_data[0];
                            string socket = send_data[1];
                            string to = send_data[2];
                            string length = send_data[3];
                            string data = send_data[4];
                            byte[] buffer = this.so.Hex_To_Byte(data);
                            DataRow row = SocketSend.dtSocketBatchSend.NewRow();
                            row[0] = int.Parse(index);
                            row[1] = int.Parse(socket);
                            row[2] = to;
                            row[3] = length;
                            row[4] = data;
                            row[5] = buffer;
                            SocketSend.dtSocketBatchSend.Rows.Add(row);
                            success++;
                        }
                        catch
                        {
                            fail++;
                        }
                    }
                }
                MessageBox.Show("加载完毕，成功【" + success.ToString() + "】失败【" + fail.ToString() + "】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败！错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void bSaveSocket_Click(object sender, EventArgs e)
        {
            int success = 0;
            int fail = 0;
            if ((this.dgBatchSend.Rows.Count > 0) && (this.sfdSaveSocket.ShowDialog() == DialogResult.OK))
            {
                try
                {
                    FileStream stream = new FileStream(this.sfdSaveSocket.FileName, FileMode.Create);
                    StreamWriter writer = new StreamWriter(stream);
                    for (int i = 0; i < this.dgBatchSend.Rows.Count; i++)
                    {
                        try
                        {
                            byte[] data = (byte[])SocketSend.dtSocketBatchSend.Rows[i]["字节"];
                            string index = (i + 1).ToString();
                            string socket = this.dgBatchSend.Rows[i].Cells[1].Value.ToString().Trim();
                            string to = this.dgBatchSend.Rows[i].Cells[2].Value.ToString().Trim();
                            string length = this.dgBatchSend.Rows[i].Cells[3].Value.ToString().Trim();
                            string buffer = this.so.Byte_To_Hex(data);
                            string text = string.Concat(new string[] { index, "|", socket, "|", to, "|", length, "|", buffer });
                            writer.WriteLine(text);
                            success++;
                        }
                        catch
                        {
                            fail++;
                        }
                    }
                    writer.Flush();
                    writer.Close();
                    stream.Close();
                    MessageBox.Show("保存完毕，成功【" + success.ToString() + "】失败【" + fail.ToString() + "】！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！错误：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (this.cbUseSocket.Checked)
            {
                string socket = this.txtUseSocket.Text.Trim();
                if (string.IsNullOrEmpty(socket))
                {
                    flag = false;
                }
                else
                {
                    try
                    {
                        if (int.Parse(socket) <= 0)
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
