using EasyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPELibrary.Lib;
using static WPELibrary.Lib.SocketEvent;

namespace WPELibrary
{
    public partial class DLL_Form : Form
    {
        private WinSockHook ws = new WinSockHook();
        private SocketOperation so = new SocketOperation();
        private BindingList<SocketInfo> lstRecPacket = new BindingList<SocketInfo>();
        private int Select_Index = -1;
        private int FilterCNT = 0;
        private int iShowDataLen = 50;
        private bool bDebug = true;
        private bool bWakeUp = true;

        public DLL_Form()
        {
            InitializeComponent();
        }

        private void DLL_Form_Load(object sender, EventArgs e)
        {
            this.Init();
            this.bStartHook.Enabled = true;
            this.bStopHook.Enabled = false;
            this.Text = "封包拦截器（无需代理）by RNShinoa";
            this.tlSystemInfo.Text = $"已注入目标进程 {Process.GetCurrentProcess().ProcessName} [{RemoteHooking.GetCurrentProcessId()}]";
            SocketSend.dtSocketBatchSend.Columns.Add("序号", typeof(int));
            SocketSend.dtSocketBatchSend.Columns.Add("套接字", typeof(int));
            SocketSend.dtSocketBatchSend.Columns.Add("目的地址", typeof(string));
            SocketSend.dtSocketBatchSend.Columns.Add("长度", typeof(int));
            SocketSend.dtSocketBatchSend.Columns.Add("数据", typeof(string));
            SocketSend.dtSocketBatchSend.Columns.Add("字节", typeof(byte[]));
            this.dgSocketInfo.AutoGenerateColumns = false;
            this.dgSocketInfo.DataSource = this.lstRecPacket;
            this.dgSocketInfo.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this.dgSocketInfo, true, null);
            this.RecSocketPacket += new SocketEvent.SocketPacketReceived(this.Event_RecSocketPacket);
            this.tSocketInfo.Enabled = true;
        }

