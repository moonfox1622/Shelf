using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class Change : UserControl
    {
        public int id { get; set; }

        Tool tool = new Tool();
        ToolDatabase tdb = new ToolDatabase();

        public Change()
        {
            InitializeComponent();
        }

        private void ChangeLoad(object sender, EventArgs e)
        {
            tdb.GetToolById(id, ref tool);
            txtName.Text = tool.name;
            txtLife.Value = tool.life;
            txtRemain.Value = tool.remain;
        }

        private void BtnChangeClick(object sender, EventArgs e)
        {
            if(txtLife.Value < txtRemain.Value)
            {
                MessageBox.Show("壽命不可小於剩餘壽命", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("確定要執行更換嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (tdb.ChangeTool(tool))
            {
                tdb.HistoryInsert(tool, '3');
                MessageBox.Show("更換成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
