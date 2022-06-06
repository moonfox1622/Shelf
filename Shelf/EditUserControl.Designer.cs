namespace Shelf
{
    partial class EditUserControl
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLife = new System.Windows.Forms.NumericUpDown();
            this.txtRemain = new System.Windows.Forms.NumericUpDown();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.Label();
            this.txtAlarm = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(14, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "警戒值：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(14, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "剩餘壽命：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(14, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "壽命：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "名稱：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLife
            // 
            this.txtLife.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtLife.Location = new System.Drawing.Point(71, 125);
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(100, 33);
            this.txtLife.TabIndex = 17;
            this.txtLife.ValueChanged += new System.EventHandler(this.txtLife_ValueChanged);
            // 
            // txtRemain
            // 
            this.txtRemain.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtRemain.Location = new System.Drawing.Point(71, 200);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(100, 33);
            this.txtRemain.TabIndex = 18;
            this.txtRemain.ValueChanged += new System.EventHandler(this.txtRemain_ValueChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEdit.Location = new System.Drawing.Point(172, 319);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 30);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnChangeClick);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtName.Location = new System.Drawing.Point(67, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(66, 24);
            this.txtName.TabIndex = 21;
            this.txtName.Text = "Name";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // txtAlarm
            // 
            this.txtAlarm.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtAlarm.Location = new System.Drawing.Point(71, 279);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.Size = new System.Drawing.Size(100, 33);
            this.txtAlarm.TabIndex = 22;
            this.txtAlarm.ValueChanged += new System.EventHandler(this.txtAlarm_ValueChanged);
            // 
            // EditUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAlarm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.txtLife);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditUserControl";
            this.Size = new System.Drawing.Size(265, 361);
            this.Load += new System.EventHandler(this.EditLoad);
            ((System.ComponentModel.ISupportInitialize)(this.txtLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtLife;
        private System.Windows.Forms.NumericUpDown txtRemain;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.NumericUpDown txtAlarm;
    }
}
