using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

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
            this.DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panelValue, new object[] { true });
            CheckStatus();
        }

        public void CheckStatus()
        {
            
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
            //panelValue.BackColor = bc;
        }

        public void ToolUse()
        {
            this.Invalidate();
            panelValue.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsePaint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            Color backC = Color.FromArgb(241, 241, 241);
            if (tool.Taken)
            {
                ButtonBorderStyle style = ButtonBorderStyle.Solid;
                Color color = Color.FromArgb(13, 131, 0);
                ControlPaint.DrawBorder(e.Graphics, c.ClientRectangle, color, 6, style, color, 6, style, color, 6, style, color, 6, style);
                //ControlPaint.DrawBorder(e.Graphics, panelValue.ClientRectangle, color, 6, style, color, 6, style, color, 6, style, color, 6, style);
                
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, c.ClientRectangle, Color.Black, ButtonBorderStyle.None);
            }

        }

        private void panelValuePaint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            
            Color backC = Color.FromArgb(241, 241, 241);
            if (tool.Taken)
            {
                ButtonBorderStyle style = ButtonBorderStyle.Solid;
                Color color = Color.FromArgb(13, 131, 0);
                ControlPaint.DrawBorder(e.Graphics, c.ClientRectangle, color, 6, style, color, 6, style, color, 0, style, color, 6, style);
                //ControlPaint.DrawBorder(e.Graphics, panelValue.ClientRectangle, color, 6, style, color, 6, style, color, 6, style, color, 6, style);
                
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, c.ClientRectangle, Color.Black, ButtonBorderStyle.None);
            }
        }

        /// <summary>
        /// 縮放元件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircularProgressUserControl_Resize(object sender, EventArgs e)
        {
            int w = this.Width; //306
            int h = this.Height; //181
            if (w > 265)
            {
                percentBar.Font = new Font("Arial", 34, FontStyle.Bold);
                txtLife.Font = new Font("Arial", 35, FontStyle.Bold);
                
                txtWarning.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
                txtName.Font = new Font("Arial", 24, FontStyle.Bold);
            }
            else if (w <= 265 && w > 228)
            {
                percentBar.Font = new Font("Arial", 20, FontStyle.Bold);
                txtLife.Font = new Font("Arial", 20, FontStyle.Bold);
                txtWarning.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            else
            {
                percentBar.Font = new Font("Arial", 20, FontStyle.Bold);
                txtLife.Font = new Font("Arial", 20, FontStyle.Bold);
                txtWarning.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            txtLife.Location = new Point(6, panelValue.Height - txtWarning.Height - txtLife.Height - 5);
            panelPercent.Width = panelPercent.Height;
            panelPercent.Location = new Point(w - panelPercent.Width - 8, 7);

        }
    }
}
