namespace Shelf
{
    partial class SettingPageForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolGridView = new System.Windows.Forms.DataGridView();
            this.machineList = new System.Windows.Forms.ComboBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewTool = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.SuspendLayout();
            // 
            // toolGridView
            // 
            this.toolGridView.AllowUserToAddRows = false;
            this.toolGridView.AllowUserToDeleteRows = false;
            this.toolGridView.AllowUserToResizeColumns = false;
            this.toolGridView.AllowUserToResizeRows = false;
            this.toolGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.toolGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.toolGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.toolGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.toolGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.toolGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.toolGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.toolGridView.Location = new System.Drawing.Point(15, 99);
            this.toolGridView.Margin = new System.Windows.Forms.Padding(6);
            this.toolGridView.MultiSelect = false;
            this.toolGridView.Name = "toolGridView";
            this.toolGridView.ReadOnly = true;
            this.toolGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.toolGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.Height = 35;
            this.toolGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolGridView.Size = new System.Drawing.Size(1234, 567);
            this.toolGridView.TabIndex = 3;
            this.toolGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CellMouseClick);
            // 
            // machineList
            // 
            this.machineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineList.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.machineList.FormattingEnabled = true;
            this.machineList.Location = new System.Drawing.Point(108, 12);
            this.machineList.Name = "machineList";
            this.machineList.Size = new System.Drawing.Size(121, 29);
            this.machineList.TabIndex = 5;
            this.machineList.SelectedIndexChanged += new System.EventHandler(this.MachineChange);
            // 
            // picNew
            // 
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Image = global::Shelf.Properties.Resources.add;
            this.picNew.Location = new System.Drawing.Point(15, -74);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(212, 41);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 4;
            this.picNew.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "機台選擇：";
            // 
            // btnNewTool
            // 
            this.btnNewTool.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNewTool.Location = new System.Drawing.Point(16, 54);
            this.btnNewTool.Name = "btnNewTool";
            this.btnNewTool.Size = new System.Drawing.Size(96, 36);
            this.btnNewTool.TabIndex = 7;
            this.btnNewTool.Text = "新增刀具";
            this.btnNewTool.UseVisualStyleBackColor = true;
            this.btnNewTool.Click += new System.EventHandler(this.BtnNewToolClick);
            // 
            // SettingPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnNewTool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machineList);
            this.Controls.Add(this.picNew);
            this.Controls.Add(this.toolGridView);
            this.Name = "SettingPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            this.Shown += new System.EventHandler(this.SettingShown);
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.DataGridView toolGridView;
        private System.Windows.Forms.ComboBox machineList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewTool;
    }
}