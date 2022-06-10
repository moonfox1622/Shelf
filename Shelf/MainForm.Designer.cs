namespace Shelf
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.content = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtMachineName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.content.AutoScroll = true;
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.content.Cursor = System.Windows.Forms.Cursors.Default;
            this.content.Location = new System.Drawing.Point(118, 82);
            this.content.Margin = new System.Windows.Forms.Padding(0);
            this.content.Name = "content";
            this.content.Padding = new System.Windows.Forms.Padding(20);
            this.content.Size = new System.Drawing.Size(1777, 947);
            this.content.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(-5, 136);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(130, 47);
            this.btnRun.TabIndex = 1;
            this.btnRun.Tag = "start";
            this.btnRun.Text = "使用";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.btnDashBoard);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 1046);
            this.panel1.TabIndex = 0;
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("微軟正黑體", 13F, System.Drawing.FontStyle.Bold);
            this.btnDashBoard.ForeColor = System.Drawing.Color.White;
            this.btnDashBoard.Location = new System.Drawing.Point(-12, 851);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(142, 47);
            this.btnDashBoard.TabIndex = 9;
            this.btnDashBoard.Tag = "start";
            this.btnDashBoard.Text = "主頁播放設定";
            this.btnDashBoard.UseVisualStyleBackColor = false;
            this.btnDashBoard.Click += new System.EventHandler(this.BtnDashBoardClick);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(-5, 916);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(130, 47);
            this.btnSetting.TabIndex = 8;
            this.btnSetting.Text = "刀具設定";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.BtnSettingClick);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(-5, 242);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(130, 47);
            this.btnHistory.TabIndex = 7;
            this.btnHistory.Text = "歷史紀錄";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.BtnHistoryClick);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(-5, 982);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 47);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "重新設定";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // txtMachineName
            // 
            this.txtMachineName.AutoSize = true;
            this.txtMachineName.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMachineName.Location = new System.Drawing.Point(121, 24);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(279, 47);
            this.txtMachineName.TabIndex = 1;
            this.txtMachineName.Text = "machineName";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shelf";
            this.Shown += new System.EventHandler(this.MainShown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Label txtMachineName;
    }
}

