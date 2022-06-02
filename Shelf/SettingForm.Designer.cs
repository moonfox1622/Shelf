namespace Shelf
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.settingPanel = new System.Windows.Forms.Panel();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.picChange = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picEdit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // settingPanel
            // 
            this.settingPanel.Location = new System.Drawing.Point(12, 58);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(265, 361);
            this.settingPanel.TabIndex = 4;
            // 
            // picInfo
            // 
            this.picInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInfo.Image = global::Shelf.Properties.Resources.info;
            this.picInfo.Location = new System.Drawing.Point(12, 12);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(40, 40);
            this.picInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInfo.TabIndex = 3;
            this.picInfo.TabStop = false;
            this.toolTip1.SetToolTip(this.picInfo, "詳細資訊");
            this.picInfo.Click += new System.EventHandler(this.InfoPage);
            // 
            // picChange
            // 
            this.picChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChange.Image = global::Shelf.Properties.Resources.refresh;
            this.picChange.Location = new System.Drawing.Point(89, 12);
            this.picChange.Name = "picChange";
            this.picChange.Size = new System.Drawing.Size(40, 40);
            this.picChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChange.TabIndex = 2;
            this.picChange.TabStop = false;
            this.toolTip1.SetToolTip(this.picChange, "更換刀具");
            this.picChange.Click += new System.EventHandler(this.ChangePage);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::Shelf.Properties.Resources.trash;
            this.picDelete.Location = new System.Drawing.Point(237, 12);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(40, 40);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 1;
            this.picDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.picDelete, "刪除刀具");
            this.picDelete.Click += new System.EventHandler(this.DeleteTool);
            // 
            // picEdit
            // 
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Image = global::Shelf.Properties.Resources.settings;
            this.picEdit.Location = new System.Drawing.Point(164, 12);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(40, 40);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEdit.TabIndex = 0;
            this.picEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.picEdit, "修改刀具");
            this.picEdit.Click += new System.EventHandler(this.EditPage);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(289, 431);
            this.Controls.Add(this.settingPanel);
            this.Controls.Add(this.picInfo);
            this.Controls.Add(this.picChange);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.picEdit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Shown += new System.EventHandler(this.SettingShown);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picChange;
        private System.Windows.Forms.PictureBox picInfo;
        private System.Windows.Forms.Panel settingPanel;
    }
}