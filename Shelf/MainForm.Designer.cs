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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtMachineName = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Panel();
            this.txtPage = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.txtDivide = new System.Windows.Forms.Label();
            this.txtMaxPage = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picMenu = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.historyBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnMuiltTool = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.panelContent = new System.Windows.Forms.Panel();
            this.picMachine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            this.sidebarPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMachineName
            // 
            this.txtMachineName.AutoSize = true;
            this.txtMachineName.Font = new System.Drawing.Font("微軟正黑體", 48F, System.Drawing.FontStyle.Bold);
            this.txtMachineName.Location = new System.Drawing.Point(132, 23);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(486, 81);
            this.txtMachineName.TabIndex = 1;
            this.txtMachineName.Text = "machineName";
            // 
            // content
            // 
            this.content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.content.Location = new System.Drawing.Point(5, 134);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1682, 819);
            this.content.TabIndex = 2;
            // 
            // txtPage
            // 
            this.txtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPage.AutoSize = true;
            this.txtPage.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPage.Location = new System.Drawing.Point(1571, 963);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(28, 31);
            this.txtPage.TabIndex = 6;
            this.txtPage.Text = "6";
            this.txtPage.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Image = global::Shelf.Properties.Resources.left;
            this.btnLast.Location = new System.Drawing.Point(1526, 959);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(40, 40);
            this.btnLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLast.TabIndex = 4;
            this.btnLast.TabStop = false;
            this.btnLast.Visible = false;
            this.btnLast.Click += new System.EventHandler(this.LastPageClick);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = global::Shelf.Properties.Resources.right;
            this.btnNext.Location = new System.Drawing.Point(1647, 959);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnNext.TabIndex = 3;
            this.btnNext.TabStop = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.NextPageClick);
            // 
            // txtDivide
            // 
            this.txtDivide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivide.AutoSize = true;
            this.txtDivide.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDivide.Location = new System.Drawing.Point(1596, 963);
            this.txtDivide.Name = "txtDivide";
            this.txtDivide.Size = new System.Drawing.Size(25, 31);
            this.txtDivide.TabIndex = 7;
            this.txtDivide.Text = "/";
            this.txtDivide.Visible = false;
            // 
            // txtMaxPage
            // 
            this.txtMaxPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxPage.AutoSize = true;
            this.txtMaxPage.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMaxPage.Location = new System.Drawing.Point(1616, 963);
            this.txtMaxPage.Name = "txtMaxPage";
            this.txtMaxPage.Size = new System.Drawing.Size(28, 31);
            this.txtMaxPage.TabIndex = 5;
            this.txtMaxPage.Text = "6";
            this.txtMaxPage.Visible = false;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.sidebarPanel.Controls.Add(this.panel2);
            this.sidebarPanel.Controls.Add(this.panel3);
            this.sidebarPanel.Controls.Add(this.panel4);
            this.sidebarPanel.Controls.Add(this.panel1);
            this.sidebarPanel.Controls.Add(this.panel7);
            this.sidebarPanel.Controls.Add(this.panel8);
            this.sidebarPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.MaximumSize = new System.Drawing.Size(188, 0);
            this.sidebarPanel.MinimumSize = new System.Drawing.Size(53, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(188, 1041);
            this.sidebarPanel.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.picMenu);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 100);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "刀具管理";
            // 
            // picMenu
            // 
            this.picMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMenu.Image = ((System.Drawing.Image)(resources.GetObject("picMenu.Image")));
            this.picMenu.Location = new System.Drawing.Point(7, 9);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(30, 30);
            this.picMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMenu.TabIndex = 0;
            this.picMenu.TabStop = false;
            this.picMenu.Visible = false;
            this.picMenu.Click += new System.EventHandler(this.MenuClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.historyBtn);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(3, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 70);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pictureBox1.Image = global::Shelf.Properties.Resources.history;
            this.pictureBox1.Location = new System.Drawing.Point(7, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.BtnHistoryClick);
            // 
            // historyBtn
            // 
            this.historyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyBtn.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.historyBtn.ForeColor = System.Drawing.Color.White;
            this.historyBtn.Location = new System.Drawing.Point(-27, -5);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(262, 82);
            this.historyBtn.TabIndex = 10;
            this.historyBtn.Text = "歷史紀錄";
            this.historyBtn.UseVisualStyleBackColor = true;
            this.historyBtn.Click += new System.EventHandler(this.BtnHistoryClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(3, 185);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(185, 70);
            this.panel4.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pictureBox2.Image = global::Shelf.Properties.Resources.computer;
            this.pictureBox2.Location = new System.Drawing.Point(7, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.BtnSystemLogClick);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(-27, -5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 82);
            this.button1.TabIndex = 10;
            this.button1.Text = "系統紀錄";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnSystemLogClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.btnMuiltTool);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(3, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 70);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pictureBox7.Image = global::Shelf.Properties.Resources.setting_w;
            this.pictureBox7.Location = new System.Drawing.Point(7, 20);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 11;
            this.pictureBox7.TabStop = false;
            // 
            // btnMuiltTool
            // 
            this.btnMuiltTool.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMuiltTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuiltTool.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold);
            this.btnMuiltTool.ForeColor = System.Drawing.Color.White;
            this.btnMuiltTool.Location = new System.Drawing.Point(-27, -5);
            this.btnMuiltTool.Name = "btnMuiltTool";
            this.btnMuiltTool.Size = new System.Drawing.Size(262, 82);
            this.btnMuiltTool.TabIndex = 10;
            this.btnMuiltTool.Text = "刀具設定";
            this.btnMuiltTool.UseVisualStyleBackColor = true;
            this.btnMuiltTool.Click += new System.EventHandler(this.BtnMuiltToolClick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox5);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Location = new System.Drawing.Point(3, 337);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(185, 70);
            this.panel7.TabIndex = 13;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pictureBox5.Image = global::Shelf.Properties.Resources.exchange;
            this.pictureBox5.Location = new System.Drawing.Point(7, 21);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.BtnDashBoardClick);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(-20, -5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(262, 82);
            this.button4.TabIndex = 10;
            this.button4.Text = "主頁撥放設定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BtnDashBoardClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pictureBox6);
            this.panel8.Controls.Add(this.btnRun);
            this.panel8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel8.Location = new System.Drawing.Point(3, 413);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(185, 70);
            this.panel8.TabIndex = 14;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(7, 20);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(-38, -5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(262, 82);
            this.btnRun.TabIndex = 10;
            this.btnRun.Tag = "start";
            this.btnRun.Text = "使用";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.SidebarTimer);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Controls.Add(this.txtPage);
            this.panelContent.Controls.Add(this.picMachine);
            this.panelContent.Controls.Add(this.btnLast);
            this.panelContent.Controls.Add(this.content);
            this.panelContent.Controls.Add(this.btnNext);
            this.panelContent.Controls.Add(this.txtDivide);
            this.panelContent.Controls.Add(this.txtMachineName);
            this.panelContent.Controls.Add(this.txtMaxPage);
            this.panelContent.Location = new System.Drawing.Point(202, 12);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1690, 1006);
            this.panelContent.TabIndex = 10;
            // 
            // picMachine
            // 
            this.picMachine.Image = global::Shelf.Properties.Resources.CNC3;
            this.picMachine.Location = new System.Drawing.Point(5, 15);
            this.picMachine.Name = "picMachine";
            this.picMachine.Size = new System.Drawing.Size(121, 96);
            this.picMachine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMachine.TabIndex = 8;
            this.picMachine.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(1904, 1030);
            this.ControlBox = false;
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.panelContent);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shelf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            this.sidebarPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label txtMachineName;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.PictureBox btnLast;
        private System.Windows.Forms.Label txtMaxPage;
        private System.Windows.Forms.Label txtPage;
        private System.Windows.Forms.Label txtDivide;
        private System.Windows.Forms.PictureBox picMachine;
        private System.Windows.Forms.FlowLayoutPanel sidebarPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PictureBox picMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btnMuiltTool;
    }
}

