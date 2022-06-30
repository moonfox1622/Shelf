namespace Shelf
{
    partial class HistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableView = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorSelect = new System.Windows.Forms.CheckBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.machineList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableView
            // 
            this.tableView.AllowUserToAddRows = false;
            this.tableView.AllowUserToDeleteRows = false;
            this.tableView.AllowUserToResizeColumns = false;
            this.tableView.AllowUserToResizeRows = false;
            this.tableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tableView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableView.DefaultCellStyle = dataGridViewCellStyle14;
            this.tableView.Location = new System.Drawing.Point(12, 93);
            this.tableView.MultiSelect = false;
            this.tableView.Name = "tableView";
            this.tableView.ReadOnly = true;
            this.tableView.RowHeadersVisible = false;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tableView.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.tableView.RowTemplate.Height = 35;
            this.tableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableView.Size = new System.Drawing.Size(1240, 554);
            this.tableView.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(1063, 57);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(189, 29);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "名稱/使用磨耗/紀錄時間";
            this.searchBox.TextChanged += new System.EventHandler(this.QuickSearch);
            this.searchBox.Enter += new System.EventHandler(this.Textbox_Enter);
            this.searchBox.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.CalendarFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.startDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.startDateTimePicker.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTimePicker.Location = new System.Drawing.Point(108, 34);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(155, 23);
            this.startDateTimePicker.TabIndex = 2;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.CalendarFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.endDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.endDateTimePicker.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateTimePicker.Location = new System.Drawing.Point(108, 61);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(155, 23);
            this.endDateTimePicker.TabIndex = 3;
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelStartTime.Location = new System.Drawing.Point(12, 35);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(90, 21);
            this.labelStartTime.TabIndex = 4;
            this.labelStartTime.Text = "開始時間：";
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelEndTime.Location = new System.Drawing.Point(12, 61);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(90, 21);
            this.labelEndTime.TabIndex = 5;
            this.labelEndTime.Text = "結束時間：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(999, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "搜尋：";
            // 
            // errorSelect
            // 
            this.errorSelect.AutoSize = true;
            this.errorSelect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.errorSelect.Location = new System.Drawing.Point(269, 60);
            this.errorSelect.Name = "errorSelect";
            this.errorSelect.Size = new System.Drawing.Size(93, 25);
            this.errorSelect.TabIndex = 8;
            this.errorSelect.Text = "異常紀錄";
            this.errorSelect.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDownload.Location = new System.Drawing.Point(486, 26);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(110, 46);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "歷史下載";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Visible = false;
            this.btnDownload.Click += new System.EventHandler(this.BtnDownloadClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(30)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(1171, 652);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 25);
            this.label2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(1202, 656);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "異常";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch.Location = new System.Drawing.Point(370, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 46);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "條件搜尋";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "機台選擇：";
            // 
            // machineList
            // 
            this.machineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineList.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.machineList.FormattingEnabled = true;
            this.machineList.Location = new System.Drawing.Point(108, 6);
            this.machineList.Name = "machineList";
            this.machineList.Size = new System.Drawing.Size(132, 24);
            this.machineList.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(1087, 656);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "執行換刀";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(202)))), ((int)(((byte)(41)))));
            this.label6.Location = new System.Drawing.Point(1056, 652);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 25);
            this.label6.TabIndex = 17;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machineList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.errorSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelEndTime);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.tableView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "歷史紀錄";
            this.Shown += new System.EventHandler(this.HistoryShown);
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableView;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox errorSelect;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.SaveFileDialog fileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox machineList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}