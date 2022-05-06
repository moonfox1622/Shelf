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
            this.picAlarm = new System.Windows.Forms.PictureBox();
            this.txtCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(124, 29);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Name";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAlarm
            // 
            this.picAlarm.Image = global::Shelf.Properties.Resources.warning;
            this.picAlarm.Location = new System.Drawing.Point(85, 3);
            this.picAlarm.Name = "picAlarm";
            this.picAlarm.Size = new System.Drawing.Size(42, 42);
            this.picAlarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAlarm.TabIndex = 2;
            this.picAlarm.TabStop = false;
            this.picAlarm.Visible = false;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCount.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.Location = new System.Drawing.Point(3, 86);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(124, 40);
            this.txtCount.TabIndex = 3;
            this.txtCount.Text = "Count";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(201)))), ((int)(((byte)(165)))));
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.picAlarm);
            this.Controls.Add(this.txtName);
            this.Name = "Grid";
            this.Size = new System.Drawing.Size(130, 130);
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.PictureBox picAlarm;
        private System.Windows.Forms.Label txtCount;
    }
}
