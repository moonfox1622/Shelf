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
        
        ToolDatabase tdb = new ToolDatabase();
        

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
            LoadProgressBar();

            //count>80:green, 80>count>=50:yellow, count<50:red
            if (tool.remain >= 80)
            {
                remainLifeBar.SliderColor = Color.FromArgb(89, 201, 165);
            }
            else if(tool.remain < 80 && tool.remain >= 50)
            {
                remainLifeBar.SliderColor = Color.FromArgb(242, 236, 0);
            }
            else
            {
                remainLifeBar.SliderColor = Color.FromArgb(216, 30, 91);
            }

            if(tool.remain < check)
            {
                tool.alarm = true;
            }
            else
            {
                tool.alarm = false;
            }
            //alarm == true show picAlarm
            if (tool.alarm == true)
            {
                //picWarning.Visible = true;
                txtCount.ForeColor = Color.White;
                panelStatus.BackColor = Color.FromArgb(216, 30, 91);
            }

        }


        /// <summary>
        /// 開啟設定頁面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingPage(object sender, EventArgs e)
        {
            Setting setting = new Setting { id = tool.id };
            setting.ShowDialog();
            if (setting.isDelete)
            {
                this.Parent.Controls.Remove(this);
                return;
            }
            Tool t = new Tool();
            tdb.GetToolById(tool.id, ref t);
            tool = t;
            this.CheckStatus();
        }

        /// <summary>
        /// 執行更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void BtnRunClick(object sender, EventArgs e)
        //{
        //    if(btnRun.Tag.ToString() == "play")
        //    {
        //        if (!tdb.HistoryInsert(tool, '1'))
        //            return;
        //        btnRun.Tag = "stop";
        //        btnRun.Image = Properties.Resources.stop;
        //        return;
        //    }

        //    tool.remain -= 3;
        //    if (!tdb.UpdateTool(tool))
        //        return;
        //    if (!tdb.HistoryInsert(tool, '2'))
        //        return;
        //    btnRun.Tag = "play";
        //    Tool t = tool;
        //    tdb.GetLastHistory(ref t);
        //    tool = t;
        //    btnRun.Image = Properties.Resources.play;
        //    CheckStatus();
        //}

        /// <summary>
        /// 觸發機台故障
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWarnClick(object sender, EventArgs e)
        {
            tdb.HistoryInsert(tool, '7');
        }
    }
}