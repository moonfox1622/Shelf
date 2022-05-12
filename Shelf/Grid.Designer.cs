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
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.remainLifeBar = new CustomControls.CProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Transparent;
            this.picStatus.Image = global::Shelf.Properties.Resources.greenLight;
            this.picStatus.Location = new System.Drawing.Point(6, 9);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(36, 36);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatus.TabIndex = 5;
            this.picStatus.TabStop = false;
            this.picStatus.Visible = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(1, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(39, 31);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "T1";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCount.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.Color.Black;
            this.txtCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCount.Location = new System.Drawing.Point(-33, -7);
            this.txtCount.Margin = new System.Windows.Forms.Padding(0);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(105, 49);
            this.txtCount.TabIndex = 3;
            this.txtCount.Text = "100";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.txtCount);
            this.panelStatus.Location = new System.Drawing.Point(74, 1);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(60, 45);
            this.panelStatus.TabIndex = 7;
            // 
            // remainLifeBar
            // 
            this.remainLifeBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.remainLifeBar.ChannelHeight = 12;
            this.remainLifeBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.ForeColor = System.Drawing.Color.White;
            this.remainLifeBar.Location = new System.Drawing.Point(3, 57);
            this.remainLifeBar.Maximum = 200;
            this.remainLifeBar.Name = "remainLifeBar";
            this.remainLifeBar.PaintedBack = false;
            this.remainLifeBar.ShowMaximun = false;
            this.remainLifeBar.ShowValue = CustomControls.TextPosition.None;
            this.remainLifeBar.Size = new System.Drawing.Size(130, 20);
            this.remainLifeBar.SliderColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.SliderHeight = 20;
            this.remainLifeBar.StopPainting = false;
            this.remainLifeBar.SymbolAfter = "";
            this.remainLifeBar.SymbolBefore = "";
            this.remainLifeBar.TabIndex = 6;
            this.remainLifeBar.Value = 50;
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.remainLifeBar);
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.panelStatus);
            this.Name = "Grid";
            this.Size = new System.Drawing.Size(136, 85);
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtCount;
        private CustomControls.CProgressBar remainLifeBar;
        private System.Windows.Forms.Panel panelStatus;
    }
}
