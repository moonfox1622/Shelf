using System;
using System.Windows.Forms;

namespace Shelf
{
    public partial class EditTool : Form
    {

        public Tool tool { get; set; }
        public bool hasUpdate = false;
        public EditTool()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 讀取欲修改刀具資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_Load(object sender, EventArgs e)
        {
            txtAlarm.Items.Add("正常");
            txtAlarm.Items.Add("警報");

            txtName.Text = tool.name;
            txtLife.Value = tool.life;
            txtRemain.Value = tool.remain;
            if (tool.alarm)
            {
                txtAlarm.SelectedIndex = 1;
            }
            else
            {
                txtAlarm.SelectedIndex = 0;
            }
        }


        private void Comfirm(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名稱不可以為空");
                return;
            }
            if (txtLife.Value < txtRemain.Value)
            {
                MessageBox.Show("可使用次數不能小於剩餘使用次數");
                return;
            }
            ToolDatabase tb = new ToolDatabase();
            string originName = tool.name;

            if (tb.checkExist(txtName.Text) && originName != txtName.Text)
            {
                MessageBox.Show("名稱重複，請重新命名");
                return;
            }

            if (MessageBox.Show("確定要修改嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tool = new Tool
                {
                    name = txtName.Text,
                    life = Convert.ToInt32(txtLife.Value),
                    remain = Convert.ToInt32(txtRemain.Value),
                    alarm = Convert.ToBoolean(txtAlarm.SelectedIndex)
                };
                tb.UpdateTool(originName, tool);
                hasUpdate = true;
                this.Close();
            }
            
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
