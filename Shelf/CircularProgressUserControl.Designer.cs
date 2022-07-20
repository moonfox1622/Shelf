namespace Shelf
{
    partial class CircularProgressUserControl
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
            this.txtWarning = new System.Windows.Forms.Label();
            this.txtLife = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.Label();
            this.panelValue = new System.Windows.Forms.Panel();
            this.percentBar = new CircularProgressBar.CircularProgressBar();
            this.panelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtName.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(15, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(92, 35);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "T38";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtWarning.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtWarning.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txtWarning.ForeColor = System.Drawing.Color.Black;
            this.txtWarning.Location = new System.Drawing.Point(9, 146);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.Size = new System.Drawing.Size(114, 25);
            this.txtWarning.TabIndex = 13;
            this.txtWarning.Text = "警戒值: 100";
            this.txtWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLife
            // 
            this.txtLife.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtLife.Font = new System.Drawing.Font("Arial", 39F, System.Drawing.FontStyle.Bold);
            this.txtLife.ForeColor = System.Drawing.Color.Black;
            this.txtLife.Location = new System.Drawing.Point(-4, -3);
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(114, 53);
            this.txtLife.TabIndex = 4;
            this.txtLife.Text = "68";
            this.txtLife.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtUnit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtUnit.ForeColor = System.Drawing.Color.Black;
            this.txtUnit.Location = new System.Drawing.Point(62, 27);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(57, 19);
            this.txtUnit.TabIndex = 15;
            this.txtUnit.Text = "(mm)";
            this.txtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUnit.Visible = false;
            // 
            // panelValue
            // 
            this.panelValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelValue.Controls.Add(this.txtUnit);
            this.panelValue.Controls.Add(this.txtLife);
            this.panelValue.Location = new System.Drawing.Point(6, 95);
            this.panelValue.Name = "panelValue";
            this.panelValue.Size = new System.Drawing.Size(108, 52);
            this.panelValue.TabIndex = 16;
            // 
            // percentBar
            // 
            this.percentBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percentBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.percentBar.AnimationSpeed = 500;
            this.percentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.percentBar.Font = new System.Drawing.Font("Arial", 34F, System.Drawing.FontStyle.Bold);
            this.percentBar.ForeColor = System.Drawing.Color.Black;
            this.percentBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.percentBar.InnerMargin = 0;
            this.percentBar.InnerWidth = -1;
            this.percentBar.Location = new System.Drawing.Point(142, 11);
            this.percentBar.Margin = new System.Windows.Forms.Padding(0);
            this.percentBar.MarqueeAnimationSpeed = 2000;
            this.percentBar.Name = "percentBar";
            this.percentBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(201)))), ((int)(((byte)(165)))));
            this.percentBar.OuterMargin = -20;
            this.percentBar.OuterWidth = 20;
            this.percentBar.ProgressColor = System.Drawing.Color.Gray;
            this.percentBar.ProgressWidth = 20;
            this.percentBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percentBar.SecondaryFont = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.percentBar.Size = new System.Drawing.Size(160, 160);
            this.percentBar.StartAngle = 270;
            this.percentBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentBar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.percentBar.SubscriptText = "";
            this.percentBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentBar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.percentBar.SuperscriptText = "";
            this.percentBar.TabIndex = 17;
            this.percentBar.Text = "68%";
            this.percentBar.TextMargin = new System.Windows.Forms.Padding(0);
            this.percentBar.Value = 32;
            // 
            // CircularProgressUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.percentBar);
            this.Controls.Add(this.panelValue);
            this.Controls.Add(this.txtWarning);
            this.Controls.Add(this.txtName);
            this.Name = "CircularProgressUserControl";
            this.Size = new System.Drawing.Size(312, 181);
            this.Load += new System.EventHandler(this.CircularProgress_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsePaint);
            this.Resize += new System.EventHandler(this.CircularProgressUserControl_Resize);
            this.panelValue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtWarning;
        private System.Windows.Forms.Label txtLife;
        private System.Windows.Forms.Label txtUnit;
        private System.Windows.Forms.Panel panelValue;
        private CircularProgressBar.CircularProgressBar percentBar;
    }
}
