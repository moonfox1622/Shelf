using Shelf.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Shelf
{
    public partial class MainForm : Form
    {
        //資料庫連線設定
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        //List<int> lastDatas = new List<int>(); //預防更新失敗之暫存資料
        List<GridUserControl> tools = new List<GridUserControl>(); //刀具UserController List
        List<int> checkDatas; //觸發警報數值(隨機生成)
        bool keepUpdate = true; //持續更新刀具資料
        TableLayoutPanel table = new TableLayoutPanel();
        ToolDatabase tdb = new ToolDatabase();
        bool simulateRun = true;

        //Delegate function
        private delegate void updateGridUI();
        private delegate void deleInitialContent(bool save);


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainShown(object sender, EventArgs e)
        {
            //回傳本地資料指資料庫
            Thread restoreThread = new Thread(SendLocalData);
            restoreThread.Start();

            //SetDoubleBuffered(content);
            initialContent(true);
            Thread thread = new Thread(ToolUpdate);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="save">紀錄歷史</param>
        /// <param name="edit">設定模式</param>
        private void initialContent(bool save)
        {
            content.Controls.Clear();
            tools = new List<GridUserControl>();
            LoadData(ref tools);
            
            table = initialTablePanel();

            Random randNum = new Random();
            checkDatas = Enumerable
                .Repeat(0, tools.Count)
                .Select(i => randNum.Next(0, 49))
                .ToList();
            //Point loc = new Point(0, 23);
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].check = checkDatas[i];
                //tools[i].Location = loc;
                
                table.Controls.Add(tools[i], i % 6, table.RowCount);

                //設定方框位置，每六個換一行
                if ((i + 1) % 6 == 0)
                {
                    table.RowCount += 1;
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
                }
            }
            content.Controls.Add(table);
        }


        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private void LoadData(ref List<GridUserControl> tools)
        {
            List<Tool> toolsData = new List<Tool>();
            if (!tdb.GetAllTool(ref toolsData))
            {
                MessageBox.Show("無法取得資料");
                return;
            }

            for(int i=0 ; i<toolsData.Count ; i++)
            {
                Tool t = toolsData[i];
                tdb.GetLastHistory(ref t);
                GridUserControl g = new GridUserControl
                {
                    tool = t
                };

                tools.Add(g);
            }
        }

        /// <summary>
        /// 當有 Grid 被刪除整理畫面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableControlRemoved(object sender, ControlEventArgs e)
        {
            initialContent(false);
        }

        /// <summary>
        /// 刀具方框排版設定
        /// </summary>
        /// <returns></returns>
        private TableLayoutPanel initialTablePanel()
        {
            table = new TableLayoutPanel();
            table.ColumnCount = 6;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
            table.Dock = DockStyle.Fill;
            table.ControlRemoved += TableControlRemoved;
            return table;
        }

        /// <summary>
        /// 持續更新刀具資料
        /// </summary>
        private void ToolUpdate()
        {
            while (keepUpdate)
            {
                List<Tool> toolData = new List<Tool>();
                if(!tdb.GetAllTool(ref toolData))
                {
                    return;
                }
                if(toolData.Count != tools.Count)
                {
                    Invoke(new deleInitialContent(initialContent), false);
                    continue;
                }
                for(int i = 0; i < tools.Count; i++)
                {
                    tools[i].tool.name = toolData[i].name;
                    tools[i].tool.life = toolData[i].life;
                    tools[i].tool.remain = toolData[i].remain;
                    tools[i].tool.warning = toolData[i].warning;
                    Invoke(new updateGridUI(tools[i].CheckStatus));
                }
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        ///  資料更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRunClick(object sender, EventArgs e)
        {
            if(btnRun.Tag.ToString() == "start")
            {
                Thread sim = new Thread(simulate);
                simulateRun = true;
                btnRun.Tag = "end";
                btnRun.Text = "結束";
                sim.Start();
            }
            else
            {
                simulateRun = false;
                btnRun.Tag = "start";
                btnRun.Text = "開始";
            }
        }


        /// <summary>
        /// 重新設定刀具庫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClick(object sender, EventArgs e)
        {
            ResetForm reset = new ResetForm();
            reset.ShowDialog();
            if (reset.resetCount != 0)
            {
                //updateCount = 0;
                int insertCount = 0;
                List<Tool> newDatas = new List<Tool>();
                Random randNum = new Random();
                for (int i = 0; i < reset.resetCount; i++)
                {
                    int randLife = randNum.Next(80, 100);
                    int randAlarm = randNum.Next(0, 50);
                    Tool data = new Tool
                    {
                        name = "I" + i,
                        life = randLife,
                        remain = randLife,
                        warning = randAlarm
                    };
                    newDatas.Add(data);
                }
                var query = @"DELETE FROM tool";
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectStr))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        using (SqlCommand comm = new SqlCommand(query, conn))
                        {
                            comm.ExecuteNonQuery();
                        }

                        foreach (Tool data in newDatas)
                        {
                            query = @"INSERT INTO tool(id, name, life, remain, warning) VALUES (@id, @name, @life, @remain, @warning)";
                            using (SqlCommand comm = new SqlCommand(query, conn))
                            {
                                comm.Parameters.AddWithValue("@id", insertCount);
                                comm.Parameters.AddWithValue("@name", data.name);
                                comm.Parameters.AddWithValue("@life", data.life);
                                comm.Parameters.AddWithValue("@remain", data.remain);
                                comm.Parameters.AddWithValue("@warning", data.warning);
                                insertCount += comm.ExecuteNonQuery();
                            }
                        }

                    }
                } catch (SqlException ex)
                {
                    MessageBox.Show("資料庫發生問題，新增失敗：" + ex.Message);
                } catch (Exception ex)
                {
                    MessageBox.Show("新增失敗：" + ex.Message);
                }
                if (insertCount != reset.resetCount)
                {
                    MessageBox.Show("新增過程中發生錯誤，未新增完全");
                }
                else
                {
                    MessageBox.Show("新增成功");
                    initialContent(true);
                }
            }
            else
            {
                MessageBox.Show("未進行任何改變");
            }

        }

        /// <summary>
        /// 主頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainClick(object sender, EventArgs e)
        {
            initialContent(false);
            btnRun.Visible = true;
            if (!keepUpdate)
            {
                keepUpdate = true;
                Thread thread = new Thread(ToolUpdate);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        /// <summary>
        /// 模擬刀具使用
        /// </summary>
        private void simulate()
        {
            int count = 0;
            
            while (simulateRun)
            {
                Random rand = new Random();
                int decrease = rand.Next(3, 6);
                int randNum = rand.Next(0, tools.Count);
                Tool randTool = tools[randNum].tool;
                UseTool(randTool, DateTime.Now);
                Thread.Sleep(3000);
                randTool.remain -= decrease;
                ReturnTool(randTool, DateTime.Now);
                
                count++;
            }
        }

        /// <summary>
        /// 使用刀具
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool UseTool(Tool t, DateTime startTime)
        {
            if (!tdb.checkExist(t.name))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }

            foreach(GridUserControl g in tools)
            {
                if (g.tool.name == t.name)
                {
                    Invoke(new updateGridUI(g.ToolUse));
                    g.tool.startTime = startTime;
                    break;
                }
            }

            return true;
        }

        /// <summary>
        /// 刀具使用完畢
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remain"></param>
        /// <returns></returns>
        private bool ReturnTool(Tool t, DateTime endTime)
        {
            Tool lastToolStatus = new Tool();
            if (!tdb.GetToolByName(t.name, ref lastToolStatus))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }
            
            ToolHistory history = new ToolHistory();
            foreach (GridUserControl g in tools)
            {
                if (g.tool.name == t.name)
                {
                    if (!tdb.UpdateTool(t))
                        return false;
                    history = new ToolHistory
                    {
                        toolId = t.id,
                        name = t.name,
                        beforeUseLife = lastToolStatus.remain,
                        afterUseLife = t.remain,
                        startTime = g.tool.startTime,
                        endTime = endTime,
                        warning = t.warning,
                        mark = '1'
                    };
                    Invoke(new updateGridUI(g.ToolUnuse));
                    break;
                }
            }

            bool result = tdb.HistoryUseTool(history);

            return result;
        }

        /// <summary>
        /// 刀具歷史紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHistoryClick(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }

        /// <summary>
        /// 設定頁面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSettingClick(object sender, EventArgs e)
        {
            keepUpdate = false;
            content.Controls.Clear();
            SettingPageUserControl settingPage = new SettingPageUserControl();
            settingPage.Dock = DockStyle.Fill;
            content.Controls.Add(settingPage);
            btnRun.Visible = false;
            settingPage.GridViewStyle();
        }


        private void SendLocalData()
        {
            if (!File.Exists("Temp\\TempHistoryData.csv"))
                return;
            if (!tdb.IsDatabaseConnected())
            {

            }                
            TempSave tempSave = new TempSave();
            //tempSave.SaveToolTempInDatabase();
        }
    }
}