using System;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class EditForm : Form
    {
        public string name { get; set; }
        public int machineId { get; set; }

        Tool tool = new Tool();
        ToolDatabase tdb = new ToolDatabase();

        public EditForm()
        {
            InitializeComponent();
        }

        private void EditFormShown(object sender, EventArgs e)
        {
            tdb.GetToolByName(this.name, this.machineId, ref tool);
            txtName.Text = tool.name;
            txtLife.Value = tool.life;
            txtRemain.Value = tool.remain;
            txtAlarm.Value = tool.warning;
        }

        /// <summary>
        /// 進行修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名稱不可為空白", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLife.Value < txtRemain.Value)
            {
                MessageBox.Show("壽命不可小於剩餘壽命", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tdb.CheckRepeatName(tool.id, txtName.Text, machineId))
            {
                MessageBox.Show("名稱重複", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("確定要修改嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            tool = new Tool
            {
                id = tool.id,
                machineId = machineId,
                name = txtName.Text,
                life = Convert.ToInt32(txtLife.Value),
                remain = Convert.ToInt32(txtRemain.Value),
                warning = Convert.ToInt32(txtAlarm.Value)
            };

            if (tdb.EditTool(tool))
            {
                Log log = new Log
                {
                    machineId = machineId,
                    name = tool.name,
                    life = tool.life,
                    remain = tool.remain,
                    warning = tool.warning,
                    dateTime = DateTime.Now,
                    mark = "修改"
                };
                tdb.InsertSystemLog(log);
                this.Close();
                MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}