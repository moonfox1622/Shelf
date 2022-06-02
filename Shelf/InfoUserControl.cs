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
    public partial class InfoUserControl : UserControl
    {
        public string name { get; set; }
        Tool tool = new Tool();
        ToolDatabase tdb = new ToolDatabase();
        public InfoUserControl()
        {
            InitializeComponent();
        }

        private void InfoLoad(object sender, EventArgs e)
        {
            tdb.GetToolByName(name, ref tool);
            txtName.Text = tool.name;
            txtLife.Text = tool.life.ToString();
            txtRemain.Text = tool.remain.ToString();
            txtAlarm.Text = tool.warning.ToString();
        }
    }
}