        private void DLL_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LocalHook.Release();
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
            finally
            {
                if (this.bWakeUp)
                {
                    RemoteHooking.WakeUpProcess();
                    this.bWakeUp = false;
                }
            }
        }

        private void tSocketInfo_Tick(object sender, EventArgs e)
        {
            this.tlQueue_CNT.Text = this.ws._SocketQueue.Count.ToString();
            this.tlALL_CNT.Text = (this.ws.Recv_CNT + this.ws.Send_CNT).ToString();
            this.tlRecv_CNT.Text = this.ws.Recv_CNT.ToString();
            this.tlSend_CNT.Text = this.ws.Send_CNT.ToString();
            this.tlInterecept_CNT.Text = this.ws.Interecept_CNT.ToString();
            this.tlFilter_CNT.Text = this.FilterCNT.ToString();
            if (!this.bgwSocketInfo.IsBusy && (this.ws._SocketQueue.Count > 0))
            {
                this.bgwSocketInfo.RunWorkerAsync();
            }
        }

        private void bgwSocketInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ShowSocketInfo();
        }

        private void bStartHook_Click(object sender, EventArgs e)
        {
            this.Init();
            this.bStartHook.Enabled = false;
            this.bStopHook.Enabled = true;
            this.ws.StartHook();

            if (this.bWakeUp)
            {
                RemoteHooking.WakeUpProcess();
                this.bWakeUp = false;
            }
        }

        private void bStopHook_Click(object sender, EventArgs e)
        {
            this.bStartHook.Enabled = true;
            this.bStopHook.Enabled = false;

            this.ws.StopHook();
        }

        private void cmsSocketInfo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string text = e.ClickedItem.Text;
            if (text.Equals("查看发送列表"))
            {
                if (!SocketSend.bHasBatchSendForm)
                {
                    new SocketBatchSend_Form().Show();
                }
            }
            else if (this.Select_Index > -1)
            {
                try
                {
                    int index = this.lstRecPacket[this.Select_Index].Index;
                    int socket = this.lstRecPacket[this.Select_Index].Socket;
                    int length = this.lstRecPacket[this.Select_Index].Length;
                    string to = this.lstRecPacket[this.Select_Index].To;
                    string data = this.lstRecPacket[this.Select_Index].Data;
                    byte[] buffer = this.lstRecPacket[this.Select_Index].Buffer;
                    if (text.Equals("发送"))
                    {
                        if ((this.Select_Index > -1 && this.dgSocketInfo.SelectedRows.Count == 1) && this.lstRecPacket.Count > 0)
                        {
                            new SocketSend_Form
                            {
                                Send_Index = index.ToString(),
                                Send_Socket = socket.ToString(),
                                Send_Len = length.ToString(),
                                Send_IPTo = to,
                                Send_Byte = buffer
                            }.Show();
                        }
                    }
                    else if (text.Equals("添加到发送列表"))
                    {
                        DataRow row = SocketSend.dtSocketBatchSend.NewRow();
                        row[0] = index;
                        row[1] = socket;
                        row[2] = to;
                        row[3] = length;
                        row[4] = data;
                        row[5] = buffer;
                        SocketSend.dtSocketBatchSend.Rows.Add(row);
                        if (!SocketSend.bHasBatchSendForm)
                        {
                            new SocketBatchSend_Form().Show();
                        }
                    }
                    else if (text.Equals("使用此套接字"))
                    {
                        SocketSend.iUseSocket = socket;
                    }
                }
                catch (Exception ex)
                {
                    this.ShowDebug(ex.Message);
                }
            }
        }

        private void dgSocketInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgSocketInfo.SelectedRows.Count == 1)
            {
                this.Select_Index = this.dgSocketInfo.SelectedRows[0].Index;
                this.ShowPacketInfo();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string str = this.txtSearch.Text.Trim();
            if (!str.Equals(""))
            {
                for (int i = 0; i < this.dgSocketInfo.Rows.Count; i++)
                {
                    if (this.dgSocketInfo.Rows[i].Cells[6].Value.ToString().IndexOf(str) >= 0)
                    {
                        this.dgSocketInfo.Rows[i].Selected = true;
                        this.dgSocketInfo.CurrentCell = this.dgSocketInfo.Rows[i].Cells[0];
                        break;
                    }
                }
            }
        }

        private void tcPacketInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowPacketInfo();
        }

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event SocketPacketReceived RecSocketPacket;

        private void Event_RecSocketPacket(SocketInfo si)
        {
            this.dgSocketInfo.Invoke((MethodInvoker)delegate
            {
                this.lstRecPacket.Add(si);
            });
        }

        private void Init()
        {
            this.ws.Interecept_Recv = this.cbInterecept_Recv.Checked;
            this.ws.Interecept_RecvFrom = this.cbInterecept_RecvFrom.Checked;
            this.ws.Interecept_Send = this.cbInterecept_Send.Checked;
            this.ws.Interecept_SendTo = this.cbInterecept_SendTo.Checked;
            this.ws.Display_Recv = this.cbDisplay_Recv.Checked;
            this.ws.Display_RecvFrom = this.cbDisplay_RecvFrom.Checked;
            this.ws.Display_Send = this.cbDisplay_Send.Checked;
            this.ws.Display_SendTo = this.cbDisplay_SendTo.Checked;
            this.ws.Reset_CNT = this.cbReset_CNT.Checked;
            this.so.Filter_Size = this.cbFilter_Size.Checked;
            this.so.Filter_Socket = this.cbFilter_Socket.Checked;
            this.so.Filter_IP = this.cbFilter_IP.Checked;
            this.so.Filter_Packet = this.cbFilter_Packet.Checked;
            this.so.Filter_Size_From = this.txtFilter_Size_From.Text.Trim();
            this.so.Filter_Size_To = this.txtFilter_Size_To.Text.Trim();
            this.so.Filter_Socket_txt = this.txtFilter_Socket.Text.Trim();
            this.so.Filter_IP_txt = this.txtFilter_IP.Text.Trim();
            this.so.Filter_Packet_txt = this.txtFilter_Packet.Text.Trim();
            if (this.cbReset_CNT.Checked)
            {
                this.FilterCNT = 0;
                this.dgSocketInfo.Rows.Clear();
                this.rtbHEX.Clear();
                this.rtbDEC.Clear();
                this.rtbBIN.Clear();
                this.rtbUNICODE.Clear();
                this.rtbUTF8.Clear();
                this.rtbGB2312.Clear();
                this.rtbDEBUG.Clear();
            }
        }

        private void ShowDebug(string sLog)
        {
            if (this.bDebug)
            {
                this.rtbDEBUG.Invoke((MethodInvoker)delegate { this.rtbDEBUG.AppendText(sLog + "\n"); });
            }
        }

        private void ShowPacketInfo()
        {
            try
            {
                if (this.Select_Index > -1)
                {
                    byte[] bSelected = this.lstRecPacket[this.Select_Index].Buffer;
                    switch (tcPacketInfo.SelectedIndex)
                    {
                        case 0:
                            this.rtbHEX.Invoke((MethodInvoker)delegate { this.rtbHEX.Text = this.so.Byte_To_Hex(bSelected); });
                            break;
                        case 1:
                            this.rtbDEC.Invoke((MethodInvoker)delegate { this.rtbDEC.Text = this.so.Byte_To_Dec(bSelected); });
                            break;
                        case 2:
                            this.rtbBIN.Invoke((MethodInvoker)delegate { this.rtbBIN.Text = this.so.Byte_To_Bin(bSelected); });
                            break;
                        case 3:
                            this.rtbUNICODE.Invoke((MethodInvoker)delegate { this.rtbUNICODE.Text = this.so.Byte_To_Unicode(bSelected); });
                            break;
                        case 4:
                            this.rtbUTF8.Invoke((MethodInvoker)delegate { this.rtbUTF8.Text = this.so.Byte_To_UTF8(bSelected); });
                            break;
                        case 5:
                            this.rtbGB2312.Invoke((MethodInvoker)delegate { this.rtbGB2312.Text = this.so.Byte_To_GB2312(bSelected); });
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDebug("ShowPacketInfo - " + ex.Message);
            }
        }

        private void ShowSocketInfo()
        {
            try
            {
                if (this.ws._SocketQueue.Count > 0)
                {
                    SocketPacket s = this.ws._SocketQueue.Dequeue();
                    if (this.so.Filter_Default(s))
                    {
                        if (this.so.Filter(s))
                        {
                            int index = this.dgSocketInfo.Rows.Count + 1;
                            string type = s.Type;
                            int socket = s.Socket;
                            int length = s.Length;
                            byte[] buffer = s.Buffer;
                            string data = "";
                            if (length > this.iShowDataLen)
                            {
                                byte[] buffer2 = new byte[this.iShowDataLen];
                                for (int i = 0; i < this.iShowDataLen; i++)
                                {
                                    buffer2[i] = buffer[i];
                                }
                                data = this.so.Byte_To_Hex(buffer2) + " ...";
                            }
                            else
                            {
                                data = this.so.Byte_To_Hex(buffer);
                            }
                            SocketPacket.sockaddr addr = s.Addr;
                            string from = "";
                            string to = "";
                            if (type.Equals("R"))
                            {
                                type = "接收";
                                from = this.so.GetSocketIP(socket, "T");
                                to = this.so.GetSocketIP(socket, "F");
                            }
                            else if (type.Equals("S"))
                            {
                                type = "发送";
                                from = this.so.GetSocketIP(socket, "F");
                                to = this.so.GetSocketIP(socket, "T");
                            }
                            else if (type.Equals("ST"))
                            {
                                type = "发送到";
                                from = this.so.GetSocketIP(socket, "F");
                                to = this.so.GetSocketIP(addr.sin_addr, addr.sin_port);
                            }
                            else if (type.Equals("RF"))
                            {
                                type = "接收自";
                                from = this.so.GetSocketIP(addr.sin_addr, addr.sin_port);
                                to = this.so.GetSocketIP(socket, "F");
                            }
                            SocketInfo si = new SocketInfo(index, type, socket, from, to, length, data, buffer);
                            if (this.RecSocketPacket != null)
                            {
                                this.RecSocketPacket(si);
                            }
                        }
                        else
                        {
                            this.FilterCNT++;
                        }
                    }
                    else
                    {
                        this.FilterCNT++;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowDebug(ex.Message);
            }
        }
    }
}
