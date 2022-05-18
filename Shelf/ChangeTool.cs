using System;
using System.Windows.Forms;

namespace Shelf
{
    public partial class ChangeTool : Form
    {

        public Tool tool { get; set; }
        public bool hasChange = false;
        public ChangeTool()
        {
            InitializeComponent();
        }

        private void ChangeToolShown(object sender, EventArgs e)
        {
            txtName.Text = tool.name;
            txtLife.Value = tool.life;
            txtRemain.Value = tool.remain;
        }

        private void Comfirm(object sender, EventArgs e)
        {
            if (txtLife.Value < txtRemain.Value)
            {
                MessageBox.Show("可使用次數不能小於剩餘使用次數");
                return;
            }
            ToolDatabase tb = new ToolDatabase();
            
            if (MessageBox.Show("確定要修改嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            tool = new Tool
            {
                id = tool.id,
                name = txtName.Text,
                life = Convert.ToInt32(txtLife.Value),
                remain = Convert.ToInt32(txtRemain.Value),
                alarm = false
            };
            if (tb.ChangeTool(tool))
            {
                hasChange = true;
                tb.InsertHistory(tool, '3');
                this.Close();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
