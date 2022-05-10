namespace Shelf
{
    partial class Main
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
            this.btnReupload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.AutoScroll = true;
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.content.Location = new System.Drawing.Point(12, 46);
            this.content.Margin = new System.Windows.Forms.Padding(0);
            this.content.Name = "content";
            this.content.Padding = new System.Windows.Forms.Padding(20);
            this.content.Size = new System.Drawing.Size(987, 626);
            this.content.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(921, -7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(88, 60);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "更新";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // btnReupload
            // 
            this.btnReupload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnReupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReupload.ForeColor = System.Drawing.Color.White;
            this.btnReupload.Location = new System.Drawing.Point(833, -6);
            this.btnReupload.Name = "btnReupload";
            this.btnReupload.Size = new System.Drawing.Size(88, 60);
            this.btnReupload.TabIndex = 2;
            this.btnReupload.Text = "重新上傳";
            this.btnReupload.UseVisualStyleBackColor = false;
            this.btnReupload.Visible = false;
            this.btnReupload.Click += new System.EventHandler(this.BtnReuploadClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnReupload);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 43);
            this.panel1.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(-1, -6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 60);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "重新設定";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1024, 720);
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "Main";
            this.Text = "Shelf";
            this.Shown += new System.EventHandler(this.MainShown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReupload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReset;
    }
}

