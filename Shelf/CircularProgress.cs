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
    public partial class CircularProgress : UserControl
    {
        public Tool tool { get; set; }
        public CircularProgress()
        {
            InitializeComponent();
        }

        private void CircularProgress_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            percentBar.Text = tool.Remain.ToString();
            txtName.Text = tool.Name;
            double percent = ((double)tool.Remain / (double)tool.Life) * 100;
            txtPercent.Text = ((int)percent).ToString();
            percentBar.Value = (int)percent;
        }

        private void ProgressDecrease()
        {
            int remain = percentBar.Value - 1;
            if (remain < 0)
                remain = 100;
            percentBar.Value = remain;
            percentBar.Text = remain.ToString();
            if (percentBar.Value >= 80)
            {
                percentBar.ProgressColor = Color.FromArgb(89, 201, 165);
            }
            else if (percentBar.Value < 80 && percentBar.Value >= 50)
            {
                percentBar.ProgressColor = Color.FromArgb(242, 236, 0);
            }
            else
            {
                percentBar.ProgressColor = Color.FromArgb(216, 30, 91);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
