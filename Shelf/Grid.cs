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
    public partial class Grid : UserControl
    {
        public Tool tool { get; set; }
        public int check { get; set; }

        public Grid()
        {
            InitializeComponent();

        }

        private void Grid_Load(object sender, EventArgs e)
        {
            //set ProgressBar in DoubleBuffered (can stop the flicker)
            typeof(ProgressBar).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, remainLifeBar, new object[] { true });

            //txtName.Parent = picStatus;

            remainLifeBar.Maximum = tool.life;
            //TextResize();
            CheckStatus();
        }
        
        private void TextResize()
        {
            LoadProgressBar();
            if (tool.name.Length >= 6)
            {
                txtName.Font = new Font("Arial", 18, FontStyle.Bold);
            }
        }

        private void LoadProgressBar()
        {
            if (tool.remain <= 0)
            {
                remainLifeBar.Value = 0;
            }
            else
            {
                remainLifeBar.Value = tool.remain;
            }
        }

        /// <summary>
        /// 檢查刀具目前狀態
        /// </summary>
        public void CheckStatus()
        {
            txtName.Text = tool.name;
            txtCount.Text = tool.remain.ToString();
            LoadProgressBar();

            if(txtCount.Text.Length >= 3)
            {
                panelStatus.Size = new Size(86, 45);
                panelStatus.Location = new Point(48, 1);
            }
            else
            {
                panelStatus.Size = new Size(64, 45);
                panelStatus.Location = new Point(74, 1);
            }

            //count>80:green, 80>count>=50:yellow, count<50:red
            if (tool.remain >= 80)
            {
                //this.BackColor = Color.FromArgb(89, 201, 165);
                picStatus.Image = Shelf.Properties.Resources.greenLight;
                remainLifeBar.SliderColor = Color.FromArgb(89, 201, 165);
            }
            else if(tool.remain < 80 && tool.remain >= 50)
            {
                //this.BackColor = Color.FromArgb(255, 253, 152);
                picStatus.Image = Shelf.Properties.Resources.yellowLightdark;
                remainLifeBar.SliderColor = Color.FromArgb(242, 236, 0);
            }
            else
            {
                //this.BackColor = Color.FromArgb(216, 30, 91);
                picStatus.Image = Shelf.Properties.Resources.yellowLightdark;
                remainLifeBar.SliderColor = Color.FromArgb(216, 30, 91);
            }

            //alarm == true show picAlarm
            if (tool.remain <= check)
            {
                //picWarning.Visible = true;
                txtCount.ForeColor = Color.White;
                panelStatus.BackColor = Color.FromArgb(216, 30, 91);
            }
        }
    }
}