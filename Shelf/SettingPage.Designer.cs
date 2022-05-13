namespace Shelf
{
    partial class SettingPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Life = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alarm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.change = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableView
            // 
            this.tableView.AllowUserToAddRows = false;
            this.tableView.AllowUserToDeleteRows = false;
            this.tableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Life,
            this.remain,
            this.alarm,
            this.change,
            this.edit,
            this.delete});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableView.DefaultCellStyle = dataGridViewCellStyle9;
            this.tableView.Location = new System.Drawing.Point(68, 61);
            this.tableView.MultiSelect = false;
            this.tableView.Name = "tableView";
            this.tableView.ReadOnly = true;
            this.tableView.RowTemplate.Height = 24;
            this.tableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableView.Size = new System.Drawing.Size(1239, 586);
            this.tableView.TabIndex = 0;
            // 
            // name
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.HeaderText = "名稱";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Life
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Life.DefaultCellStyle = dataGridViewCellStyle3;
            this.Life.HeaderText = "可使用次數";
            this.Life.Name = "Life";
            this.Life.ReadOnly = true;
            // 
            // remain
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remain.DefaultCellStyle = dataGridViewCellStyle4;
            this.remain.HeaderText = "剩餘使用次數";
            this.remain.Name = "remain";
            this.remain.ReadOnly = true;
            // 
            // alarm
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarm.DefaultCellStyle = dataGridViewCellStyle5;
            this.alarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alarm.HeaderText = "警告狀態";
            this.alarm.Name = "alarm";
            this.alarm.ReadOnly = true;
            // 
            // change
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change.DefaultCellStyle = dataGridViewCellStyle6;
            this.change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.change.HeaderText = "換刀";
            this.change.Name = "change";
            this.change.ReadOnly = true;
            this.change.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.change.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.change.Text = "換刀";
            this.change.UseColumnTextForButtonValue = true;
            // 
            // edit
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit.DefaultCellStyle = dataGridViewCellStyle7;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.HeaderText = "修改";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "修改";
            this.edit.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.DefaultCellStyle = dataGridViewCellStyle8;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.HeaderText = "刪除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "刪除";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // SettingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.tableView);
            this.Name = "SettingPage";
            this.Size = new System.Drawing.Size(1777, 1032);
            this.Load += new System.EventHandler(this.SettingPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tableView;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Life;
        private System.Windows.Forms.DataGridViewTextBoxColumn remain;
        private System.Windows.Forms.DataGridViewButtonColumn alarm;
        private System.Windows.Forms.DataGridViewButtonColumn change;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}
