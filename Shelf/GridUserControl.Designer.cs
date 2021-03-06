namespace Shelf
{
    partial class GridUserControl
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
            this.components = new System.ComponentModel.Container();
            this.tipSetting = new System.Windows.Forms.ToolTip(this.components);
            this.panelStatus = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtPercet = new System.Windows.Forms.Label();
            this.txtWarning = new System.Windows.Forms.Label();
            this.remainLifeBar = new CustomControls.CProgressBar();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.txtCount);
            this.panelStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelStatus.Location = new System.Drawing.Point(154, 7);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(92, 56);
            this.panelStatus.TabIndex = 10;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCount.Font = new System.Drawing.Font("Arial", 42F, System.Drawing.FontStyle.Bold);
            this.txtCount.ForeColor = System.Drawing.Color.Black;
            this.txtCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCount.Location = new System.Drawing.Point(-15, 0);
            this.txtCount.Margin = new System.Windows.Forms.Padding(0);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(126, 56);
            this.txtCount.TabIndex = 3;
            this.txtCount.Text = "100";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtName.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Location = new System.Drawing.Point(10, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(93, 42);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "T1";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPercet
            // 
            this.txtPercet.AutoSize = true;
            this.txtPercet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPercet.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold);
            this.txtPercet.ForeColor = System.Drawing.Color.White;
            this.txtPercet.Location = new System.Drawing.Point(9, 66);
            this.txtPercet.Name = "txtPercet";
            this.txtPercet.Size = new System.Drawing.Size(64, 31);
            this.txtPercet.TabIndex = 11;
            this.txtPercet.Text = "99%";
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarning.BackColor = System.Drawing.Color.Transparent;
            this.txtWarning.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtWarning.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.txtWarning.ForeColor = System.Drawing.Color.Black;
            this.txtWarning.Location = new System.Drawing.Point(134, 64);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.Size = new System.Drawing.Size(117, 25);
            this.txtWarning.TabIndex = 12;
            this.txtWarning.Text = "警戒值: 100";
            this.txtWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // remainLifeBar
            // 
            this.remainLifeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remainLifeBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.remainLifeBar.ChannelHeight = 19;
            this.remainLifeBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.remainLifeBar.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.remainLifeBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.ForeColor = System.Drawing.Color.White;
            this.remainLifeBar.Location = new System.Drawing.Point(9, 88);
            this.remainLifeBar.Maximum = 200;
            this.remainLifeBar.Name = "remainLifeBar";
            this.remainLifeBar.PaintedBack = false;
            this.remainLifeBar.ShowMaximun = false;
            this.remainLifeBar.ShowValue = CustomControls.TextPosition.None;
            this.remainLifeBar.Size = new System.Drawing.Size(242, 30);
            this.remainLifeBar.SliderColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.SliderHeight = 23;
            this.remainLifeBar.StopPainting = false;
            this.remainLifeBar.SymbolAfter = "";
            this.remainLifeBar.SymbolBefore = "";
            this.remainLifeBar.TabIndex = 9;
            this.remainLifeBar.Value = 50;
            // 
            // GridUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.txtPercet);
            this.Controls.Add(this.txtWarning);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.remainLifeBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "GridUserControl";
            this.Size = new System.Drawing.Size(260, 125);
            this.Load += new System.EventHandler(this.Grid_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GridUserControl_Paint);
            this.panelStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip tipSetting;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.Label txtName;
        private CustomControls.CProgressBar remainLifeBar;
        private System.Windows.Forms.Label txtPercet;
        private System.Windows.Forms.Label txtWarning;
    }
}
