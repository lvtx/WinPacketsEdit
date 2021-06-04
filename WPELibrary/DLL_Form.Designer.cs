namespace WPELibrary
{
    partial class DLL_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DLL_Form));
            this.tSocketInfo = new System.Windows.Forms.Timer(this.components);
            this.gbRight = new System.Windows.Forms.GroupBox();
            this.cbCleanSocket = new System.Windows.Forms.CheckBox();
            this.txtFilter_Packet = new System.Windows.Forms.TextBox();
            this.gbFilter_Size = new System.Windows.Forms.GroupBox();
            this.cbFilter_Size = new System.Windows.Forms.CheckBox();
            this.txtFilter_Size_From = new System.Windows.Forms.TextBox();
            this.txtFilter_Size_To = new System.Windows.Forms.TextBox();
            this.lSplit = new System.Windows.Forms.Label();
            this.cbFilter_Packet = new System.Windows.Forms.CheckBox();
            this.bStopHook = new System.Windows.Forms.Button();
            this.txtFilter_IP = new System.Windows.Forms.TextBox();
            this.gbFilter_Type = new System.Windows.Forms.GroupBox();
            this.cbInterecept_RecvFrom = new System.Windows.Forms.CheckBox();
            this.cbInterecept_Recv = new System.Windows.Forms.CheckBox();
            this.cbInterecept_SendTo = new System.Windows.Forms.CheckBox();
            this.cbInterecept_Send = new System.Windows.Forms.CheckBox();
            this.cbType_RecvFrom = new System.Windows.Forms.CheckBox();
            this.cbType_Recv = new System.Windows.Forms.CheckBox();
            this.cbType_SendTo = new System.Windows.Forms.CheckBox();
            this.cbType_Send = new System.Windows.Forms.CheckBox();
            this.cbFilter_IP = new System.Windows.Forms.CheckBox();
            this.bStartHook = new System.Windows.Forms.Button();
            this.txtFilter_Socket = new System.Windows.Forms.TextBox();
            this.cbFilter_Socket = new System.Windows.Forms.CheckBox();
            this.bgwSocketInfo = new System.ComponentModel.BackgroundWorker();
            this.gbBottom = new System.Windows.Forms.GroupBox();
            this.tcPacketInfo = new System.Windows.Forms.TabControl();
            this.tpHEX = new System.Windows.Forms.TabPage();
            this.rtbHEX = new System.Windows.Forms.RichTextBox();
            this.tpDEC = new System.Windows.Forms.TabPage();
            this.rtbDEC = new System.Windows.Forms.RichTextBox();
            this.tpBIN = new System.Windows.Forms.TabPage();
            this.rtbBIN = new System.Windows.Forms.RichTextBox();
            this.tpUNICODE = new System.Windows.Forms.TabPage();
            this.rtbUNICODE = new System.Windows.Forms.RichTextBox();
            this.tpUTF8 = new System.Windows.Forms.TabPage();
            this.rtbUTF8 = new System.Windows.Forms.RichTextBox();
            this.tpGB2312 = new System.Windows.Forms.TabPage();
            this.rtbGB2312 = new System.Windows.Forms.RichTextBox();
            this.tpDebug = new System.Windows.Forms.TabPage();
            this.rtbDEBUG = new System.Windows.Forms.RichTextBox();
            this.ssStatusInfo_Top = new System.Windows.Forms.StatusStrip();
            this.tlSystemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlALL = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlALL_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlQueue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlQueue_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlRecv = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlRecv_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlFilter_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlInterecept = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlInterecept_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsSocketInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSend = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSearch_Bottom = new System.Windows.Forms.GroupBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lSearch = new System.Windows.Forms.Label();
            this.lvSocketInfo = new System.Windows.Forms.ListView();
            this.chNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSocket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIPFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIPTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbRight.SuspendLayout();
            this.gbFilter_Size.SuspendLayout();
            this.gbFilter_Type.SuspendLayout();
            this.gbBottom.SuspendLayout();
            this.tcPacketInfo.SuspendLayout();
            this.tpHEX.SuspendLayout();
            this.tpDEC.SuspendLayout();
            this.tpBIN.SuspendLayout();
            this.tpUNICODE.SuspendLayout();
            this.tpUTF8.SuspendLayout();
            this.tpGB2312.SuspendLayout();
            this.tpDebug.SuspendLayout();
            this.ssStatusInfo_Top.SuspendLayout();
            this.cmsSocketInfo.SuspendLayout();
            this.gbSearch_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tSocketInfo
            // 
            this.tSocketInfo.Interval = 50;
            this.tSocketInfo.Tick += new System.EventHandler(this.tSocketInfo_Tick);
            // 
            // gbRight
            // 
            this.gbRight.Controls.Add(this.cbCleanSocket);
            this.gbRight.Controls.Add(this.txtFilter_Packet);
            this.gbRight.Controls.Add(this.gbFilter_Size);
            this.gbRight.Controls.Add(this.cbFilter_Packet);
            this.gbRight.Controls.Add(this.bStopHook);
            this.gbRight.Controls.Add(this.txtFilter_IP);
            this.gbRight.Controls.Add(this.gbFilter_Type);
            this.gbRight.Controls.Add(this.cbFilter_IP);
            this.gbRight.Controls.Add(this.bStartHook);
            this.gbRight.Controls.Add(this.txtFilter_Socket);
            this.gbRight.Controls.Add(this.cbFilter_Socket);
            this.gbRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbRight.Location = new System.Drawing.Point(0, 0);
            this.gbRight.Name = "gbRight";
            this.gbRight.Size = new System.Drawing.Size(883, 116);
            this.gbRight.TabIndex = 0;
            this.gbRight.TabStop = false;
            this.gbRight.Text = "[ 过滤条件 ] - 支持多个内容使用 ; 分隔符";
            // 
            // cbCleanSocket
            // 
            this.cbCleanSocket.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbCleanSocket.Checked = true;
            this.cbCleanSocket.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCleanSocket.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCleanSocket.Location = new System.Drawing.Point(762, 20);
            this.cbCleanSocket.Name = "cbCleanSocket";
            this.cbCleanSocket.Size = new System.Drawing.Size(22, 86);
            this.cbCleanSocket.TabIndex = 8;
            this.cbCleanSocket.Text = "清除数据";
            this.cbCleanSocket.UseVisualStyleBackColor = true;
            // 
            // txtFilter_Packet
            // 
            this.txtFilter_Packet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter_Packet.Location = new System.Drawing.Point(116, 79);
            this.txtFilter_Packet.Name = "txtFilter_Packet";
            this.txtFilter_Packet.Size = new System.Drawing.Size(400, 22);
            this.txtFilter_Packet.TabIndex = 5;
            this.txtFilter_Packet.WordWrap = false;
            // 
            // gbFilter_Size
            // 
            this.gbFilter_Size.Controls.Add(this.cbFilter_Size);
            this.gbFilter_Size.Controls.Add(this.txtFilter_Size_From);
            this.gbFilter_Size.Controls.Add(this.txtFilter_Size_To);
            this.gbFilter_Size.Controls.Add(this.lSplit);
            this.gbFilter_Size.Location = new System.Drawing.Point(520, 9);
            this.gbFilter_Size.Name = "gbFilter_Size";
            this.gbFilter_Size.Size = new System.Drawing.Size(89, 101);
            this.gbFilter_Size.TabIndex = 6;
            this.gbFilter_Size.TabStop = false;
            // 
            // cbFilter_Size
            // 
            this.cbFilter_Size.AutoSize = true;
            this.cbFilter_Size.Location = new System.Drawing.Point(10, 14);
            this.cbFilter_Size.Name = "cbFilter_Size";
            this.cbFilter_Size.Size = new System.Drawing.Size(75, 21);
            this.cbFilter_Size.TabIndex = 0;
            this.cbFilter_Size.Text = "封包长度";
            this.cbFilter_Size.UseVisualStyleBackColor = true;
            // 
            // txtFilter_Size_From
            // 
            this.txtFilter_Size_From.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter_Size_From.Location = new System.Drawing.Point(15, 41);
            this.txtFilter_Size_From.Name = "txtFilter_Size_From";
            this.txtFilter_Size_From.Size = new System.Drawing.Size(57, 22);
            this.txtFilter_Size_From.TabIndex = 1;
            this.txtFilter_Size_From.Text = "0";
            this.txtFilter_Size_From.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFilter_Size_To
            // 
            this.txtFilter_Size_To.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter_Size_To.Location = new System.Drawing.Point(15, 74);
            this.txtFilter_Size_To.Name = "txtFilter_Size_To";
            this.txtFilter_Size_To.Size = new System.Drawing.Size(57, 22);
            this.txtFilter_Size_To.TabIndex = 3;
            this.txtFilter_Size_To.Text = "100";
            this.txtFilter_Size_To.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSplit
            // 
            this.lSplit.AutoSize = true;
            this.lSplit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lSplit.Location = new System.Drawing.Point(35, 59);
            this.lSplit.Name = "lSplit";
            this.lSplit.Size = new System.Drawing.Size(17, 17);
            this.lSplit.TabIndex = 2;
            this.lSplit.Text = "~";
            // 
            // cbFilter_Packet
            // 
            this.cbFilter_Packet.AutoSize = true;
            this.cbFilter_Packet.Location = new System.Drawing.Point(17, 81);
            this.cbFilter_Packet.Name = "cbFilter_Packet";
            this.cbFilter_Packet.Size = new System.Drawing.Size(99, 21);
            this.cbFilter_Packet.TabIndex = 2;
            this.cbFilter_Packet.Text = "过滤封包内容";
            this.cbFilter_Packet.UseVisualStyleBackColor = true;
            // 
            // bStopHook
            // 
            this.bStopHook.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bStopHook.Location = new System.Drawing.Point(797, 69);
            this.bStopHook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bStopHook.Name = "bStopHook";
            this.bStopHook.Size = new System.Drawing.Size(75, 33);
            this.bStopHook.TabIndex = 10;
            this.bStopHook.Text = "结 束 (&J)";
            this.bStopHook.UseVisualStyleBackColor = true;
            this.bStopHook.Click += new System.EventHandler(this.bStopHook_Click);
            // 
            // txtFilter_IP
            // 
            this.txtFilter_IP.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter_IP.Location = new System.Drawing.Point(116, 51);
            this.txtFilter_IP.Name = "txtFilter_IP";
            this.txtFilter_IP.Size = new System.Drawing.Size(400, 22);
            this.txtFilter_IP.TabIndex = 4;
            this.txtFilter_IP.WordWrap = false;
            // 
            // gbFilter_Type
            // 
            this.gbFilter_Type.Controls.Add(this.cbInterecept_RecvFrom);
            this.gbFilter_Type.Controls.Add(this.cbInterecept_Recv);
            this.gbFilter_Type.Controls.Add(this.cbInterecept_SendTo);
            this.gbFilter_Type.Controls.Add(this.cbInterecept_Send);
            this.gbFilter_Type.Controls.Add(this.cbType_RecvFrom);
            this.gbFilter_Type.Controls.Add(this.cbType_Recv);
            this.gbFilter_Type.Controls.Add(this.cbType_SendTo);
            this.gbFilter_Type.Controls.Add(this.cbType_Send);
            this.gbFilter_Type.Location = new System.Drawing.Point(614, 9);
            this.gbFilter_Type.Name = "gbFilter_Type";
            this.gbFilter_Type.Padding = new System.Windows.Forms.Padding(1);
            this.gbFilter_Type.Size = new System.Drawing.Size(144, 101);
            this.gbFilter_Type.TabIndex = 7;
            this.gbFilter_Type.TabStop = false;
            // 
            // cbInterecept_RecvFrom
            // 
            this.cbInterecept_RecvFrom.AutoSize = true;
            this.cbInterecept_RecvFrom.Location = new System.Drawing.Point(9, 78);
            this.cbInterecept_RecvFrom.Name = "cbInterecept_RecvFrom";
            this.cbInterecept_RecvFrom.Size = new System.Drawing.Size(60, 21);
            this.cbInterecept_RecvFrom.TabIndex = 3;
            this.cbInterecept_RecvFrom.Text = "拦截 -";
            this.cbInterecept_RecvFrom.UseVisualStyleBackColor = true;
            // 
            // cbInterecept_Recv
            // 
            this.cbInterecept_Recv.AutoSize = true;
            this.cbInterecept_Recv.Location = new System.Drawing.Point(9, 57);
            this.cbInterecept_Recv.Name = "cbInterecept_Recv";
            this.cbInterecept_Recv.Size = new System.Drawing.Size(60, 21);
            this.cbInterecept_Recv.TabIndex = 2;
            this.cbInterecept_Recv.Text = "拦截 -";
            this.cbInterecept_Recv.UseVisualStyleBackColor = true;
            // 
            // cbInterecept_SendTo
            // 
            this.cbInterecept_SendTo.AutoSize = true;
            this.cbInterecept_SendTo.Location = new System.Drawing.Point(9, 34);
            this.cbInterecept_SendTo.Name = "cbInterecept_SendTo";
            this.cbInterecept_SendTo.Size = new System.Drawing.Size(60, 21);
            this.cbInterecept_SendTo.TabIndex = 1;
            this.cbInterecept_SendTo.Text = "拦截 -";
            this.cbInterecept_SendTo.UseVisualStyleBackColor = true;
            // 
            // cbInterecept_Send
            // 
            this.cbInterecept_Send.AutoSize = true;
            this.cbInterecept_Send.Location = new System.Drawing.Point(9, 11);
            this.cbInterecept_Send.Name = "cbInterecept_Send";
            this.cbInterecept_Send.Size = new System.Drawing.Size(60, 21);
            this.cbInterecept_Send.TabIndex = 0;
            this.cbInterecept_Send.Text = "拦截 -";
            this.cbInterecept_Send.UseVisualStyleBackColor = true;
            // 
            // cbType_RecvFrom
            // 
            this.cbType_RecvFrom.AutoSize = true;
            this.cbType_RecvFrom.Checked = true;
            this.cbType_RecvFrom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbType_RecvFrom.Location = new System.Drawing.Point(75, 78);
            this.cbType_RecvFrom.Name = "cbType_RecvFrom";
            this.cbType_RecvFrom.Size = new System.Drawing.Size(63, 21);
            this.cbType_RecvFrom.TabIndex = 7;
            this.cbType_RecvFrom.Text = "接收自";
            this.cbType_RecvFrom.UseVisualStyleBackColor = true;
            // 
            // cbType_Recv
            // 
            this.cbType_Recv.AutoSize = true;
            this.cbType_Recv.Checked = true;
            this.cbType_Recv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbType_Recv.Location = new System.Drawing.Point(75, 57);
            this.cbType_Recv.Name = "cbType_Recv";
            this.cbType_Recv.Size = new System.Drawing.Size(51, 21);
            this.cbType_Recv.TabIndex = 6;
            this.cbType_Recv.Text = "接收";
            this.cbType_Recv.UseVisualStyleBackColor = true;
            // 
            // cbType_SendTo
            // 
            this.cbType_SendTo.AutoSize = true;
            this.cbType_SendTo.Checked = true;
            this.cbType_SendTo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbType_SendTo.Location = new System.Drawing.Point(75, 34);
            this.cbType_SendTo.Name = "cbType_SendTo";
            this.cbType_SendTo.Size = new System.Drawing.Size(63, 21);
            this.cbType_SendTo.TabIndex = 5;
            this.cbType_SendTo.Text = "发送到";
            this.cbType_SendTo.UseVisualStyleBackColor = true;
            // 
            // cbType_Send
            // 
            this.cbType_Send.AutoSize = true;
            this.cbType_Send.Checked = true;
            this.cbType_Send.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbType_Send.Location = new System.Drawing.Point(75, 11);
            this.cbType_Send.Name = "cbType_Send";
            this.cbType_Send.Size = new System.Drawing.Size(51, 21);
            this.cbType_Send.TabIndex = 4;
            this.cbType_Send.Text = "发送";
            this.cbType_Send.UseVisualStyleBackColor = true;
            // 
            // cbFilter_IP
            // 
            this.cbFilter_IP.AutoSize = true;
            this.cbFilter_IP.Location = new System.Drawing.Point(17, 53);
            this.cbFilter_IP.Name = "cbFilter_IP";
            this.cbFilter_IP.Size = new System.Drawing.Size(86, 21);
            this.cbFilter_IP.TabIndex = 1;
            this.cbFilter_IP.Text = "过滤IP地址";
            this.cbFilter_IP.UseVisualStyleBackColor = true;
            // 
            // bStartHook
            // 
            this.bStartHook.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bStartHook.Location = new System.Drawing.Point(797, 20);
            this.bStartHook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bStartHook.Name = "bStartHook";
            this.bStartHook.Size = new System.Drawing.Size(75, 33);
            this.bStartHook.TabIndex = 9;
            this.bStartHook.Text = "开 始 (&K)";
            this.bStartHook.UseVisualStyleBackColor = true;
            this.bStartHook.Click += new System.EventHandler(this.bStartHook_Click);
            // 
            // txtFilter_Socket
            // 
            this.txtFilter_Socket.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter_Socket.Location = new System.Drawing.Point(116, 24);
            this.txtFilter_Socket.Name = "txtFilter_Socket";
            this.txtFilter_Socket.Size = new System.Drawing.Size(400, 22);
            this.txtFilter_Socket.TabIndex = 3;
            this.txtFilter_Socket.WordWrap = false;
            // 
            // cbFilter_Socket
            // 
            this.cbFilter_Socket.AutoSize = true;
            this.cbFilter_Socket.Location = new System.Drawing.Point(17, 26);
            this.cbFilter_Socket.Name = "cbFilter_Socket";
            this.cbFilter_Socket.Size = new System.Drawing.Size(87, 21);
            this.cbFilter_Socket.TabIndex = 0;
            this.cbFilter_Socket.Text = "过滤套接字";
            this.cbFilter_Socket.UseVisualStyleBackColor = true;
            // 
            // bgwSocketInfo
            // 
            this.bgwSocketInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSocketInfo_DoWork);
            // 
            // gbBottom
            // 
            this.gbBottom.Controls.Add(this.tcPacketInfo);
            this.gbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbBottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbBottom.Location = new System.Drawing.Point(0, 471);
            this.gbBottom.Margin = new System.Windows.Forms.Padding(0);
            this.gbBottom.Name = "gbBottom";
            this.gbBottom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBottom.Size = new System.Drawing.Size(883, 165);
            this.gbBottom.TabIndex = 5;
            this.gbBottom.TabStop = false;
            this.gbBottom.Text = "[ 数据显示方式 ]";
            // 
            // tcPacketInfo
            // 
            this.tcPacketInfo.Controls.Add(this.tpHEX);
            this.tcPacketInfo.Controls.Add(this.tpDEC);
            this.tcPacketInfo.Controls.Add(this.tpBIN);
            this.tcPacketInfo.Controls.Add(this.tpUNICODE);
            this.tcPacketInfo.Controls.Add(this.tpUTF8);
            this.tcPacketInfo.Controls.Add(this.tpGB2312);
            this.tcPacketInfo.Controls.Add(this.tpDebug);
            this.tcPacketInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPacketInfo.Location = new System.Drawing.Point(3, 20);
            this.tcPacketInfo.Name = "tcPacketInfo";
            this.tcPacketInfo.SelectedIndex = 0;
            this.tcPacketInfo.Size = new System.Drawing.Size(877, 141);
            this.tcPacketInfo.TabIndex = 10;
            // 
            // tpHEX
            // 
            this.tpHEX.Controls.Add(this.rtbHEX);
            this.tpHEX.Location = new System.Drawing.Point(4, 26);
            this.tpHEX.Name = "tpHEX";
            this.tpHEX.Size = new System.Drawing.Size(869, 111);
            this.tpHEX.TabIndex = 0;
            this.tpHEX.Text = "十六进制";
            this.tpHEX.UseVisualStyleBackColor = true;
            // 
            // rtbHEX
            // 
            this.rtbHEX.BackColor = System.Drawing.SystemColors.Window;
            this.rtbHEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHEX.Location = new System.Drawing.Point(0, 0);
            this.rtbHEX.Name = "rtbHEX";
            this.rtbHEX.Size = new System.Drawing.Size(869, 111);
            this.rtbHEX.TabIndex = 0;
            this.rtbHEX.Text = "";
            // 
            // tpDEC
            // 
            this.tpDEC.Controls.Add(this.rtbDEC);
            this.tpDEC.Location = new System.Drawing.Point(4, 26);
            this.tpDEC.Name = "tpDEC";
            this.tpDEC.Size = new System.Drawing.Size(869, 111);
            this.tpDEC.TabIndex = 1;
            this.tpDEC.Text = "十进制";
            this.tpDEC.UseVisualStyleBackColor = true;
            // 
            // rtbDEC
            // 
            this.rtbDEC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDEC.Location = new System.Drawing.Point(0, 0);
            this.rtbDEC.Name = "rtbDEC";
            this.rtbDEC.Size = new System.Drawing.Size(869, 111);
            this.rtbDEC.TabIndex = 0;
            this.rtbDEC.Text = "";
            // 
            // tpBIN
            // 
            this.tpBIN.Controls.Add(this.rtbBIN);
            this.tpBIN.Location = new System.Drawing.Point(4, 26);
            this.tpBIN.Name = "tpBIN";
            this.tpBIN.Size = new System.Drawing.Size(869, 111);
            this.tpBIN.TabIndex = 2;
            this.tpBIN.Text = "二进制";
            this.tpBIN.UseVisualStyleBackColor = true;
            // 
            // rtbBIN
            // 
            this.rtbBIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBIN.Location = new System.Drawing.Point(0, 0);
            this.rtbBIN.Name = "rtbBIN";
            this.rtbBIN.Size = new System.Drawing.Size(869, 111);
            this.rtbBIN.TabIndex = 0;
            this.rtbBIN.Text = "";
            // 
            // tpUNICODE
            // 
            this.tpUNICODE.Controls.Add(this.rtbUNICODE);
            this.tpUNICODE.Location = new System.Drawing.Point(4, 26);
            this.tpUNICODE.Name = "tpUNICODE";
            this.tpUNICODE.Size = new System.Drawing.Size(869, 111);
            this.tpUNICODE.TabIndex = 3;
            this.tpUNICODE.Text = "Unicode";
            this.tpUNICODE.UseVisualStyleBackColor = true;
            // 
            // rtbUNICODE
            // 
            this.rtbUNICODE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbUNICODE.Location = new System.Drawing.Point(0, 0);
            this.rtbUNICODE.Name = "rtbUNICODE";
            this.rtbUNICODE.Size = new System.Drawing.Size(869, 111);
            this.rtbUNICODE.TabIndex = 0;
            this.rtbUNICODE.Text = "";
            // 
            // tpUTF8
            // 
            this.tpUTF8.Controls.Add(this.rtbUTF8);
            this.tpUTF8.Location = new System.Drawing.Point(4, 26);
            this.tpUTF8.Name = "tpUTF8";
            this.tpUTF8.Size = new System.Drawing.Size(869, 111);
            this.tpUTF8.TabIndex = 4;
            this.tpUTF8.Text = "UTF-8";
            this.tpUTF8.UseVisualStyleBackColor = true;
            // 
            // rtbUTF8
            // 
            this.rtbUTF8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbUTF8.Location = new System.Drawing.Point(0, 0);
            this.rtbUTF8.Name = "rtbUTF8";
            this.rtbUTF8.Size = new System.Drawing.Size(869, 111);
            this.rtbUTF8.TabIndex = 0;
            this.rtbUTF8.Text = "";
            // 
            // tpGB2312
            // 
            this.tpGB2312.Controls.Add(this.rtbGB2312);
            this.tpGB2312.Location = new System.Drawing.Point(4, 26);
            this.tpGB2312.Name = "tpGB2312";
            this.tpGB2312.Size = new System.Drawing.Size(869, 111);
            this.tpGB2312.TabIndex = 5;
            this.tpGB2312.Text = "GB2312";
            this.tpGB2312.UseVisualStyleBackColor = true;
            // 
            // rtbGB2312
            // 
            this.rtbGB2312.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGB2312.Location = new System.Drawing.Point(0, 0);
            this.rtbGB2312.Name = "rtbGB2312";
            this.rtbGB2312.Size = new System.Drawing.Size(869, 111);
            this.rtbGB2312.TabIndex = 0;
            this.rtbGB2312.Text = "";
            // 
            // tpDebug
            // 
            this.tpDebug.Controls.Add(this.rtbDEBUG);
            this.tpDebug.Location = new System.Drawing.Point(4, 26);
            this.tpDebug.Name = "tpDebug";
            this.tpDebug.Size = new System.Drawing.Size(869, 111);
            this.tpDebug.TabIndex = 7;
            this.tpDebug.Text = "调试信息";
            this.tpDebug.UseVisualStyleBackColor = true;
            // 
            // rtbDEBUG
            // 
            this.rtbDEBUG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDEBUG.Location = new System.Drawing.Point(0, 0);
            this.rtbDEBUG.Name = "rtbDEBUG";
            this.rtbDEBUG.Size = new System.Drawing.Size(869, 111);
            this.rtbDEBUG.TabIndex = 0;
            this.rtbDEBUG.Text = "";
            // 
            // ssStatusInfo_Top
            // 
            this.ssStatusInfo_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.ssStatusInfo_Top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlSystemInfo,
            this.toolStripStatusLabel3,
            this.tlALL,
            this.tlALL_CNT,
            this.tlSplit,
            this.tlQueue,
            this.tlQueue_CNT,
            this.toolStripStatusLabel5,
            this.tlSend,
            this.tlSend_CNT,
            this.toolStripStatusLabel1,
            this.tlRecv,
            this.tlRecv_CNT,
            this.toolStripStatusLabel2,
            this.tlFilter,
            this.tlFilter_CNT,
            this.toolStripStatusLabel4,
            this.tlInterecept,
            this.tlInterecept_CNT});
            this.ssStatusInfo_Top.Location = new System.Drawing.Point(0, 116);
            this.ssStatusInfo_Top.Name = "ssStatusInfo_Top";
            this.ssStatusInfo_Top.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.ssStatusInfo_Top.Size = new System.Drawing.Size(883, 22);
            this.ssStatusInfo_Top.SizingGrip = false;
            this.ssStatusInfo_Top.TabIndex = 1;
            this.ssStatusInfo_Top.Text = "statusStrip1";
            // 
            // tlSystemInfo
            // 
            this.tlSystemInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlSystemInfo.Name = "tlSystemInfo";
            this.tlSystemInfo.Size = new System.Drawing.Size(56, 17);
            this.tlSystemInfo.Text = "系统信息";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // tlALL
            // 
            this.tlALL.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tlALL.Name = "tlALL";
            this.tlALL.Size = new System.Drawing.Size(58, 17);
            this.tlALL.Text = "封包总数:";
            // 
            // tlALL_CNT
            // 
            this.tlALL_CNT.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tlALL_CNT.Name = "tlALL_CNT";
            this.tlALL_CNT.Size = new System.Drawing.Size(14, 17);
            this.tlALL_CNT.Text = "0";
            // 
            // tlSplit
            // 
            this.tlSplit.ForeColor = System.Drawing.Color.DarkGray;
            this.tlSplit.Name = "tlSplit";
            this.tlSplit.Size = new System.Drawing.Size(11, 17);
            this.tlSplit.Text = "|";
            // 
            // tlQueue
            // 
            this.tlQueue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlQueue.Name = "tlQueue";
            this.tlQueue.Size = new System.Drawing.Size(47, 17);
            this.tlQueue.Text = "缓存区:";
            // 
            // tlQueue_CNT
            // 
            this.tlQueue_CNT.Name = "tlQueue_CNT";
            this.tlQueue_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlQueue_CNT.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // tlSend
            // 
            this.tlSend.Name = "tlSend";
            this.tlSend.Size = new System.Drawing.Size(35, 17);
            this.tlSend.Text = "发送:";
            // 
            // tlSend_CNT
            // 
            this.tlSend_CNT.Name = "tlSend_CNT";
            this.tlSend_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlSend_CNT.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tlRecv
            // 
            this.tlRecv.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlRecv.Name = "tlRecv";
            this.tlRecv.Size = new System.Drawing.Size(35, 17);
            this.tlRecv.Text = "接收:";
            // 
            // tlRecv_CNT
            // 
            this.tlRecv_CNT.Name = "tlRecv_CNT";
            this.tlRecv_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlRecv_CNT.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tlFilter
            // 
            this.tlFilter.Name = "tlFilter";
            this.tlFilter.Size = new System.Drawing.Size(35, 17);
            this.tlFilter.Text = "过滤:";
            // 
            // tlFilter_CNT
            // 
            this.tlFilter_CNT.Name = "tlFilter_CNT";
            this.tlFilter_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlFilter_CNT.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // tlInterecept
            // 
            this.tlInterecept.Name = "tlInterecept";
            this.tlInterecept.Size = new System.Drawing.Size(47, 17);
            this.tlInterecept.Text = "已拦截:";
            // 
            // tlInterecept_CNT
            // 
            this.tlInterecept_CNT.Name = "tlInterecept_CNT";
            this.tlInterecept_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlInterecept_CNT.Text = "0";
            // 
            // cmsSocketInfo
            // 
            this.cmsSocketInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSend});
            this.cmsSocketInfo.Name = "cmsSocketInfo";
            this.cmsSocketInfo.Size = new System.Drawing.Size(153, 48);
            this.cmsSocketInfo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsSocketInfo_ItemClicked);
            // 
            // tsmiSend
            // 
            this.tsmiSend.Name = "tsmiSend";
            this.tsmiSend.Size = new System.Drawing.Size(152, 22);
            this.tsmiSend.Text = "发送";
            // 
            // gbSearch_Bottom
            // 
            this.gbSearch_Bottom.Controls.Add(this.bSearch);
            this.gbSearch_Bottom.Controls.Add(this.txtSearch);
            this.gbSearch_Bottom.Controls.Add(this.lSearch);
            this.gbSearch_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSearch_Bottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSearch_Bottom.Location = new System.Drawing.Point(0, 418);
            this.gbSearch_Bottom.Name = "gbSearch_Bottom";
            this.gbSearch_Bottom.Size = new System.Drawing.Size(883, 53);
            this.gbSearch_Bottom.TabIndex = 4;
            this.gbSearch_Bottom.TabStop = false;
            this.gbSearch_Bottom.Text = "[ 数据搜索 ]";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(811, 18);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(60, 28);
            this.bSearch.TabIndex = 2;
            this.bSearch.Text = "搜索";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(153, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(641, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // lSearch
            // 
            this.lSearch.AutoSize = true;
            this.lSearch.Location = new System.Drawing.Point(14, 25);
            this.lSearch.Name = "lSearch";
            this.lSearch.Size = new System.Drawing.Size(140, 17);
            this.lSearch.TabIndex = 0;
            this.lSearch.Text = "搜索内容（十六进制）：";
            // 
            // lvSocketInfo
            // 
            this.lvSocketInfo.BackColor = System.Drawing.Color.Black;
            this.lvSocketInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNum,
            this.chType,
            this.chSocket,
            this.chIPFrom,
            this.chIPTo,
            this.chLen,
            this.chData});
            this.lvSocketInfo.ContextMenuStrip = this.cmsSocketInfo;
            this.lvSocketInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSocketInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvSocketInfo.ForeColor = System.Drawing.Color.LawnGreen;
            this.lvSocketInfo.FullRowSelect = true;
            this.lvSocketInfo.GridLines = true;
            this.lvSocketInfo.HideSelection = false;
            this.lvSocketInfo.Location = new System.Drawing.Point(0, 138);
            this.lvSocketInfo.MultiSelect = false;
            this.lvSocketInfo.Name = "lvSocketInfo";
            this.lvSocketInfo.Size = new System.Drawing.Size(883, 280);
            this.lvSocketInfo.TabIndex = 2;
            this.lvSocketInfo.UseCompatibleStateImageBehavior = false;
            this.lvSocketInfo.View = System.Windows.Forms.View.Details;
            this.lvSocketInfo.SelectedIndexChanged += new System.EventHandler(this.lvSocketInfo_SelectedIndexChanged);
            // 
            // chNum
            // 
            this.chNum.Text = "序号";
            this.chNum.Width = 50;
            // 
            // chType
            // 
            this.chType.Text = "类别";
            this.chType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chSocket
            // 
            this.chSocket.Text = "套接字";
            this.chSocket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chIPFrom
            // 
            this.chIPFrom.Text = "源地址";
            this.chIPFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chIPFrom.Width = 150;
            // 
            // chIPTo
            // 
            this.chIPTo.Text = "目标地址";
            this.chIPTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chIPTo.Width = 150;
            // 
            // chLen
            // 
            this.chLen.Text = "长度";
            this.chLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chData
            // 
            this.chData.Text = "数据";
            this.chData.Width = 300;
            // 
            // DLL_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 636);
            this.Controls.Add(this.lvSocketInfo);
            this.Controls.Add(this.gbSearch_Bottom);
            this.Controls.Add(this.ssStatusInfo_Top);
            this.Controls.Add(this.gbBottom);
            this.Controls.Add(this.gbRight);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "DLL_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "封包拦截器 by RNShinoa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DLL_Form_FormClosed);
            this.gbRight.ResumeLayout(false);
            this.gbRight.PerformLayout();
            this.gbFilter_Size.ResumeLayout(false);
            this.gbFilter_Size.PerformLayout();
            this.gbFilter_Type.ResumeLayout(false);
            this.gbFilter_Type.PerformLayout();
            this.gbBottom.ResumeLayout(false);
            this.tcPacketInfo.ResumeLayout(false);
            this.tpHEX.ResumeLayout(false);
            this.tpDEC.ResumeLayout(false);
            this.tpBIN.ResumeLayout(false);
            this.tpUNICODE.ResumeLayout(false);
            this.tpUTF8.ResumeLayout(false);
            this.tpGB2312.ResumeLayout(false);
            this.tpDebug.ResumeLayout(false);
            this.ssStatusInfo_Top.ResumeLayout(false);
            this.ssStatusInfo_Top.PerformLayout();
            this.cmsSocketInfo.ResumeLayout(false);
            this.gbSearch_Bottom.ResumeLayout(false);
            this.gbSearch_Bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tSocketInfo;
        private System.Windows.Forms.GroupBox gbRight;
        private System.Windows.Forms.GroupBox gbFilter_Size;
        private System.Windows.Forms.Label lSplit;
        private System.Windows.Forms.TextBox txtFilter_Size_To;
        private System.Windows.Forms.TextBox txtFilter_Size_From;
        private System.Windows.Forms.CheckBox cbFilter_Size;
        private System.Windows.Forms.Button bStopHook;
        private System.Windows.Forms.GroupBox gbFilter_Type;
        private System.Windows.Forms.Button bStartHook;
        private System.Windows.Forms.TextBox txtFilter_Packet;
        private System.Windows.Forms.CheckBox cbFilter_Packet;
        private System.Windows.Forms.TextBox txtFilter_IP;
        private System.Windows.Forms.CheckBox cbFilter_IP;
        private System.Windows.Forms.TextBox txtFilter_Socket;
        private System.Windows.Forms.CheckBox cbFilter_Socket;
        private System.ComponentModel.BackgroundWorker bgwSocketInfo;
        private System.Windows.Forms.GroupBox gbBottom;
        private System.Windows.Forms.TabControl tcPacketInfo;
        private System.Windows.Forms.TabPage tpHEX;
        private System.Windows.Forms.TabPage tpDEC;
        private System.Windows.Forms.RichTextBox rtbDEC;
        private System.Windows.Forms.TabPage tpBIN;
        private System.Windows.Forms.TabPage tpUNICODE;
        private System.Windows.Forms.RichTextBox rtbUNICODE;
        private System.Windows.Forms.TabPage tpUTF8;
        private System.Windows.Forms.RichTextBox rtbUTF8;
        private System.Windows.Forms.TabPage tpGB2312;
        private System.Windows.Forms.RichTextBox rtbGB2312;
        private System.Windows.Forms.TabPage tpDebug;
        private System.Windows.Forms.RichTextBox rtbDEBUG;
        private System.Windows.Forms.StatusStrip ssStatusInfo_Top;
        private System.Windows.Forms.ToolStripStatusLabel tlALL;
        private System.Windows.Forms.ToolStripStatusLabel tlALL_CNT;
        private System.Windows.Forms.ToolStripStatusLabel tlSplit;
        private System.Windows.Forms.ToolStripStatusLabel tlSend;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_CNT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tlRecv;
        private System.Windows.Forms.ToolStripStatusLabel tlRecv_CNT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tlFilter;
        private System.Windows.Forms.ToolStripStatusLabel tlFilter_CNT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tlQueue;
        private System.Windows.Forms.ToolStripStatusLabel tlQueue_CNT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.RichTextBox rtbHEX;
        private System.Windows.Forms.RichTextBox rtbBIN;
        private System.Windows.Forms.ToolStripStatusLabel tlSystemInfo;
        private System.Windows.Forms.CheckBox cbType_RecvFrom;
        private System.Windows.Forms.CheckBox cbType_Recv;
        private System.Windows.Forms.CheckBox cbType_SendTo;
        private System.Windows.Forms.CheckBox cbType_Send;
        private System.Windows.Forms.CheckBox cbInterecept_RecvFrom;
        private System.Windows.Forms.CheckBox cbInterecept_Recv;
        private System.Windows.Forms.CheckBox cbInterecept_SendTo;
        private System.Windows.Forms.CheckBox cbInterecept_Send;
        private System.Windows.Forms.ToolStripStatusLabel tlInterecept;
        private System.Windows.Forms.ToolStripStatusLabel tlInterecept_CNT;
        private System.Windows.Forms.GroupBox gbSearch_Bottom;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lSearch;
        private System.Windows.Forms.ContextMenuStrip cmsSocketInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiSend;
        private System.Windows.Forms.ListView lvSocketInfo;
        private System.Windows.Forms.ColumnHeader chNum;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chSocket;
        private System.Windows.Forms.ColumnHeader chIPFrom;
        private System.Windows.Forms.ColumnHeader chIPTo;
        private System.Windows.Forms.ColumnHeader chLen;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.CheckBox cbCleanSocket;
    }
}