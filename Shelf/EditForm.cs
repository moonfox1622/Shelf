using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            if (tdb.CheckRepeatName(tool.id, txtName.Text))
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
                name = txtName.Text,
                life = Convert.ToInt32(txtLife.Value),
                remain = Convert.ToInt32(txtRemain.Value),
                warning = Convert.ToInt32(txtAlarm.Value)
            };

            if (tdb.EditTool(tool))
            {
                //tdb.HistoryInsert(tool, '5');
                MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
