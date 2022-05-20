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
            this.components = new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.remainLifeBar = new CustomControls.CProgressBar();
            this.tipSetting = new System.Windows.Forms.ToolTip(this.components);
            this.btnWarn = new System.Windows.Forms.PictureBox();
            this.btnRun = new System.Windows.Forms.PictureBox();
            this.picChange = new System.Windows.Forms.PictureBox();
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.panelStatus.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(4, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(39, 31);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "T1";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.txtCount);
            this.panelStatus.Location = new System.Drawing.Point(85, 5);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(85, 45);
            this.panelStatus.TabIndex = 7;
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panelGrid.Controls.Add(this.panelStatus);
            this.panelGrid.Controls.Add(this.txtName);
            this.panelGrid.Controls.Add(this.remainLifeBar);
            this.panelGrid.Location = new System.Drawing.Point(0, 27);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(174, 88);
            this.panelGrid.TabIndex = 8;
            // 
            // remainLifeBar
            // 
            this.remainLifeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remainLifeBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.remainLifeBar.ChannelHeight = 12;
            this.remainLifeBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.remainLifeBar.ForeColor = System.Drawing.Color.White;
            this.remainLifeBar.Location = new System.Drawing.Point(3, 58);
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
            this.remainLifeBar.TabIndex = 6;
            this.remainLifeBar.Value = 50;
            // 
            // btnWarn
            // 
            this.btnWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWarn.Image = global::Shelf.Properties.Resources.warning1;
            this.btnWarn.Location = new System.Drawing.Point(29, 4);
            this.btnWarn.Name = "btnWarn";
            this.btnWarn.Size = new System.Drawing.Size(20, 20);
            this.btnWarn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnWarn.TabIndex = 21;
            this.btnWarn.TabStop = false;
            this.btnWarn.Tag = "play";
            this.btnWarn.Click += new System.EventHandler(this.BtnWarnClick);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Image = global::Shelf.Properties.Resources.play;
            this.btnRun.Location = new System.Drawing.Point(3, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(20, 20);
            this.btnRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRun.TabIndex = 20;
            this.btnRun.TabStop = false;
            this.btnRun.Tag = "play";
            this.btnRun.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // picChange
            // 
            this.picChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChange.Image = global::Shelf.Properties.Resources.refresh;
            this.picChange.Location = new System.Drawing.Point(97, 4);
            this.picChange.Name = "picChange";
            this.picChange.Size = new System.Drawing.Size(20, 20);
            this.picChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChange.TabIndex = 19;
            this.picChange.TabStop = false;
            this.picChange.Visible = false;
            this.picChange.Click += new System.EventHandler(this.ChangeTool);
            // 
            // picEdit
            // 
            this.picEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Image = global::Shelf.Properties.Resources.settings;
            this.picEdit.Location = new System.Drawing.Point(123, 4);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(20, 20);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEdit.TabIndex = 18;
            this.picEdit.TabStop = false;
            this.picEdit.Visible = false;
            this.picEdit.Click += new System.EventHandler(this.EditTool);
            // 
            // picDelete
            // 
            this.picDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::Shelf.Properties.Resources.trash;
            this.picDelete.Location = new System.Drawing.Point(149, 4);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(20, 20);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 17;
            this.picDelete.TabStop = false;
            this.picDelete.Visible = false;
            this.picDelete.Click += new System.EventHandler(this.DeleteTool);
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.btnWarn);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.picChange);
            this.Controls.Add(this.picEdit);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.panelGrid);
            this.Name = "Grid";
            this.Size = new System.Drawing.Size(174, 115);
            this.Load += new System.EventHandler(this.Grid_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnWarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtCount;
        private CustomControls.CProgressBar remainLifeBar;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.PictureBox picChange;
        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.ToolTip tipSetting;
        private System.Windows.Forms.PictureBox btnRun;
        private System.Windows.Forms.PictureBox btnWarn;
    }
}
