namespace Shelf
{
    partial class EditMulitToolsForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLife = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSend.Location = new System.Drawing.Point(94, 241);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 30);
            this.btnSend.TabIndex = 37;
            this.btnSend.Text = "送出";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(21, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 24);
            this.label7.TabIndex = 43;
            this.label7.Text = "警戒值";
            // 
            // txtWarning
            // 
            this.txtWarning.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtWarning.Location = new System.Drawing.Point(56, 189);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.Size = new System.Drawing.Size(128, 32);
            this.txtWarning.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 24);
            this.label6.TabIndex = 41;
            this.label6.Text = "剩餘磨耗值";
            // 
            // txtRemain
            // 
            this.txtRemain.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtRemain.Location = new System.Drawing.Point(56, 111);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(128, 32);
            this.txtRemain.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "最大磨耗值";
            // 
            // txtLife
            // 
            this.txtLife.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txtLife.Location = new System.Drawing.Point(56, 36);
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(128, 32);
            this.txtLife.TabIndex = 38;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(169, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 30);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // EditMulitToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 283);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWarning);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLife);
            this.Controls.Add(this.btnSend);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMulitToolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定數值";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWarning;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLife;
        private System.Windows.Forms.Button btnCancel;
    }
}