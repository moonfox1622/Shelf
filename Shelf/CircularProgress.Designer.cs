namespace Shelf
{
    partial class CircularProgress
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
            this.percentBar = new CircularProgressBar.CircularProgressBar();
            this.txtName = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // percentBar
            // 
            this.percentBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.percentBar.AnimationSpeed = 500;
            this.percentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.percentBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentBar.Font = new System.Drawing.Font("微軟正黑體", 50F, System.Drawing.FontStyle.Bold);
            this.percentBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.percentBar.InnerMargin = 0;
            this.percentBar.InnerWidth = -1;
            this.percentBar.Location = new System.Drawing.Point(0, 0);
            this.percentBar.Margin = new System.Windows.Forms.Padding(0);
            this.percentBar.MarqueeAnimationSpeed = 2000;
            this.percentBar.Name = "percentBar";
            this.percentBar.OuterColor = System.Drawing.Color.Gray;
            this.percentBar.OuterMargin = -39;
            this.percentBar.OuterWidth = 39;
            this.percentBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(201)))), ((int)(((byte)(165)))));
            this.percentBar.ProgressWidth = 40;
            this.percentBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percentBar.SecondaryFont = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.percentBar.Size = new System.Drawing.Size(270, 270);
            this.percentBar.StartAngle = 270;
            this.percentBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentBar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.percentBar.SubscriptText = "";
            this.percentBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.percentBar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.percentBar.SuperscriptText = "";
            this.percentBar.TabIndex = 1;
            this.percentBar.Text = "100";
            this.percentBar.TextMargin = new System.Windows.Forms.Padding(0);
            this.percentBar.Value = 68;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtName.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.txtName.Location = new System.Drawing.Point(81, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(107, 34);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "T38";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPercent
            // 
            this.txtPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPercent.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.txtPercent.Location = new System.Drawing.Point(83, 169);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(107, 41);
            this.txtPercent.TabIndex = 4;
            this.txtPercent.Text = "100%";
            this.txtPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CircularProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.percentBar);
            this.Name = "CircularProgress";
            this.Size = new System.Drawing.Size(270, 270);
            this.Load += new System.EventHandler(this.CircularProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar percentBar;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtPercent;
    }
}
