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
    public partial class Grid : UserControl
    {
        public string name { get; set; }
        public int count { get; set; }
        public bool alarm { get; set; }
        public int check { get; set; }

        public Grid()
        {
            InitializeComponent();
        }

        private void Grid_Load(object sender, EventArgs e)
        {
            CheckStatus();
        }
        public void CheckStatus()
        {
            txtName.Text = name;
            txtCount.Text = count.ToString();
            //count>80:green, 80>count>=50:yellow, count<50:red
            if (count >= 80)
            {
                this.BackColor = Color.FromArgb(89, 201, 165);
            }else if(count < 80 && count >= 50)
            {
                this.BackColor = Color.FromArgb(255, 253, 152);
            }
            else
            {
                this.BackColor = Color.FromArgb(216, 30, 91);
            }

            //alarm == true show picAlarm
            if (count <= check)
            {
                picAlarm.Visible = true;
            }
            else
            {
                picAlarm.Visible = false;
            }
        }


    }
}
