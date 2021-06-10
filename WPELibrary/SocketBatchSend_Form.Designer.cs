namespace WPELibrary
{
    partial class SocketBatchSend_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgBatchSend = new System.Windows.Forms.DataGridView();
            this.cIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSocket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsBatchSend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ssSocketBatchSend = new System.Windows.Forms.StatusStrip();
            this.tlSendBatch = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSendBatch_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Success = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Success_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Fail = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlSend_Fail_CNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSend_Bottom = new System.Windows.Forms.GroupBox();
            this.bClear = new System.Windows.Forms.Button();
            this.bSendStop = new System.Windows.Forms.Button();
            this.txtSend_CNT = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.txtSend_Int = new System.Windows.Forms.TextBox();
            this.lSend_Int = new System.Windows.Forms.Label();
            this.lSend_CNT = new System.Windows.Forms.Label();
            this.bgwSendPacket = new System.ComponentModel.BackgroundWorker();
            this.tSend = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgBatchSend)).BeginInit();
            this.cmsBatchSend.SuspendLayout();
            this.ssSocketBatchSend.SuspendLayout();
            this.gbSend_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBatchSend
            // 
            this.dgBatchSend.AllowUserToAddRows = false;
            this.dgBatchSend.AllowUserToDeleteRows = false;
            this.dgBatchSend.AllowUserToResizeRows = false;
            this.dgBatchSend.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgBatchSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBatchSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIndex,
            this.cSocket,
            this.Column5,
            this.cLen,
            this.cData});
            this.dgBatchSend.ContextMenuStrip = this.cmsBatchSend;
            this.dgBatchSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBatchSend.Location = new System.Drawing.Point(0, 0);
            this.dgBatchSend.MultiSelect = false;
            this.dgBatchSend.Name = "dgBatchSend";
            this.dgBatchSend.RowHeadersVisible = false;
            this.dgBatchSend.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.WindowText;
            this.dgBatchSend.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgBatchSend.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.LimeGreen;
            this.dgBatchSend.RowTemplate.Height = 23;
            this.dgBatchSend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBatchSend.Size = new System.Drawing.Size(681, 348);
            this.dgBatchSend.TabIndex = 50;
            // 
            // cIndex
            // 
            this.cIndex.DataPropertyName = "序号";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cIndex.DefaultCellStyle = dataGridViewCellStyle1;
            this.cIndex.HeaderText = "序号";
            this.cIndex.Name = "cIndex";
            this.cIndex.ReadOnly = true;
            this.cIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cIndex.Width = 50;
            // 
            // cSocket
            // 
            this.cSocket.DataPropertyName = "套接字";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cSocket.DefaultCellStyle = dataGridViewCellStyle2;
            this.cSocket.HeaderText = "套接字";
            this.cSocket.Name = "cSocket";
            this.cSocket.ReadOnly = true;
            this.cSocket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cSocket.Width = 60;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "目的地址";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "目的地址";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // cLen
            // 
            this.cLen.DataPropertyName = "长度";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cLen.DefaultCellStyle = dataGridViewCellStyle4;
            this.cLen.HeaderText = "长度";
            this.cLen.Name = "cLen";
            this.cLen.ReadOnly = true;
            this.cLen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cLen.Width = 50;
            // 
            // cData
            // 
            this.cData.DataPropertyName = "数据";
            this.cData.HeaderText = "数据";
            this.cData.Name = "cData";
            this.cData.ReadOnly = true;
            this.cData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cData.Width = 340;
            // 
            // cmsBatchSend
            // 
            this.cmsBatchSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.cmsBatchSend.Name = "cmsBatchSend";
            this.cmsBatchSend.Size = new System.Drawing.Size(149, 26);
            this.cmsBatchSend.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsBatchSend_ItemClicked);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(148, 22);
            this.tsmiDelete.Text = "从列表中移除";
            // 
            // ssSocketBatchSend
            // 
            this.ssSocketBatchSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlSendBatch,
            this.tlSendBatch_CNT,
            this.tlSplit,
            this.tlSend_Success,
            this.tlSend_Success_CNT,
            this.toolStripStatusLabel3,
            this.tlSend_Fail,
            this.tlSend_Fail_CNT});
            this.ssSocketBatchSend.Location = new System.Drawing.Point(0, 326);
            this.ssSocketBatchSend.Name = "ssSocketBatchSend";
            this.ssSocketBatchSend.Size = new System.Drawing.Size(681, 22);
            this.ssSocketBatchSend.SizingGrip = false;
            this.ssSocketBatchSend.TabIndex = 51;
            // 
            // tlSendBatch
            // 
            this.tlSendBatch.Name = "tlSendBatch";
            this.tlSendBatch.Size = new System.Drawing.Size(71, 17);
            this.tlSendBatch.Text = "已循环次数:";
            // 
            // tlSendBatch_CNT
            // 
            this.tlSendBatch_CNT.Name = "tlSendBatch_CNT";
            this.tlSendBatch_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlSendBatch_CNT.Text = "0";
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
            this.tlSend_Success.Size = new System.Drawing.Size(59, 17);
            this.tlSend_Success.Text = "发送成功:";
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
            this.tlSend_Fail.Size = new System.Drawing.Size(59, 17);
            this.tlSend_Fail.Text = "发送失败:";
            // 
            // tlSend_Fail_CNT
            // 
            this.tlSend_Fail_CNT.Name = "tlSend_Fail_CNT";
            this.tlSend_Fail_CNT.Size = new System.Drawing.Size(15, 17);
            this.tlSend_Fail_CNT.Text = "0";
            // 
            // gbSend_Bottom
            // 
            this.gbSend_Bottom.Controls.Add(this.bClear);
            this.gbSend_Bottom.Controls.Add(this.bSendStop);
            this.gbSend_Bottom.Controls.Add(this.txtSend_CNT);
            this.gbSend_Bottom.Controls.Add(this.bSend);
            this.gbSend_Bottom.Controls.Add(this.txtSend_Int);
            this.gbSend_Bottom.Controls.Add(this.lSend_Int);
            this.gbSend_Bottom.Controls.Add(this.lSend_CNT);
            this.gbSend_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSend_Bottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSend_Bottom.Location = new System.Drawing.Point(0, 275);
            this.gbSend_Bottom.Name = "gbSend_Bottom";
            this.gbSend_Bottom.Size = new System.Drawing.Size(681, 51);
            this.gbSend_Bottom.TabIndex = 52;
            this.gbSend_Bottom.TabStop = false;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(375, 16);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(94, 29);
            this.bClear.TabIndex = 93;
            this.bClear.Text = "清空发送列表";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSendStop
            // 
            this.bSendStop.Location = new System.Drawing.Point(609, 16);
            this.bSendStop.Name = "bSendStop";
            this.bSendStop.Size = new System.Drawing.Size(60, 29);
            this.bSendStop.TabIndex = 92;
            this.bSendStop.Text = "停止 (&T)";
            this.bSendStop.UseVisualStyleBackColor = true;
            this.bSendStop.Click += new System.EventHandler(this.bSendStop_Click);
            // 
            // txtSend_CNT
            // 
            this.txtSend_CNT.Location = new System.Drawing.Point(77, 16);
            this.txtSend_CNT.Name = "txtSend_CNT";
            this.txtSend_CNT.Size = new System.Drawing.Size(50, 23);
            this.txtSend_CNT.TabIndex = 10;
            this.txtSend_CNT.Text = "1";
            this.txtSend_CNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(533, 16);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(60, 29);
            this.bSend.TabIndex = 91;
            this.bSend.Text = "发送 (&F)";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // txtSend_Int
            // 
            this.txtSend_Int.Location = new System.Drawing.Point(245, 16);
            this.txtSend_Int.Name = "txtSend_Int";
            this.txtSend_Int.Size = new System.Drawing.Size(50, 23);
            this.txtSend_Int.TabIndex = 90;
            this.txtSend_Int.Text = "1000";
            this.txtSend_Int.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSend_Int
            // 
            this.lSend_Int.AutoSize = true;
            this.lSend_Int.Location = new System.Drawing.Point(148, 19);
            this.lSend_Int.Name = "lSend_Int";
            this.lSend_Int.Size = new System.Drawing.Size(91, 17);
            this.lSend_Int.TabIndex = 8;
            this.lSend_Int.Text = "发送间隔(毫秒):";
            // 
            // lSend_CNT
            // 
            this.lSend_CNT.AutoSize = true;
            this.lSend_CNT.Location = new System.Drawing.Point(7, 19);
            this.lSend_CNT.Name = "lSend_CNT";
            this.lSend_CNT.Size = new System.Drawing.Size(68, 17);
            this.lSend_CNT.TabIndex = 6;
            this.lSend_CNT.Text = "循环次数：";
            // 
            // bgwSendPacket
            // 
            this.bgwSendPacket.WorkerSupportsCancellation = true;
            this.bgwSendPacket.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendPacket_DoWork);
            // 
            // tSend
            // 
            this.tSend.Enabled = true;
            this.tSend.Interval = 1000;
            this.tSend.Tick += new System.EventHandler(this.tSend_Tick);
            // 
            // SocketBatchSend_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(681, 348);
            this.Controls.Add(this.gbSend_Bottom);
            this.Controls.Add(this.ssSocketBatchSend);
            this.Controls.Add(this.dgBatchSend);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SocketBatchSend_Form";
            this.Text = "发送列表 by RNShinoa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SocketBatchSend_Form_FormClosed);
            this.Load += new System.EventHandler(this.SocketBatchSend_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBatchSend)).EndInit();
            this.cmsBatchSend.ResumeLayout(false);
            this.ssSocketBatchSend.ResumeLayout(false);
            this.ssSocketBatchSend.PerformLayout();
            this.gbSend_Bottom.ResumeLayout(false);
            this.gbSend_Bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBatchSend;
        private System.Windows.Forms.StatusStrip ssSocketBatchSend;
        private System.Windows.Forms.ToolStripStatusLabel tlSendBatch;
        private System.Windows.Forms.ToolStripStatusLabel tlSendBatch_CNT;
        private System.Windows.Forms.ToolStripStatusLabel tlSplit;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Success;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Success_CNT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Fail;
        private System.Windows.Forms.ToolStripStatusLabel tlSend_Fail_CNT;
        private System.Windows.Forms.GroupBox gbSend_Bottom;
        private System.Windows.Forms.TextBox txtSend_CNT;
        private System.Windows.Forms.TextBox txtSend_Int;
        private System.Windows.Forms.Label lSend_Int;
        private System.Windows.Forms.Label lSend_CNT;
        private System.Windows.Forms.Button bSendStop;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSocket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cData;
        private System.Windows.Forms.ContextMenuStrip cmsBatchSend;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.ComponentModel.BackgroundWorker bgwSendPacket;
        private System.Windows.Forms.Timer tSend;
        private System.Windows.Forms.Button bClear;
    }
}