using Shelf.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Shelf
{
    public partial class MainForm : Form
    {
        //資料庫連線設定
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        TableLayoutPanel table = new TableLayoutPanel();
        List<GridUserControl> tools = new List<GridUserControl>(); //刀具UserController List
        bool keepUpdate = true; //持續更新刀具資料
        int carouselSpeed = 10;
        ToolDatabase tdb = new ToolDatabase();
        bool simulateRun = true;
        Machine machine = new Machine();
        int page = 0;
        
        //Delegate function
        private delegate void updateGridUI();

        
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        } 

        private void MainShown(object sender, EventArgs e)
        {
            if (!tdb.IsDatabaseConnected())
            {
                txtMachineName.Text = "未連線";
                return;
            }
            //回傳本地資料指資料庫
            Thread restoreThread = new Thread(TmpDataRestore);
            restoreThread.Start();

            if (!tdb.GetTopMachine(ref machine))
            {
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            initialContent();
            if (tools.Count == 0)
                return;
            keepUpdate = true;

            Thread thread = new Thread(ToolUpdateCycle);
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
            //content.Controls.Clear();
            tools = new List<GridUserControl>();
            table = InitialTablePanel();
            
            if (!LoadData(ref tools, machine.id, page))
                return;

            txtMachineName.Text = machine.name;
            for (int i = 0; i < tools.Count; i++)
            {
                //tools[i].Margin = new Padding(8, 0, 8, 50);
                table.Controls.Add(tools[i], i % 6, table.RowCount);
                //設定方框位置，每六個換一行
                if ((i + 1) % 6 == 0)
                {
                    table.RowCount += 1;
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
                }
            }
            foreach (Control c in content.Controls)
            {
                c.Dispose();
            }
            content.Controls.Add(table);
        }

        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private bool LoadData(ref List<GridUserControl> tools, int machineId, int page)
        {
            List<Tool> toolsData = new List<Tool>();
            if (!tdb.GetToolByPage(ref toolsData, machineId, page))
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
            ToolUpdate();
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
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            table.AutoScroll = false;
            table.Dock = DockStyle.Fill;
            table.ControlRemoved += TableControlRemoved;
            return table;
        }

        /// <summary>
        /// 持續更新刀具資料
        /// </summary>
        private void ToolUpdateCycle()
        {
            try
            {
                while (keepUpdate)
                {
                    Invoke(new updateGridUI(ToolUpdate));
                    Thread.Sleep(1000);
                }
            }catch
            {

            }
            
        }

        /// <summary>
        /// 更新畫面刀具資料
        /// </summary>
        private void ToolUpdate()
        {
            try
            {
                List<Tool> toolData = new List<Tool>();
                txtMachineName.Text = machine.name;
                if (!tdb.GetToolByPage(ref toolData, machine.id, page))
                    return;

                int toolsCount = TableCellShowCount(table);
                

                //若讀取資料比原來的多，多顯示 n 個GridUserControl
                if (toolData.Count > toolsCount)
                {
                    for (int i = toolsCount; i <= (toolData.Count-1); i++)
                    {
                        table.GetControlFromPosition(i % 6, i / 6).Visible = true;
                    }
                }

                //若讀取資料比原來的少，隱藏 n 個GridUserControl
                if (toolData.Count < toolsCount)
                {
                    for (int i = toolsCount-1; i >  (toolData.Count - 1); i--)
                    {
                        table.GetControlFromPosition(i % 6, i / 6).Visible = false;
                    }
                }

                for (int i = 0; i < tools.Count; i++)
                {
                    tools[i].tool = toolData[i];
                    tools[i].CheckStatus();
                }
            }
            catch
            {

            }
        }

        private int TableCellShowCount(TableLayoutPanel t)
        {
            int toolsCount = 0;
            for (int i = 0; i < t.RowCount; i++)
            {
                for (int j = 0; j < t.ColumnCount; j++)
                {
                    if (t.GetControlFromPosition(j, i).Visible == false)
                        return toolsCount;
                    toolsCount++;

                }
            }
            return toolsCount;
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
                        //Invoke(new updateGridUI(showPages));
                        Thread.Sleep(3000);
                    }
                }
            }
        }

        private void showPages(bool status)
        {
            if (status)
            {
                int num = tdb.GetToolCountByMachine(machine.id);
                int maxPage = num / 36;
                if (num % 36 != 0)
                    maxPage++;
                txtMaxPage.Text = maxPage.ToString();
                txtPage.Text = "1";
                
                page = 0;

                txtMaxPage.Visible = true;
                txtPage.Visible = true;
                txtDivide.Visible = true;
                btnNext.Visible = true;
                btnLast.Visible = true;

                btnLast.Enabled = false;
                btnNext.Enabled = true;
                btnLast.Image = Properties.Resources.disableLeft;
                btnNext.Image = Properties.Resources.right;
                if (maxPage == 0)
                {
                    btnNext.Image = Properties.Resources.disableRight;
                    btnNext.Enabled = false;
                    txtPage.Text = "0";
                }
                    
            }
            else
            {
                txtMaxPage.Visible = false;
                txtPage.Visible = false;
                txtDivide.Visible = false;
                btnNext.Visible = false;
                btnLast.Visible = false;
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
                    ToolUpdate();
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
                
                foreach (Tool t in tools)
                {
                    DateTime endTime = DateTime.Now;
                    int decrease = rand.Next(3, 6);
                    int remain = t.remain - decrease;
                    if (remain <= 0)
                        remain = 0;
                    WriteHistory(t.name, machineId, remain, startTime, endTime);
                    Thread.Sleep(1000);
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
            t.taken = true;
            if (!tdb.UpdateTool(t))
                return false;

            return true;
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
            t.taken = false;
            t.lastUpdate = DateTime.Now;
            if (!tdb.UpdateTool(t))
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
                showPages(true);
                
            }
            else
            {
                page = 0;
                showPages(false);
            }
            ToolUpdate();
        }

        private void BtnSystemLogClick(object sender, EventArgs e)
        {
            SystemLogForm logForm = new SystemLogForm();
            logForm.ShowDialog();
        }

        /// <summary>
        /// 將未上傳成功的資料重新上傳
        /// </summary>
        private void TmpDataRestore()
        {
            TempSave save = new TempSave();
            if (File.Exists("Temp\\TempToolData.csv"))
                save.RestoreToolTemp();

            if (File.Exists("Temp\\TempHistoryData.csv"))
                save.RestoreHistoryTemp();

            if (File.Exists("Temp\\TempLogData.csv"))
                save.RestoreSystemLogTemp();
        }

        /// <summary>
        /// 點選上一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastPageClick(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(txtPage.Text);
            int maxPage = Convert.ToInt32(txtMaxPage.Text);

            if (currentPage == 1)
                return;
            currentPage--;
            page = currentPage - 1;
            if (currentPage != maxPage)
            {
                btnNext.Enabled = true;
                btnNext.Image = Properties.Resources.right;
            }

            if (currentPage == 1)
            {
                btnLast.Enabled = false;
                btnLast.Image = Properties.Resources.disableLeft;
            }
            txtPage.Text = currentPage.ToString();
            ToolUpdate();
        }

        /// <summary>
        /// 點選下一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPageClick(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(txtPage.Text);
            int maxPage = Convert.ToInt32(txtMaxPage.Text);

            if (currentPage == maxPage)
                return;
            currentPage++;
            page = currentPage - 1;
            if (currentPage != 1)
            {
                btnLast.Enabled = true;
                btnLast.Image = Properties.Resources.left;
            }

            if(currentPage == maxPage)
            {
                btnNext.Enabled = false;
                btnNext.Image = Properties.Resources.disableRight;
            }
                
            txtPage.Text = currentPage.ToString();
            ToolUpdate();
        }

    }
}