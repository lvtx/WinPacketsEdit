namespace WPELibrary
{
    partial class SocketSend_Form
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
            this.ssSocketSend = new System.Windows.Forms.StatusStrip();
            this.tlSendPacket = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSendPacket_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Success = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Success_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Fail = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Fail_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.bSendStop = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.gbSend2 = new System.Windows.Forms.GroupBox();
            this.txtSend_Port = new System.Windows.Forms.TextBox();
            this.lSend_Port = new System.Windows.Forms.Label();
            this.txtSend_IP = new System.Windows.Forms.TextBox();
            this.lSend_IP = new System.Windows.Forms.Label();
            this.gbSend1 = new System.Windows.Forms.GroupBox();
            this.txtSend_Len = new System.Windows.Forms.TextBox();
            this.lSend_Len = new System.Windows.Forms.Label();
            this.txtSend_Socket = new System.Windows.Forms.TextBox();
            this.lSend_Socket = new System.Windows.Forms.Label();
            this.gbSend_Bottom = new System.Windows.Forms.GroupBox();
            this.txtSend_CNT = new System.Windows.Forms.TextBox();
            this.txtSend_Int = new System.Windows.Forms.TextBox();
            this.lSend_Int = new System.Windows.Forms.Label();
            this.lSend_CNT = new System.Windows.Forms.Label();
            this.bgwSendPacket = new System.ComponentModel.BackgroundWorker();
            this.pSend_Top = new System.Windows.Forms.Panel();
            this.rtbSocketSend_Data = new System.Windows.Forms.RichTextBox();
            this.tSend = new System.Windows.Forms.Timer(this.components);
            this.ssSocketSend.SuspendLayout();
            this.gbSend2.SuspendLayout();
            this.gbSend1.SuspendLayout();
            this.gbSend_Bottom.SuspendLayout();
            this.pSend_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssSocketSend
            // 
            this.ssSocketSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlSendPacket,
            this.tlSendPacket_CNT,
            this.tlSplit,
            this.tlSend_Success,
            this.tlSend_Success_CNT,
            this.toolStripStatusLabel3,
            this.tlSend_Fail,
            this.tlSend_Fail_CNT});
            this.ssSocketSend.Location = new System.Drawing.Point(0, 206);
            this.ssSocketSend.Name = "ssSocketSend";
            this.ssSocketSend.Size = new System.Drawing.Size(552, 22);
            this.ssSocketSend.SizingGrip = false;
            this.ssSocketSend.TabIndex = 4;
            // 
            // tlSendPacket
            // 
            this.tlSendPacket.Name = "tlSendPacket";
            this.tlSendPacket.Size = new System.Drawing.Size(47, 17);
            this.tlSendPacket.Text = "已发送:";
            // 
            // tlSendPacket_CNT
            // 
            this.tlSendPacket_CNT.Name = "tlSendPacket_CNT";
            this.tlSendPacket_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlSendPacket_CNT.Text = "0";
            // 
            // tlSplit
            // 
            this.tlSplit.ForeColor = System.Drawing.Color.DarkGray;
            this.tlSplit.Name = "tlSplit";
            this.tlSplit.Size = new System.Drawing.Size(11, 17);
            this.tlSplit.Text = "|";
            // 
            // tlSend_Success
            // 
            this.tlSend_Success.Name = "tlSend_Success";
            this.tlSend_Success.Size = new System.Drawing.Size(35, 17);
            this.tlSend_Success.Text = "成功:";
            // 
            // tlSend_Success_CNT
            // 
            this.tlSend_Success_CNT.Name = "tlSend_Success_CNT";
            this.tlSend_Success_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlSend_Success_CNT.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // tlSend_Fail
            // 
            this.tlSend_Fail.Name = "tlSend_Fail";
            this.tlSend_Fail.Size = new System.Drawing.Size(35, 17);
            this.tlSend_Fail.Text = "失败:";
            // 
            // tlSend_Fail_CNT
            // 
            this.tlSend_Fail_CNT.Name = "tlSend_Fail_CNT";
            this.tlSend_Fail_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlSend_Fail_CNT.Text = "0";
            // 
            // bSendStop
            // 
            this.bSendStop.Location = new System.Drawing.Point(481, 175);
            this.bSendStop.Name = "bSendStop";
            this.bSendStop.Size = new System.Drawing.Size(60, 25);
            this.bSendStop.TabIndex = 6;
            this.bSendStop.Text = "停止 (&T)";
            this.bSendStop.UseVisualStyleBackColor = true;
            this.bSendStop.Click += new System.EventHandler(this.bSendStop_Click);
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(481, 142);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(60, 25);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "发送 (&F)";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // gbSend2
            // 
            this.gbSend2.Controls.Add(this.txtSend_Port);
            this.gbSend2.Controls.Add(this.lSend_Port);
            this.gbSend2.Controls.Add(this.txtSend_IP);
            this.gbSend2.Controls.Add(this.lSend_IP);
            this.gbSend2.Location = new System.Drawing.Point(146, 131);
            this.gbSend2.Name = "gbSend2";
            this.gbSend2.Size = new System.Drawing.Size(182, 75);
            this.gbSend2.TabIndex = 2;
            this.gbSend2.TabStop = false;
            // 
            // txtSend_Port
            // 
            this.txtSend_Port.Location = new System.Drawing.Point(68, 45);
            this.txtSend_Port.Name = "txtSend_Port";
            this.txtSend_Port.ReadOnly = true;
            this.txtSend_Port.Size = new System.Drawing.Size(60, 23);
            this.txtSend_Port.TabIndex = 3;
            this.txtSend_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSend_Port
            // 
            this.lSend_Port.AutoSize = true;
            this.lSend_Port.Location = new System.Drawing.Point(6, 48);
            this.lSend_Port.Name = "lSend_Port";
            this.lSend_Port.Size = new System.Drawing.Size(68, 17);
            this.lSend_Port.TabIndex = 1;
            this.lSend_Port.Text = "目的端口：";
            // 
            // txtSend_IP
            // 
            this.txtSend_IP.Location = new System.Drawing.Point(68, 16);
            this.txtSend_IP.Name = "txtSend_IP";
            this.txtSend_IP.ReadOnly = true;
            this.txtSend_IP.Size = new System.Drawing.Size(106, 23);
            this.txtSend_IP.TabIndex = 2;
            this.txtSend_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSend_IP
            // 
            this.lSend_IP.AutoSize = true;
            this.lSend_IP.Location = new System.Drawing.Point(6, 19);
            this.lSend_IP.Name = "lSend_IP";
            this.lSend_IP.Size = new System.Drawing.Size(55, 17);
            this.lSend_IP.TabIndex = 0;
            this.lSend_IP.Text = "目的IP：";
            // 
            // gbSend1
            // 
            this.gbSend1.Controls.Add(this.txtSend_Len);
            this.gbSend1.Controls.Add(this.lSend_Len);
            this.gbSend1.Controls.Add(this.txtSend_Socket);
            this.gbSend1.Controls.Add(this.lSend_Socket);
            this.gbSend1.Location = new System.Drawing.Point(6, 131);
            this.gbSend1.Name = "gbSend1";
            this.gbSend1.Size = new System.Drawing.Size(134, 75);
            this.gbSend1.TabIndex = 1;
            this.gbSend1.TabStop = false;
            // 
            // txtSend_Len
            // 
            this.txtSend_Len.Location = new System.Drawing.Point(58, 45);
            this.txtSend_Len.Name = "txtSend_Len";
            this.txtSend_Len.Size = new System.Drawing.Size(50, 23);
            this.txtSend_Len.TabIndex = 3;
            this.txtSend_Len.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSend_Len
            // 
            this.lSend_Len.AutoSize = true;
            this.lSend_Len.Location = new System.Drawing.Point(6, 48);
            this.lSend_Len.Name = "lSend_Len";
            this.lSend_Len.Size = new System.Drawing.Size(44, 17);
            this.lSend_Len.TabIndex = 1;
            this.lSend_Len.Text = "长度：";
            // 
            // txtSend_Socket
            // 
            this.txtSend_Socket.Location = new System.Drawing.Point(58, 16);
            this.txtSend_Socket.Name = "txtSend_Socket";
            this.txtSend_Socket.Size = new System.Drawing.Size(68, 23);
            this.txtSend_Socket.TabIndex = 2;
            this.txtSend_Socket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSend_Socket
            // 
            this.lSend_Socket.AutoSize = true;
            this.lSend_Socket.Location = new System.Drawing.Point(6, 19);
            this.lSend_Socket.Name = "lSend_Socket";
            this.lSend_Socket.Size = new System.Drawing.Size(56, 17);
            this.lSend_Socket.TabIndex = 0;
            this.lSend_Socket.Text = "套接字：";
            // 
            // gbSend_Bottom
            // 
            this.gbSend_Bottom.Controls.Add(this.txtSend_CNT);
            this.gbSend_Bottom.Controls.Add(this.txtSend_Int);
            this.gbSend_Bottom.Controls.Add(this.lSend_Int);
            this.gbSend_Bottom.Controls.Add(this.lSend_CNT);
            this.gbSend_Bottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSend_Bottom.Location = new System.Drawing.Point(334, 131);
            this.gbSend_Bottom.Name = "gbSend_Bottom";
            this.gbSend_Bottom.Size = new System.Drawing.Size(137, 75);
            this.gbSend_Bottom.TabIndex = 3;
            this.gbSend_Bottom.TabStop = false;
            // 
            // txtSend_CNT
            // 
            this.txtSend_CNT.Location = new System.Drawing.Point(77, 16);
            this.txtSend_CNT.Name = "txtSend_CNT";
            this.txtSend_CNT.Size = new System.Drawing.Size(50, 23);
            this.txtSend_CNT.TabIndex = 2;
            this.txtSend_CNT.Text = "1";
            this.txtSend_CNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSend_Int
            // 
            this.txtSend_Int.Location = new System.Drawing.Point(77, 45);
            this.txtSend_Int.Name = "txtSend_Int";
            this.txtSend_Int.Size = new System.Drawing.Size(50, 23);
            this.txtSend_Int.TabIndex = 3;
            this.txtSend_Int.Text = "1000";
            this.txtSend_Int.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSend_Int
            // 
            this.lSend_Int.AutoSize = true;
            this.lSend_Int.Location = new System.Drawing.Point(7, 48);
            this.lSend_Int.Name = "lSend_Int";
            this.lSend_Int.Size = new System.Drawing.Size(67, 17);
            this.lSend_Int.TabIndex = 1;
            this.lSend_Int.Text = "间隔(毫秒):";
            // 
            // lSend_CNT
            // 
            this.lSend_CNT.AutoSize = true;
            this.lSend_CNT.Location = new System.Drawing.Point(7, 19);
            this.lSend_CNT.Name = "lSend_CNT";
            this.lSend_CNT.Size = new System.Drawing.Size(68, 17);
            this.lSend_CNT.TabIndex = 0;
            this.lSend_CNT.Text = "发送次数：";
            // 
            // bgwSendPacket
            // 
            this.bgwSendPacket.WorkerSupportsCancellation = true;
            this.bgwSendPacket.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendPacket_DoWork);
            // 
            // pSend_Top
            // 
            this.pSend_Top.Controls.Add(this.rtbSocketSend_Data);
            this.pSend_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSend_Top.Location = new System.Drawing.Point(0, 0);
            this.pSend_Top.Name = "pSend_Top";
            this.pSend_Top.Padding = new System.Windows.Forms.Padding(3);
            this.pSend_Top.Size = new System.Drawing.Size(552, 136);
            this.pSend_Top.TabIndex = 0;
            // 
            // rtbSocketSend_Data
            // 
            this.rtbSocketSend_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSocketSend_Data.Location = new System.Drawing.Point(3, 3);
            this.rtbSocketSend_Data.Name = "rtbSocketSend_Data";
            this.rtbSocketSend_Data.Size = new System.Drawing.Size(546, 130);
            this.rtbSocketSend_Data.TabIndex = 0;
            this.rtbSocketSend_Data.Text = "";
            // 
            // tSend
            // 
            this.tSend.Enabled = true;
            this.tSend.Interval = 1000;
            this.tSend.Tick += new System.EventHandler(this.tSend_Tick);
            // 
            // SocketSend_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 228);
            this.Controls.Add(this.pSend_Top);
            this.Controls.Add(this.bSendStop);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.gbSend2);
            this.Controls.Add(this.gbSend1);
            this.Controls.Add(this.gbSend_Bottom);
            this.Controls.Add(this.ssSocketSend);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SocketSend_Form";
            this.Text = "发送封包 by RNShinoa";
            this.Load += new System.EventHandler(this.SocketSend_Form_Load);
            this.ssSocketSend.ResumeLayout(false);
            this.ssSocketSend.PerformLayout();
            this.gbSend2.ResumeLayout(false);
            this.gbSend2.PerformLayout();
            this.gbSend1.ResumeLayout(false);
            this.gbSend1.PerformLayout();
            this.gbSend_Bottom.ResumeLayout(false);
            this.gbSend_Bottom.PerformLayout();
            this.pSend_Top.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssSocketSend;
        private System.Windows.Forms.Button bSendStop;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.GroupBox gbSend2;
        private System.Windows.Forms.TextBox txtSend_Port;
        private System.Windows.Forms.Label lSend_Port;
        private System.Windows.Forms.TextBox txtSend_IP;
        private System.Windows.Forms.Label lSend_IP;
        private System.Windows.Forms.GroupBox gbSend1;
        private System.Windows.Forms.TextBox txtSend_Len;
        private System.Windows.Forms.Label lSend_Len;
        private System.Windows.Forms.TextBox txtSend_Socket;
        private System.Windows.Forms.Label lSend_Socket;
        private System.Windows.Forms.GroupBox gbSend_Bottom;
        private System.Windows.Forms.TextBox txtSend_Int;
        private System.Windows.Forms.Label lSend_Int;
        private System.Windows.Forms.Label lSend_CNT;
        private System.Windows.Forms.ToolStripStatusLabel tlSendPacket;
        private System.Windows.Forms.ToolStripStatusLabel tlSendPacket_CNT;
        private System.ComponentModel.BackgroundWorker bgwSendPacket;
        private System.Windows.Forms.Panel pSend_Top;
        private System.Windows.Forms.RichTextBox rtbSocketSend_Data;
        private System.Windows.Forms.Timer tSend;
        private System.Windows.Forms.ToolStripStatusLabel tlSplit;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Success;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Success_CNT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Fail;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Fail_CNT;
        private System.Windows.Forms.TextBox txtSend_CNT;
    }
}