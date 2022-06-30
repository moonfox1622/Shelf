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
            txtName.Text = tool.Name;
            txtLife.Value = tool.Life;
            txtRemain.Value = tool.Remain;
            txtAlarm.Value = tool.Warning;
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

            if (tdb.CheckRepeatName(tool.Id, txtName.Text, machineId))
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
                Id = tool.Id,
                MachineId = machineId,
                Name = txtName.Text,
                Life = Convert.ToInt32(txtLife.Value),
                Remain = Convert.ToInt32(txtRemain.Value),
                Warning = Convert.ToInt32(txtAlarm.Value)
            };
            
            if (tdb.EditTool(tool))
            {
                Log log = new Log
                {
                    MachineId = machineId,
                    Name = tool.Name,
                    Life = tool.Life,
                    Remain = tool.Remain,
                    Warning = tool.Warning,
                    CreateTime = DateTime.Now,
                    Mark = "修改"
                };
                tdb.InsertSystemLog(log);
                this.Close();
                MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}