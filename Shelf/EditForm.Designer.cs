namespace Shelf
{
    partial class EditForm
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
            this.txtAlarm = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtRemain = new System.Windows.Forms.NumericUpDown();
            this.txtLife = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLife)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAlarm
            // 
            this.txtAlarm.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtAlarm.Location = new System.Drawing.Point(68, 279);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.Size = new System.Drawing.Size(100, 33);
            this.txtAlarm.TabIndex = 31;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtName.Location = new System.Drawing.Point(64, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(66, 24);
            this.txtName.TabIndex = 30;
            this.txtName.Text = "Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEdit.Location = new System.Drawing.Point(169, 319);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 30);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnChangeClick);
            // 
            // txtRemain
            // 
            this.txtRemain.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtRemain.Location = new System.Drawing.Point(68, 200);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(100, 33);
            this.txtRemain.TabIndex = 28;
            // 
            // txtLife
            // 
            this.txtLife.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtLife.Location = new System.Drawing.Point(68, 125);
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(100, 33);
            this.txtLife.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(11, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "警戒值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(11, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "剩餘磨耗值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(11, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "最大磨耗值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "刀具名稱：";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 358);
            this.Controls.Add(this.txtAlarm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.txtLife);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(266, 397);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(266, 397);
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改";
            this.Shown += new System.EventHandler(this.EditFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.txtAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLife)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtAlarm;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.NumericUpDown txtRemain;
        private System.Windows.Forms.NumericUpDown txtLife;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}