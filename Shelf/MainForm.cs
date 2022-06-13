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
        bool keepUpdate = true; //持續更新刀具資料
        int carouselSpeed = 10;
        //TableLayoutPanel table = new TableLayoutPanel();
        ToolDatabase tdb = new ToolDatabase();
        bool simulateRun = true;
        Machine machine = new Machine();
        //int machineId = 1;


        //Delegate function
        private delegate void updateGridUI();

        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainShown(object sender, EventArgs e)
        {
            //回傳本地資料指資料庫
            //Thread restoreThread = new Thread(SendLocalData);
            //restoreThread.Start();
            if (!tdb.GetTopMachine(ref machine))
            {
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            initialContent();
            if (tools.Count == 0)
                return;
            keepUpdate = true;

            Thread thread = new Thread(ToolUpdate);
            thread.IsBackground = true;
            thread.Start();

            Thread carouselThread = new Thread(CarouselMachine);
            carouselThread.IsBackground = true;
            carouselThread.Start();

        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void initialContent()
        {
            content.Controls.Clear();
            tools = new List<GridUserControl>();
            if (!LoadData(ref tools, machine.id))
                return;

            txtMachineName.Text = machine.name;
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].Margin = new Padding(8, 0, 8, 50);
                //設定方框位置，每六個換一行
                //if ((i + 1) % 6 == 0)
                //{
                //    content.SetFlowBreak(tools[i], true);
                //}
                content.Controls.Add(tools[i]);
            }
        }

        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private bool LoadData(ref List<GridUserControl> tools, int machineId)
        {
            List<Tool> toolsData = new List<Tool>();
            if (!tdb.GetToolByMachineId(ref toolsData, machineId))
            {
                return false;
            }

            for(int i=0 ; i<toolsData.Count ; i++)
            {
                //讀取中斷資料
                Tool t = toolsData[i];
                ToolHistory h = new ToolHistory { name = t.name };
                tdb.GetLastHistory(ref h);
                t.startTime = h.startTime;
                t.endTime = h.endTime;

                GridUserControl g = new GridUserControl
                {
                    tool = t
                };

                tools.Add(g);
            }
            return true;
        }

        /// <summary>
        /// 當有 Grid 被刪除整理畫面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableControlRemoved(object sender, ControlEventArgs e)
        {
            initialContent();
        }

        /// <summary>
        /// 刀具方框排版設定
        /// </summary>
        /// <returns></returns>
        private TableLayoutPanel InitialTablePanel()
        {
            TableLayoutPanel table = new TableLayoutPanel();
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

        private FlowLayoutPanel InitialFlowPanel()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.LeftToRight;
            flow.WrapContents = true;
            flow.AutoScroll = true;
            

            return flow;
        }

        /// <summary>
        /// 持續更新刀具資料
        /// </summary>
        private void ToolUpdate()
        {
            try
            {
                while (keepUpdate)
                {
                    List<Tool> toolData = new List<Tool>();
                    
                    if (!tdb.GetToolByMachineId(ref toolData, machine.id))
                    {
                        continue;
                    }

                    if (toolData.Count != tools.Count || toolData[0].machineId != tools[0].tool.machineId)
                    {
                        Invoke(new updateGridUI(initialContent));
                        continue;
                    }
                    for (int i = 0; i < tools.Count; i++)
                    {
                        tools[i].tool = toolData[i];
                        Invoke(new updateGridUI(tools[i].CheckStatus));
                    }
                    Thread.Sleep(1000);
                }
            }catch (Exception e)
            {

            }
            
        }

        /// <summary>
        /// 定時變換觀看機台ID
        /// </summary>
        private void CarouselMachine()
        {
            List<Machine> machines = new List<Machine>();
            if (!tdb.GetAllMachine(ref machines))
            {
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            while (keepUpdate)
            {
                
                foreach(Machine m in machines)
                {
                    List<Tool> tList = new List<Tool>();
                    tdb.GetToolByMachineId(ref tList, m.id);

                    if (carouselSpeed != 0)
                    {
                        if (tList.Count == 0)
                            continue;
                        machine = m;
                        Thread.Sleep(carouselSpeed * 1000);
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                        
                    
                }
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
                
                
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectStr))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        

                        var query = @"DELETE FROM tool WHERE machineId = @machineId";
                        using (SqlCommand comm = new SqlCommand(query, conn))
                        {
                            comm.Parameters.AddWithValue("@machineId", machine.id);
                            comm.ExecuteNonQuery();
                        }

                        query = @"SELECT MAX(id) as id FROM tool";
                        int maxId = 0;
                        using (SqlCommand comm = new SqlCommand(query, conn))
                        {
                            comm.Parameters.AddWithValue("@machineId", machine.id);
                            using (SqlDataReader data = comm.ExecuteReader())
                            {
                                if(data.HasRows)
                                    while (data.Read())
                                    {
                                        maxId = Convert.ToInt32(data["id"].ToString());
                                    }
                            }
                        }

                        for (int i = 1; i <= reset.resetCount; i++)
                        {
                            int randLife = randNum.Next(80, 100);
                            int randAlarm = randNum.Next(0, 50);
                            Tool data = new Tool
                            {
                                id = maxId + i,
                                name = "T" + i,
                                life = randLife,
                                remain = randLife,
                                warning = randAlarm
                            };
                            newDatas.Add(data);
                        }

                        foreach (Tool data in newDatas)
                        {
                            query = @"INSERT INTO tool(id, name, life, remain, warning, machineId) VALUES (@id, @name, @life, @remain, @warning, @machineId)";
                            using (SqlCommand comm = new SqlCommand(query, conn))
                            {
                                comm.Parameters.AddWithValue("@id", data.id);
                                comm.Parameters.AddWithValue("@name", data.name);
                                comm.Parameters.AddWithValue("@life", data.life);
                                comm.Parameters.AddWithValue("@remain", data.life);
                                comm.Parameters.AddWithValue("@warning", data.warning);
                                comm.Parameters.AddWithValue("@machineId", machine.id);
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
                    initialContent();
                }
            }
            else
            {
                MessageBox.Show("未進行任何改變");
            }
        }


        /// <summary>
        /// 模擬刀具使用
        /// </summary>
        private void simulate()
        {
            Random rand = new Random();
            List<Machine> mList = new List<Machine>();
            if (!tdb.GetAllMachine(ref mList))
                return;
            while (simulateRun)
            {
                int machineId = rand.Next(mList[0].id, mList.Count);
                //machineId = 1;
                List<Tool> allToolList = new List<Tool>();
                DateTime startTime = DateTime.Now;
                if (!tdb.GetToolByMachineId(ref allToolList, machineId))
                    continue;
                if (allToolList.Count == 0)
                    continue;
                List<Tool> tools = new List<Tool>();

                for(int i = 0; i < 5; i++)
                {
                    int randNum = rand.Next(0, allToolList.Count);
                    bool add = true;
                    for (int j = 0; j < tools.Count; j++)
                    {
                        if (tools[j].id == allToolList[randNum].id)
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                        tools.Add(allToolList[randNum]);
                    UseTool(allToolList[randNum].name, allToolList[randNum].machineId);
                    Thread.Sleep(5000);
                }
                
                foreach(Tool t in tools)
                {
                    DateTime endTime = DateTime.Now;
                    int decrease = rand.Next(3, 6);
                    int remain = t.remain - decrease;
                    WriteHistory(t.name, machineId, remain, startTime, endTime);
                }
            }
        }

        /// <summary>
        /// 使用刀具
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool UseTool(string name, int machineId)
        {
            Tool t = new Tool ();
            
            if (!tdb.GetToolByName(name, machineId, ref t))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }

            if (tdb.UnuseTool(machineId))
            {
                //MessageBox.Show("test");
            }
            t.lastUpdate = DateTime.Now;
            if (!tdb.UpdateTool(t, true))
                return false;

            return true;
        }

        private void Finished(int machineId)
        {
            tdb.UnuseTool(machineId);
        }

        /// <summary>
        /// 刀具使用完畢
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remain"></param>
        /// <returns></returns>
        private bool WriteHistory(string name, int machineId, int remain, DateTime startTime, DateTime endTime)
        {
            Tool t = new Tool();
            if (!tdb.GetToolByName(name, machineId, ref t))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }
            int beforeUseLife = t.remain;
            t.remain = remain;

            ToolHistory h = new ToolHistory
            {
                toolId = t.id,
                name = t.name,
                beforeUseLife = beforeUseLife,
                afterUseLife = t.remain,
                warning = t.warning,
                startTime = startTime,
                endTime = endTime,
                mark = '1',
                dateTime = DateTime.Now
            };
            if (!tdb.UpdateTool(t, false))
                return false;
            if (!tdb.HistoryTool(h))
                return false;

            return true;
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
            SettingPageForm setting = new SettingPageForm();
            setting.ShowDialog();
        }

        /// <summary>
        /// 開啟輪播設定頁面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDashBoardClick(object sender, EventArgs e)
        {
            DashboardSettingForm dashboard = new DashboardSettingForm();
            dashboard.carouselSpeed = carouselSpeed;
            dashboard.machineId = machine.id;
            dashboard.machineName = machine.name;

            dashboard.ShowDialog();
            carouselSpeed = dashboard.carouselSpeed;
            if(carouselSpeed == 0)
            {
                machine = new Machine
                {
                    id = dashboard.machineId,
                    name = dashboard.machineName
                };
            }
            
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