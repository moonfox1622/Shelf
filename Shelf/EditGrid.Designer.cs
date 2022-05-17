namespace Shelf
{
    partial class EditGrid
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.remainLifeBar = new CustomControls.CProgressBar();
            this.picChange = new System.Windows.Forms.PictureBox();
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.remainLifeBar);
            this.panel1.Controls.Add(this.picStatus);
            this.panel1.Controls.Add(this.panelStatus);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 91);
            this.panel1.TabIndex = 13;
            // 
            // txtCount
            // 
            this.txtCount.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.Color.Black;
            this.txtCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtCount.Location = new System.Drawing.Point(-8, -6);
            this.txtCount.Margin = new System.Windows.Forms.Padding(0);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(105, 49);
            this.txtCount.TabIndex = 3;
            this.txtCount.Text = "100";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(2, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(39, 31);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "T1";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.txtCount);
            this.panelStatus.Location = new System.Drawing.Point(87, 5);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(85, 45);
            this.panelStatus.TabIndex = 11;
            // 
            // remainLifeBar
            // 
            this.remainLifeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remainLifeBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.remainLifeBar.ChannelHeight = 12;
            this.remainLifeBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.ForeColor = System.Drawing.Color.White;
            this.remainLifeBar.Location = new System.Drawing.Point(4, 65);
            this.remainLifeBar.Maximum = 200;
            this.remainLifeBar.Name = "remainLifeBar";
            this.remainLifeBar.PaintedBack = false;
            this.remainLifeBar.ShowMaximun = false;
            this.remainLifeBar.ShowValue = CustomControls.TextPosition.None;
            this.remainLifeBar.Size = new System.Drawing.Size(168, 20);
            this.remainLifeBar.SliderColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.SliderHeight = 20;
            this.remainLifeBar.StopPainting = false;
            this.remainLifeBar.SymbolAfter = "";
            this.remainLifeBar.SymbolBefore = "";
            this.remainLifeBar.TabIndex = 10;
            this.remainLifeBar.Value = 50;
            // 
            // picChange
            // 
            this.picChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChange.Image = global::Shelf.Properties.Resources.refresh;
            this.picChange.Location = new System.Drawing.Point(99, 3);
            this.picChange.Name = "picChange";
            this.picChange.Size = new System.Drawing.Size(20, 20);
            this.picChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChange.TabIndex = 16;
            this.picChange.TabStop = false;
            this.picChange.Click += new System.EventHandler(this.ChangeTool);
            // 
            // picEdit
            // 
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Image = global::Shelf.Properties.Resources.settings;
            this.picEdit.Location = new System.Drawing.Point(125, 3);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(20, 20);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEdit.TabIndex = 15;
            this.picEdit.TabStop = false;
            this.picEdit.Click += new System.EventHandler(this.EditTool);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::Shelf.Properties.Resources.trash;
            this.picDelete.Location = new System.Drawing.Point(151, 3);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(20, 20);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 14;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.DeleteTool);
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Transparent;
            this.picStatus.Image = global::Shelf.Properties.Resources.greenLight;
            this.picStatus.Location = new System.Drawing.Point(7, 11);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(36, 36);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatus.TabIndex = 9;
            this.picStatus.TabStop = false;
            this.picStatus.Visible = false;
            // 
            // EditGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.picChange);
            this.Controls.Add(this.picEdit);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.panel1);
            this.Name = "EditGrid";
            this.Size = new System.Drawing.Size(174, 115);
            this.Load += new System.EventHandler(this.Grid_Load);
            this.panel1.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtName;
        private CustomControls.CProgressBar remainLifeBar;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.PictureBox picChange;
    }
}
