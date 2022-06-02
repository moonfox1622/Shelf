﻿using System;
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
    public partial class GridUserControl : UserControl
    {
        public Tool tool { get; set; }
        public int check { get; set; }
        
        ToolDatabase tdb = new ToolDatabase();
        

        public GridUserControl()
        {
            InitializeComponent();
        }

        private void Grid_Load(object sender, EventArgs e)
        {
            //set ProgressBar in DoubleBuffered (can stop the flicker)
            typeof(ProgressBar).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, remainLifeBar, new object[] { true });

            txtWarning.Text = "Warn: " + tool.warning.ToString();
            remainLifeBar.Maximum = tool.life;

            CheckStatus();
        }
        
        /// <summary>
        /// 剩餘壽命條
        /// </summary>
        private void LoadProgressBar()
        {
            if (tool.remain <= 0)
            {
                remainLifeBar.Value = 0;
            }
            else
            {
                remainLifeBar.Maximum = tool.life;
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
            double percent = ((double)tool.remain / (double)tool.life) * 100;
            txtPercet.Text = string.Format("{0}%", (int)percent);
            LoadProgressBar();

            //count>80:green, 80>count>=50:yellow, count<50:red
            if (percent >= 80)
            {
                remainLifeBar.SliderColor = Color.FromArgb(89, 201, 165);
                txtPercet.BackColor = Color.FromArgb(89, 201, 165);
            }
            else if(percent < 80 && percent >= 50)
            {
                remainLifeBar.SliderColor = Color.FromArgb(242, 236, 0);
                txtPercet.BackColor = Color.FromArgb(242, 236, 0);
            }
            else
            {
                remainLifeBar.SliderColor = Color.FromArgb(216, 30, 91);
                txtPercet.BackColor = Color.FromArgb(216, 30, 91);
            }

            //warning == true show picAlarm
            if (tool.remain <= tool.warning)
            {
                //picWarning.Visible = true;
                txtCount.ForeColor = Color.White;
                panelStatus.BackColor = Color.FromArgb(216, 30, 91);
            }

        }

        public void ToolUse()
        {
            picRunning.Visible = true;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void ToolUnuse()
        {
            picRunning.Visible = false;
            this.BorderStyle = BorderStyle.None;
        }
        
    }
}