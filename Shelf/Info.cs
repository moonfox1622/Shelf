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
    public partial class Info : UserControl
    {
        public string name { get; set; }
        Tool tool = new Tool();
        ToolDatabase tdb = new ToolDatabase();
        public Info()
        {
            InitializeComponent();
        }

        private void InfoLoad(object sender, EventArgs e)
        {
            tdb.GetToolByName(name, ref tool);
            txtName.Text = tool.name;
            txtLife.Text = tool.life.ToString();
            txtRemain.Text = tool.remain.ToString();

            if (tool.alarm)
            {
                txtStatus.Text = "警告";
            }
            else
            {
                txtStatus.Text = "正常";
            }
        }
    }
}
