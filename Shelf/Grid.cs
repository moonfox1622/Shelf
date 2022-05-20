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

            tipSetting.SetToolTip(picChange, "換刀");
            tipSetting.SetToolTip(picEdit, "修改");
            tipSetting.SetToolTip(picDelete, "刪除");

            remainLifeBar.Maximum = tool.life;
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

            if(tool.startTime != null && tool.endTime == null)
            {
                btnRun.Image = Properties.Resources.stop;
                btnRun.Tag = "stop";
            }

        }

        /// <summary>
        /// 刪除刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTool(object sender, EventArgs e)
        {

            panelGrid.BorderStyle = BorderStyle.Fixed3D;
            if (MessageBox.Show("確定要刪除「" + tool.name + "」嗎", "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (tdb.DeleteTool(tool.name))
                {
                    tdb.HistoryInsert(tool, '6');
                    this.Parent.Controls.Remove(this);
                }
            }
            panelGrid.BorderStyle = BorderStyle.None;
        }

        private void EditTool(object sender, EventArgs e)
        {
            panelGrid.BorderStyle = BorderStyle.Fixed3D;
            EditTool setting = new EditTool();
            setting.tool = tool;
            setting.ShowDialog();
            panelGrid.BorderStyle = BorderStyle.None;
            if (setting.hasUpdate)
            {
                tool = setting.tool;
                tdb.HistoryInsert(tool, '5');
                CheckStatus();
            }
        }

        /// <summary>
        /// 執行更換刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTool(object sender, EventArgs e)
        {
            panelGrid.BorderStyle = BorderStyle.Fixed3D;
            ChangeTool change = new ChangeTool();
            change.tool = tool;
            change.ShowDialog();
            panelGrid.BorderStyle = BorderStyle.None;
            if (!change.hasChange)
                return;
            tool = change.tool;
            CheckStatus();
        }

        /// <summary>
        /// 開啟設定按鈕
        /// </summary>
        public void OpenSetting()
        {
            picChange.Visible = true;
            picEdit.Visible = true;
            picDelete.Visible = true;
        }

        public void CloseSetting()
        {
            picChange.Visible = false;
            picEdit.Visible = false;
            picDelete.Visible = false;
        }

        private void BtnRunClick(object sender, EventArgs e)
        {
            if(btnRun.Tag.ToString() == "play")
            {
                if (!tdb.HistoryInsert(tool, '1'))
                    return;
                btnRun.Tag = "stop";
                btnRun.Image = Properties.Resources.stop;
                return;
            }

            tool.remain -= 3;
            if (!tdb.UpdateTool(tool))
                return;
            if (!tdb.HistoryInsert(tool, '2'))
                return;
            btnRun.Tag = "play";
            Tool t = tool;
            tdb.GetLastHistory(ref t);
            tool = t;
            btnRun.Image = Properties.Resources.play;
            CheckStatus();
        }

        private void BtnWarnClick(object sender, EventArgs e)
        {
            tdb.HistoryInsert(tool, '7');
        }
    }
}