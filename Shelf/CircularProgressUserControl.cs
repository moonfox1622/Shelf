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
    public partial class CircularProgressUserControl : UserControl
    {
        public Tool tool { get; set; }
        public CircularProgressUserControl()
        {
            InitializeComponent();
        }

        private void CircularProgress_Load(object sender, EventArgs e)
        {
            CheckStatus();
        }

        public void CheckStatus()
        {
            this.DoubleBuffered = true;
            percentBar.Text = tool.Remain.ToString();
            txtName.Text = tool.Name;
            txtLife.Text = tool.Remain.ToString();
            double percent = ((double)tool.Remain / (double)tool.Life) * 100;
            percentBar.Text = ((int)percent).ToString() + "%";
            percentBar.Value = 100 - (int)percent;
            txtWarning.Text = "警戒值:" + tool.Warning.ToString();
            ProgressDecrease((int)percent, tool.Warning);
            ToolUse();
        }

        private void ProgressDecrease(int remain, int warning)
        {
            if (remain < 0)
                remain = 0;
            Color bc = Color.FromArgb(241, 241, 241);
            Color fc = Color.Black;
            //percentBar.Text = remain.ToString();

            if (remain >= 80)
            {
                percentBar.OuterColor = Color.FromArgb(89, 201, 165);
            }
            else if (remain < 80 && remain > warning)
            {
                percentBar.OuterColor = Color.FromArgb(242, 236, 0);
            }
            else
            {
               bc = Color.FromArgb(216, 30, 91);
               fc = Color.White;
               percentBar.OuterColor = bc;
            }
            
            txtLife.BackColor = bc;
            txtLife.ForeColor = fc;
            txtUnit.BackColor = bc;
            txtUnit.ForeColor = fc;
            panelValue.BackColor = bc;
        }

        public void ToolUse()
        {
            this.Invalidate();
        }

        private void UsePaint(object sender, PaintEventArgs e)
        {
            Color backC = Color.FromArgb(241, 241, 241);
            if (tool.Taken)
            {
                ButtonBorderStyle style = ButtonBorderStyle.Solid;
                Color color = Color.FromArgb(13, 131, 0);
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, color, 6, style, color, 6, style, color, 6, style, color, 6, style);
                backC = Color.FromArgb(62, 167, 179);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.None);
            }

        }

        private void ResizeUI()
        {
            int w = this.Width; //306
            int h = this.Height; //181

            if (w >= 2000)
            {
                percentBar.Size = new Size(100, 100);
                percentBar.Font = new Font("Arial", 24, FontStyle.Bold);
                txtLife.Font = new Font("Arial", 15, FontStyle.Bold);
                txtWarning.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            else if(w <= 100)
            {
                percentBar.Size = new Size(100, 100);
                percentBar.Font = new Font("Arial", 24, FontStyle.Bold);
                txtLife.Font = new Font("Arial", 20, FontStyle.Bold);
                txtWarning.Font = new Font("Arial", 12, FontStyle.Bold);
            }
        }

        private void CircularProgressUserControl_Resize(object sender, EventArgs e)
        {
            int w = this.Width; //306
            int h = this.Height; //181

            if (w > 265)
            {
                percentBar.Size = new Size(160, 160);
                percentBar.Font = new Font("Arial", 34, FontStyle.Bold);

                panelValue.Height = 53;
                txtLife.Font = new Font("Arial", 39, FontStyle.Bold);
                txtLife.Location = new Point(-4, -5);
                txtWarning.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
                txtName.Font = new Font("Arial", 24, FontStyle.Bold);
            }
            else if (w <= 265 && w > 228)
            {
                percentBar.Size = new Size(130, 130);
                percentBar.Font = new Font("Arial", 24, FontStyle.Bold);
                panelValue.Height = 30;
                txtLife.Location = new Point(0, -10);
                txtLife.Font = new Font("Arial", 20, FontStyle.Bold);
                txtWarning.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            else
            {
                percentBar.Size = new Size(100, 100);
                percentBar.Font = new Font("Arial", 24, FontStyle.Bold);
                panelValue.Height = 30;
                txtLife.Location = new Point(0, -10);
                txtLife.Font = new Font("Arial", 20, FontStyle.Bold);
                txtWarning.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            percentBar.Location = new Point(w - percentBar.Width - 8, 9);
            panelValue.Location = new Point(6, txtWarning.Location.Y - panelValue.Height);

        }
    }
}
