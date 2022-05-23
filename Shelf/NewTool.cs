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
    public partial class NewTool : Form
    {
        public bool hasNew = false;
        public Tool tool { get; set; }

        public NewTool()
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
            if (txtLife.Value < txtRemain.Value)
            {
                MessageBox.Show("可使用次數不能小於剩餘使用次數");
                return;
            }
            ToolDatabase tdb = new ToolDatabase();

            if (tdb.checkExist(txtName.Text))
            {
                MessageBox.Show("名稱重複，請重新命名");
                return;
            }

            if (MessageBox.Show("確定要新增嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                tool = new Tool
                {
                    name = txtName.Text,
                    life = Convert.ToInt32(txtLife.Value),
                    remain = Convert.ToInt32(txtRemain.Value),
                    alarm = Convert.ToBoolean(txtAlarm.SelectedIndex)
                };
                tdb.InsertTool(tool);
                tdb.HistoryInsert(tool, '4');
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

        private void NewTool_Load(object sender, EventArgs e)
        {
            txtAlarm.Items.Add("正常");
            txtAlarm.Items.Add("警報");
            txtAlarm.SelectedIndex = 0;
        }
    }
}
