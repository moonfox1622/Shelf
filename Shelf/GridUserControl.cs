using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Shelf
{
    public partial class GridUserControl : UserControl
    {
        public Tool tool { get; set; }
        
        public GridUserControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Grid_Load(object sender, EventArgs e)
        {
            //set ProgressBar in DoubleBuffered (can stop the flicker)
            typeof(ProgressBar).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, remainLifeBar, new object[] { true });

            //CheckStatus();
        }
        
        /// <summary>
        /// 剩餘壽命條
        /// </summary>
        private void LoadProgressBar()
        {
            if (tool.Remain <= 0)
            {
                remainLifeBar.Value = 0;
            }
            else
            {
                remainLifeBar.Maximum = tool.Life;
                remainLifeBar.Value = tool.Remain;
            }
        }

        /// <summary>
        /// 檢查刀具目前狀態
        /// </summary>
        public void CheckStatus()
        {
            txtWarning.Text = "警戒值: " + tool.Warning.ToString();
            remainLifeBar.Maximum = tool.Life;
            txtName.Text = tool.Name;
            txtCount.Text = tool.Remain.ToString();
            double percent = ((double)tool.Remain / (double)tool.Life) * 100;
            txtPercet.Text = string.Format("{0}%", (int)percent);
            LoadProgressBar();

            //count>80:green, 80>count>=50:yellow, count<50:red
            if (percent >= 80)
            {
                remainLifeBar.SliderColor = Color.FromArgb(89, 201, 165);
                txtPercet.BackColor = Color.FromArgb(89, 201, 165);
                txtPercet.ForeColor = Color.White;
                
            }
            else if(percent < 80 && percent >= 50)
            {
                remainLifeBar.SliderColor = Color.FromArgb(242, 236, 0);
                txtPercet.BackColor = Color.FromArgb(242, 236, 0);
                txtPercet.ForeColor = Color.Black;
            }
            else
            {
                remainLifeBar.SliderColor = Color.FromArgb(216, 30, 91);
                txtPercet.BackColor = Color.FromArgb(216, 30, 91);
                txtPercet.ForeColor = Color.White;
            }

            //warning == true show picAlarm
            if (tool.Remain <= tool.Warning)
            {
                txtCount.ForeColor = Color.White;
                panelStatus.BackColor = Color.FromArgb(216, 30, 91);
            }
            else
            {
                txtCount.ForeColor = Color.Black;
                panelStatus.BackColor = Color.FromArgb(241, 241, 241);
            }

            if (tool.Taken)
                ToolUse();
            else
                ToolUnuse();

        }

        public void ToolUse()
        {
            this.Invalidate();
        }

        public void ToolUnuse()
        {
            this.Invalidate();
        }

        private void GridUserControl_Paint(object sender, PaintEventArgs e)
        {
            if (tool.Taken)
            {
                ButtonBorderStyle style = ButtonBorderStyle.Solid;
                Color color = Color.FromArgb(13, 131, 0);
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, color, 6, style, color, 6, style, color, 6, style, color, 6, style);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.None);
            }
            
            
        }
    }
}