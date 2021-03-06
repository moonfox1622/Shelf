using System;
using System.Windows.Forms;

namespace Shelf
{
    public partial class NewToolForm : Form
    {
        public bool hasNew = false;
        public Tool tool { get; set; }
        public int machineId { get; set; }


        public NewToolForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 確認新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Comfirm(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名稱不可以為空");
                return;
            }
            ToolDatabase tdb = new ToolDatabase();

            if (tdb.checkRepeat(txtName.Text, machineId))
            {
                MessageBox.Show("名稱重複，請重新命名");
                return;
            }
            if(txtLife.Value <= 0)
            {
                MessageBox.Show("最大磨耗值不可為0");
                return;
            }

            if (MessageBox.Show("確定要新增嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                tool = new Tool
                {
                    Name = txtName.Text,
                    Life = Convert.ToInt32(txtLife.Value),
                    Remain = Convert.ToInt32(txtLife.Value),
                    Warning = Convert.ToInt32(txtWarning.Value)
                };
                if (!tdb.InsertTool(tool, machineId))
                    return;
                //tdb.HistoryInsert(tool, '4');
                hasNew = true;

                this.Close();
            }
            
        }

        /// <summary>
        /// 取消新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
