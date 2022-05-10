namespace Shelf
{
    partial class Grid
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.remainLifeBar = new CustomControls.CProgressBar();
            this.picWarning = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(-1, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(39, 31);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "T1";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.Color.White;
            this.txtCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCount.Location = new System.Drawing.Point(43, 0);
            this.txtCount.Margin = new System.Windows.Forms.Padding(0);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(123, 47);
            this.txtCount.TabIndex = 3;
            this.txtCount.Text = "100";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Transparent;
            this.picStatus.Image = global::Shelf.Properties.Resources.greenLight;
            this.picStatus.Location = new System.Drawing.Point(4, 9);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(36, 36);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatus.TabIndex = 5;
            this.picStatus.TabStop = false;
            // 
            // remainLifeBar
            // 
            this.remainLifeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remainLifeBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.remainLifeBar.ChannelHeight = 12;
            this.remainLifeBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.ForeColor = System.Drawing.Color.White;
            this.remainLifeBar.Location = new System.Drawing.Point(3, 52);
            this.remainLifeBar.Name = "remainLifeBar";
            this.remainLifeBar.PaintedBack = false;
            this.remainLifeBar.ShowMaximun = false;
            this.remainLifeBar.ShowValue = CustomControls.TextPosition.None;
            this.remainLifeBar.Size = new System.Drawing.Size(146, 27);
            this.remainLifeBar.SliderColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.SliderHeight = 20;
            this.remainLifeBar.StopPainting = false;
            this.remainLifeBar.SymbolAfter = "";
            this.remainLifeBar.SymbolBefore = "";
            this.remainLifeBar.TabIndex = 6;
            this.remainLifeBar.Value = 50;
            // 
            // picWarning
            // 
            this.picWarning.Image = global::Shelf.Properties.Resources.yellowwarning;
            this.picWarning.Location = new System.Drawing.Point(126, -4);
            this.picWarning.Name = "picWarning";
            this.picWarning.Size = new System.Drawing.Size(32, 32);
            this.picWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWarning.TabIndex = 7;
            this.picWarning.TabStop = false;
            this.picWarning.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.remainLifeBar);
            this.panel1.Controls.Add(this.picStatus);
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 82);
            this.panel1.TabIndex = 8;
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.picWarning);
            this.Controls.Add(this.panel1);
            this.Name = "Grid";
            this.Size = new System.Drawing.Size(159, 112);
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.PictureBox picStatus;
        private CustomControls.CProgressBar remainLifeBar;
        private System.Windows.Forms.PictureBox picWarning;
        private System.Windows.Forms.Panel panel1;
    }
}
