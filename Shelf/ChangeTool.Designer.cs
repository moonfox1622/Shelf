namespace Shelf
{
    partial class ChangeTool
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
            this.txtLife = new System.Windows.Forms.NumericUpDown();
            this.txtRemain = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnComfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLife
            // 
            this.txtLife.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLife.Location = new System.Drawing.Point(48, 125);
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(120, 29);
            this.txtLife.TabIndex = 12;
            // 
            // txtRemain
            // 
            this.txtRemain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txtRemain.Location = new System.Drawing.Point(48, 200);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(120, 29);
            this.txtRemain.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(25, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "剩餘使用次數：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "可使用次數：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "名稱：";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtName.Location = new System.Drawing.Point(44, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(65, 24);
            this.txtName.TabIndex = 14;
            this.txtName.Text = "label4";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(143, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // btnComfirm
            // 
            this.btnComfirm.Location = new System.Drawing.Point(62, 258);
            this.btnComfirm.Name = "btnComfirm";
            this.btnComfirm.Size = new System.Drawing.Size(75, 23);
            this.btnComfirm.TabIndex = 15;
            this.btnComfirm.Text = "確認";
            this.btnComfirm.UseVisualStyleBackColor = true;
            this.btnComfirm.Click += new System.EventHandler(this.Comfirm);
            // 
            // ChangeTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 293);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnComfirm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtLife);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangeTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更換刀具";
            this.Shown += new System.EventHandler(this.ChangeToolShown);
            ((System.ComponentModel.ISupportInitialize)(this.txtLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtLife;
        private System.Windows.Forms.NumericUpDown txtRemain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnComfirm;
    }
}