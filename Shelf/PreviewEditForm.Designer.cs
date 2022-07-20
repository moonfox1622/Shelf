namespace Shelf
{
    partial class PreviewEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolGridView = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.life = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnComfirm = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.txtMachine = new System.Windows.Forms.Label();
            this.txtRemind = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).BeginInit();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.toolGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.toolGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toolGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete,
            this.name,
            this.life,
            this.remain,
            this.warning});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.toolGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.toolGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.toolGridView.Location = new System.Drawing.Point(15, 55);
            this.toolGridView.Margin = new System.Windows.Forms.Padding(6);
            this.toolGridView.MultiSelect = false;
            this.toolGridView.Name = "toolGridView";
            this.toolGridView.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.toolGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.toolGridView.RowTemplate.Height = 35;
            this.toolGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolGridView.Size = new System.Drawing.Size(859, 407);
            this.toolGridView.TabIndex = 10;
            this.toolGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ToolGridViewCellClick);
            this.toolGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ToolGridViewCellEndEdit);
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            this.delete.DefaultCellStyle = dataGridViewCellStyle6;
            this.delete.FillWeight = 126.9036F;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delete.HeaderText = "";
            this.delete.Name = "delete";
            this.delete.Text = "X";
            this.delete.Visible = false;
            this.delete.Width = 50;
            // 
            // name
            // 
            this.name.FillWeight = 93.27411F;
            this.name.HeaderText = "名稱";
            this.name.Name = "name";
            // 
            // life
            // 
            this.life.FillWeight = 93.27411F;
            this.life.HeaderText = "最大磨耗值";
            this.life.Name = "life";
            // 
            // remain
            // 
            this.remain.FillWeight = 93.27411F;
            this.remain.HeaderText = "剩餘磨耗值";
            this.remain.Name = "remain";
            // 
            // warning
            // 
            this.warning.FillWeight = 93.27411F;
            this.warning.HeaderText = "警告值";
            this.warning.Name = "warning";
            // 
            // btnComfirm
            // 
            this.btnComfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComfirm.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnComfirm.Location = new System.Drawing.Point(684, 471);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(94, 31);
            this.btnComfirm.TabIndex = 15;
            this.btnComfirm.Text = "送出";
            this.btnComfirm.UseVisualStyleBackColor = true;
            this.btnComfirm.Click += new System.EventHandler(this.BtnComfirmClick);
            // 
            // btnCancle
            // 
            this.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancle.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancle.Location = new System.Drawing.Point(784, 471);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(94, 31);
            this.btnCancle.TabIndex = 16;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.BtnCancleClick);
            // 
            // txtMachine
            // 
            this.txtMachine.AutoSize = true;
            this.txtMachine.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMachine.Location = new System.Drawing.Point(12, 14);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(87, 35);
            this.txtMachine.TabIndex = 17;
            this.txtMachine.Text = "CNCx";
            // 
            // txtRemind
            // 
            this.txtRemind.AutoSize = true;
            this.txtRemind.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRemind.Location = new System.Drawing.Point(14, 487);
            this.txtRemind.Name = "txtRemind";
            this.txtRemind.Size = new System.Drawing.Size(292, 19);
            this.txtRemind.TabIndex = 18;
            this.txtRemind.Text = "※剩餘磨耗值及警告值不可小於最大磨耗值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(14, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "※點選資料欄以修改資料";
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(105, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 31);
            this.btnNew.TabIndex = 21;
            this.btnNew.Text = "新增欄位";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
            // 
            // PreviewEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 514);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemind);
            this.Controls.Add(this.txtMachine);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnComfirm);
            this.Controls.Add(this.toolGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "結果預覽";
            this.Shown += new System.EventHandler(this.EditMuiltToolsFormShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PreviewEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.toolGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView toolGridView;
        private System.Windows.Forms.Button btnComfirm;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label txtMachine;
        private System.Windows.Forms.Label txtRemind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn life;
        private System.Windows.Forms.DataGridViewTextBoxColumn remain;
        private System.Windows.Forms.DataGridViewTextBoxColumn warning;
    }
}