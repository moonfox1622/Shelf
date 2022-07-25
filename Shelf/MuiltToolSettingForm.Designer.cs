namespace Shelf
{
    partial class MuiltToolSettingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.machineList = new System.Windows.Forms.ComboBox();
            this.toolGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectToolListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.deleListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChangeTool = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.picMachine = new System.Windows.Forms.PictureBox();
            this.txtMachDescrible = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "機台選擇：";
            // 
            // machineList
            // 
            this.machineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineList.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.machineList.FormattingEnabled = true;
            this.machineList.Location = new System.Drawing.Point(135, 22);
            this.machineList.Name = "machineList";
            this.machineList.Size = new System.Drawing.Size(121, 34);
            this.machineList.TabIndex = 7;
            this.machineList.SelectedIndexChanged += new System.EventHandler(this.MachineChange);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.toolGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.toolGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.toolGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.toolGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.toolGridView.Location = new System.Drawing.Point(367, 57);
            this.toolGridView.Margin = new System.Windows.Forms.Padding(6);
            this.toolGridView.MultiSelect = false;
            this.toolGridView.Name = "toolGridView";
            this.toolGridView.ReadOnly = true;
            this.toolGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.toolGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.Height = 35;
            this.toolGridView.Size = new System.Drawing.Size(617, 589);
            this.toolGridView.TabIndex = 9;
            this.toolGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClick);
            this.toolGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.ToolGridViewCellPainting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(362, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "勾選刀具";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(1013, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 26);
            this.label3.TabIndex = 12;
            this.label3.Text = "已選擇刀具";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.selectToolListPanel);
            this.panel1.Controls.Add(this.deleListPanel);
            this.panel1.Location = new System.Drawing.Point(1018, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 505);
            this.panel1.TabIndex = 13;
            // 
            // selectToolListPanel
            // 
            this.selectToolListPanel.Location = new System.Drawing.Point(42, 3);
            this.selectToolListPanel.Name = "selectToolListPanel";
            this.selectToolListPanel.Size = new System.Drawing.Size(173, 0);
            this.selectToolListPanel.TabIndex = 1;
            // 
            // deleListPanel
            // 
            this.deleListPanel.Location = new System.Drawing.Point(3, 3);
            this.deleListPanel.Name = "deleListPanel";
            this.deleListPanel.Size = new System.Drawing.Size(33, 0);
            this.deleListPanel.TabIndex = 0;
            // 
            // btnChangeTool
            // 
            this.btnChangeTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeTool.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnChangeTool.Location = new System.Drawing.Point(1126, 572);
            this.btnChangeTool.Name = "btnChangeTool";
            this.btnChangeTool.Size = new System.Drawing.Size(108, 41);
            this.btnChangeTool.TabIndex = 15;
            this.btnChangeTool.Text = "更換刀具";
            this.btnChangeTool.UseVisualStyleBackColor = true;
            this.btnChangeTool.Click += new System.EventHandler(this.BtnChangeToolClick);
            // 
            // btnClearList
            // 
            this.btnClearList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearList.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClearList.Location = new System.Drawing.Point(1150, 25);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(84, 30);
            this.btnClearList.TabIndex = 25;
            this.btnClearList.Tag = "select";
            this.btnClearList.Text = "清除列表";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.BtnClearListClick);
            // 
            // picMachine
            // 
            this.picMachine.Image = global::Shelf.Properties.Resources.CNC2;
            this.picMachine.Location = new System.Drawing.Point(12, 171);
            this.picMachine.Name = "picMachine";
            this.picMachine.Size = new System.Drawing.Size(346, 265);
            this.picMachine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMachine.TabIndex = 26;
            this.picMachine.TabStop = false;
            // 
            // txtMachDescrible
            // 
            this.txtMachDescrible.Font = new System.Drawing.Font("微軟正黑體", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMachDescrible.Location = new System.Drawing.Point(12, 467);
            this.txtMachDescrible.Name = "txtMachDescrible";
            this.txtMachDescrible.Size = new System.Drawing.Size(346, 146);
            this.txtMachDescrible.TabIndex = 27;
            this.txtMachDescrible.Text = "label2";
            this.txtMachDescrible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetting
            // 
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnSetting.Location = new System.Drawing.Point(1018, 619);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(108, 41);
            this.btnSetting.TabIndex = 28;
            this.btnSetting.Text = "刀具設定";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.BtnSettingClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(30)))), ((int)(((byte)(91)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1128, 619);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 41);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "刪除刀具";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(1018, 572);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(108, 41);
            this.btnNew.TabIndex = 30;
            this.btnNew.Text = "新增刀具";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            // 
            // txtTip
            // 
            this.txtTip.AutoSize = true;
            this.txtTip.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTip.Location = new System.Drawing.Point(363, 653);
            this.txtTip.Name = "txtTip";
            this.txtTip.Size = new System.Drawing.Size(337, 19);
            this.txtTip.TabIndex = 31;
            this.txtTip.Text = "※需要更改刀具名稱時請先刪除該道具再新增刀具";
            // 
            // MuiltToolSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.txtMachDescrible);
            this.Controls.Add(this.picMachine);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnChangeTool);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machineList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MuiltToolSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同時設定";
            this.Shown += new System.EventHandler(this.MuiltToolSettingFormShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MuiltToolSettingForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox machineList;
        private System.Windows.Forms.DataGridView toolGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel selectToolListPanel;
        private System.Windows.Forms.FlowLayoutPanel deleListPanel;
        private System.Windows.Forms.Button btnChangeTool;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.PictureBox picMachine;
        private System.Windows.Forms.Label txtMachDescrible;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label txtTip;
    }
}