namespace ProcessInjector
{
    partial class ProcessList_Form
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
            this.lvProcessList = new System.Windows.Forms.ListView();
            this.chPName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRAM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lProcessCNT = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.bSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvProcessList
            // 
            this.lvProcessList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPName,
            this.chPID,
            this.chRAM});
            this.lvProcessList.FullRowSelect = true;
            this.lvProcessList.GridLines = true;
            this.lvProcessList.HideSelection = false;
            this.lvProcessList.Location = new System.Drawing.Point(2, 4);
            this.lvProcessList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvProcessList.MultiSelect = false;
            this.lvProcessList.Name = "lvProcessList";
            this.lvProcessList.Size = new System.Drawing.Size(400, 403);
            this.lvProcessList.TabIndex = 0;
            this.lvProcessList.UseCompatibleStateImageBehavior = false;
            this.lvProcessList.View = System.Windows.Forms.View.Details;
            this.lvProcessList.DoubleClick += new System.EventHandler(this.lvProcessList_DoubleClick);
            this.lvProcessList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvProcessList_KeyUp);
            // 
            // chPName
            // 
            this.chPName.Text = "进程名称";
            this.chPName.Width = 210;
            // 
            // chPID
            // 
            this.chPID.Text = "PID";
            // 
            // chRAM
            // 
            this.chRAM.Text = "RAM";
            this.chRAM.Width = 100;
            // 
            // lProcessCNT
            // 
            this.lProcessCNT.AutoSize = true;
            this.lProcessCNT.Location = new System.Drawing.Point(14, 425);
            this.lProcessCNT.Name = "lProcessCNT";
            this.lProcessCNT.Size = new System.Drawing.Size(44, 17);
            this.lProcessCNT.TabIndex = 1;
            this.lProcessCNT.Text = "进程数";
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(220, 418);
            this.bRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(87, 33);
            this.bRefresh.TabIndex = 2;
            this.bRefresh.Text = "刷新";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // bSelected
            // 
            this.bSelected.Location = new System.Drawing.Point(315, 418);
            this.bSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bSelected.Name = "bSelected";
            this.bSelected.Size = new System.Drawing.Size(87, 33);
            this.bSelected.TabIndex = 3;
            this.bSelected.Text = "确定";
            this.bSelected.UseVisualStyleBackColor = true;
            this.bSelected.Click += new System.EventHandler(this.bSelected_Click);
            // 
            // ProcessList_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 463);
            this.Controls.Add(this.bSelected);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.lProcessCNT);
            this.Controls.Add(this.lvProcessList);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ProcessList_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "进程列表 by RNShinoa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProcessList;
        private System.Windows.Forms.ColumnHeader chPName;
        private System.Windows.Forms.ColumnHeader chPID;
        private System.Windows.Forms.ColumnHeader chRAM;
        private System.Windows.Forms.Label lProcessCNT;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Button bSelected;
    }
}