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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolGridView = new System.Windows.Forms.DataGridView();
            this.machineList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewTool = new System.Windows.Forms.Button();
            this.txtMachDescrible = new System.Windows.Forms.Label();
            this.picMachine = new System.Windows.Forms.PictureBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).BeginInit();
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.toolGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.toolGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.toolGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.toolGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.toolGridView.Location = new System.Drawing.Point(444, 99);
            this.toolGridView.Margin = new System.Windows.Forms.Padding(6);
            this.toolGridView.MultiSelect = false;
            this.toolGridView.Name = "toolGridView";
            this.toolGridView.ReadOnly = true;
            this.toolGridView.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.toolGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.Height = 35;
            this.toolGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolGridView.Size = new System.Drawing.Size(805, 567);
            this.toolGridView.TabIndex = 3;
            this.toolGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CellMouseClick);
            // 
            // machineList
            // 
            this.machineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineList.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.machineList.FormattingEnabled = true;
            this.machineList.Location = new System.Drawing.Point(135, 29);
            this.machineList.Name = "machineList";
            this.machineList.Size = new System.Drawing.Size(121, 34);
            this.machineList.TabIndex = 5;
            this.machineList.SelectedIndexChanged += new System.EventHandler(this.MachineChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "機台選擇：";
            // 
            // btnNewTool
            // 
            this.btnNewTool.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNewTool.Location = new System.Drawing.Point(444, 54);
            this.btnNewTool.Name = "btnNewTool";
            this.btnNewTool.Size = new System.Drawing.Size(96, 36);
            this.btnNewTool.TabIndex = 7;
            this.btnNewTool.Text = "新增刀具";
            this.btnNewTool.UseVisualStyleBackColor = true;
            this.btnNewTool.Click += new System.EventHandler(this.BtnNewToolClick);
            // 
            // txtMachDescrible
            // 
            this.txtMachDescrible.Font = new System.Drawing.Font("微軟正黑體", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMachDescrible.Location = new System.Drawing.Point(33, 495);
            this.txtMachDescrible.Name = "txtMachDescrible";
            this.txtMachDescrible.Size = new System.Drawing.Size(380, 146);
            this.txtMachDescrible.TabIndex = 9;
            this.txtMachDescrible.Text = "label2";
            this.txtMachDescrible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMachine
            // 
            this.picMachine.Image = global::Shelf.Properties.Resources.CNC2;
            this.picMachine.Location = new System.Drawing.Point(27, 171);
            this.picMachine.Name = "picMachine";
            this.picMachine.Size = new System.Drawing.Size(397, 297);
            this.picMachine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMachine.TabIndex = 8;
            this.picMachine.TabStop = false;
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
            // SettingPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.txtMachDescrible);
            this.Controls.Add(this.picMachine);
            this.Controls.Add(this.btnNewTool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machineList);
            this.Controls.Add(this.picNew);
            this.Controls.Add(this.toolGridView);
            this.Name = "SettingPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刀具設定";
            this.Shown += new System.EventHandler(this.SettingShown);
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).EndInit();
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
        private System.Windows.Forms.PictureBox picMachine;
        private System.Windows.Forms.Label txtMachDescrible;
    }
}