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
    public partial class ChangeUserControl : UserControl
    {
        public string name { get; set; }
        Tool tool = new Tool();
        ToolDatabase tdb = new ToolDatabase();

        public ChangeUserControl()
        {
            InitializeComponent();
        }

        private void ChangeLoad(object sender, EventArgs e)
        {
            tdb.GetToolByName(name, ref tool);
            txtName.Text = tool.name;
            txtLife.Value = tool.life;
            
        }

        private void BtnChangeClick(object sender, EventArgs e)
        {

            if (MessageBox.Show("確定要執行更換嗎", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            tool.life = Convert.ToInt32(txtLife.Value);
            if (tdb.ChangeTool(tool))
            {
                //db.HistoryInsert(tool, '3');
                MessageBox.Show("更換成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
