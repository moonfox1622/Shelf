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
    public partial class NewData : UserControl
    {
        public string name { get; set; }
        public int life { get; set; }
        public NewData()
        {
            InitializeComponent();
            life = 0;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            name = textBoxName.Text;
        }

        private void textBoxLife_ValueChanged(object sender, EventArgs e)
        {
            life = Convert.ToInt32(textBoxLife.Value);
        }
    }
}
