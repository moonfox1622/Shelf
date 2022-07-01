using Shelf.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        private bool restoring = false;
        
        //Delegate function
        private delegate void updateGridUI();

        
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        } 

        private void MainShown(object sender, EventArgs e)
        {
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

            if (!LoadData(ref tools, machine.Id, page))
                return;

            txtMachineName.Text = machine.Name;
            Bitmap picture = (Bitmap)Properties.Resources.ResourceManager.GetObject(machine.Picture);
            picMachine.Image = picture;
            for (int i = 0; i < tools.Count; i++)
            {
                table.Controls.Add(tools[i]);
                if (i % 6 == 0)
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 140));

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
            if (!tdb.GetToolByPage(ref toolsData, machineId, page, 36))
            {
                return false;
            }

            for(int i=0 ; i<toolsData.Count ; i++)
            {
                //讀取中斷資料
                Tool t = toolsData[i];
                ToolHistory h = new ToolHistory { Name = t.Name };
                tdb.GetLastHistory(ref h);
                t.StartTime = h.StartTime;
                t.EndTime = h.endTime;

                GridUserControl g = new GridUserControl
                {
                    tool = t
                };
                tools.Add(g);
            }
            for(int i = toolsData.Count; i < 36; i++)
            {
                tools.Add(new GridUserControl());
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
            table.RowCount = 6;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
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
                txtMachineName.Text = machine.Name;
                Bitmap picture = (Bitmap)Properties.Resources.ResourceManager.GetObject(machine.Picture);
                picMachine.Image = picture;
                if (!tdb.GetToolByPage(ref toolData, machine.Id, page, 36))
                    return;

                int toolsCount = TableCellShowCount(table);


                //若讀取資料比原來的多，多顯示 n 個GridUserControl
                if (toolData.Count > toolsCount)
                {
                    for (int i = toolsCount; i <= (toolData.Count - 1); i++)
                    {
                        table.GetControlFromPosition(i % 6, i / 6).Visible = true;

                    }
                }

                //若讀取資料比原來的少，隱藏 n 個GridUserControl
                if (toolData.Count < toolsCount)
                {
                    for (int i = toolsCount - 1; i > (toolData.Count - 1); i--)
                    {
                        table.GetControlFromPosition(i % 6, i / 6).Visible = false;
                    }
                }

                for (int i = 0; i < toolData.Count; i++)
                {
                    tools[i].tool = toolData[i];
                    tools[i].CheckStatus();
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
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
                    tdb.GetToolByMachineId(ref tList, m.Id);

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
                int num = tdb.GetToolCountByMachine(machine.Id);
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
                if (maxPage == 0 || maxPage == page+1)
                {
                    btnNext.Image = Properties.Resources.disableRight;
                    btnNext.Enabled = false;
                    txtPage.Text = maxPage.ToString();
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
                            comm.Parameters.AddWithValue("@machineId", machine.Id);
                            comm.ExecuteNonQuery();
                        }

                        query = @"SELECT MAX(id) as id FROM tool";
                        int maxId = 0;
                        using (SqlCommand comm = new SqlCommand(query, conn))
                        {
                            comm.Parameters.AddWithValue("@machineId", machine.Id);
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
                                Id = maxId + i,
                                Name = "T" + i,
                                Life = randLife,
                                Remain = randLife,
                                Warning = randAlarm
                            };
                            newDatas.Add(data);
                        }

                        foreach (Tool data in newDatas)
                        {
                            query = @"INSERT INTO tool(id, name, life, remain, warning, machineId) VALUES (@id, @name, @life, @remain, @warning, @machineId)";
                            using (SqlCommand comm = new SqlCommand(query, conn))
                            {
                                comm.Parameters.AddWithValue("@id", data.Id);
                                comm.Parameters.AddWithValue("@name", data.Name);
                                comm.Parameters.AddWithValue("@life", data.Life);
                                comm.Parameters.AddWithValue("@remain", data.Life);
                                comm.Parameters.AddWithValue("@warning", data.Warning);
                                comm.Parameters.AddWithValue("@machineId", machine.Id);
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
                int machineId = rand.Next(mList[0].Id, mList.Count);
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
                        if (tools[j].Id == allToolList[randNum].Id)
                        {
                            tools.RemoveAt(j);
                            tools.Add(allToolList[randNum]);
                            add = false;
                            break;
                        }
                    }
                    if (add)
                        tools.Add(allToolList[randNum]);
                    Machine m = new Machine();
                    tdb.GetMachineById(ref m, allToolList[randNum].MachineId);
                    UseTool(allToolList[randNum].Name, m.Name);
                    Thread.Sleep(5000);
                }
                DateTime endTime = DateTime.Now;
                foreach (Tool t in tools)
                {
                    int decrease = rand.Next(3, 6);
                    int remain = t.Remain - decrease;
                    if (remain <= 0)
                        remain = 0;
                    WriteHistory(t.Name, machineId, remain, startTime, endTime);
                }
            }
        }

        /// <summary>
        /// 使用刀具
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool UseTool(string name, string machineName)
        {
            Tool t = new Tool ();
            Machine m = new Machine();

            if(!tdb.GetMachineByName(ref m, machineName))
            {
                MessageBox.Show("該機台不存在");
                return false;
            }
            

            if (!tdb.GetToolByName(name, m.Id, ref t))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }

            tdb.UnuseTool(m.Id);

            t.LastUpdate = DateTime.Now;
            t.Taken = true;

            if (!tdb.IsDatabaseConnected())
            {
                TempSave save = new TempSave();
                save.SaveTempToolUpdate(t);
                if (!restoring)
                {
                    restoring = true;
                    Thread restoreThread = new Thread(RestoreTmpData);
                    restoreThread.Start();
                }
                return true;
            }

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
            Thread.Sleep(100);
            Tool t = new Tool();
            if (!tdb.GetToolByName(name, machineId, ref t))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }

            if(startTime > endTime)
            {
                MessageBox.Show("開始時間應該小於結束時間");
                return false;
            }

            if (!tdb.IsDatabaseConnected())
            {
                TempSave save = new TempSave();
                save.SaveTempWriteHistoryData(name, machineId, remain, startTime, endTime);
                if (!restoring)
                {
                    restoring = true;
                    Thread restoreThread = new Thread(RestoreTmpData);
                    restoreThread.Start();
                }
                return true;
            }

            int beforeUseLife = t.Remain;
            t.Remain = remain;

            ToolHistory h = new ToolHistory
            {
                ToolId = t.Id,
                Name = t.Name,
                BeforeUseLife = beforeUseLife,
                AfterUseLife = t.Remain,
                Warning = t.Warning,
                StartTime = startTime,
                endTime = endTime,
                Mark = '1',
                CreateTime = DateTime.Now
            };
            //t.Taken = true;
            t.LastUpdate = DateTime.Now;

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
            dashboard.machine = machine;

            dashboard.ShowDialog();
            carouselSpeed = dashboard.carouselSpeed;
            if(carouselSpeed == 0)
            {
                machine = dashboard.machine;
                showPages(true);
                
            }
            else
            {
                page = 0;
                showPages(false);
            }
            ToolUpdate();
        }

        /// <summary>
        /// 系統紀錄頁面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSystemLogClick(object sender, EventArgs e)
        {
            SystemLogForm logForm = new SystemLogForm();
            logForm.ShowDialog();
        }


        /// <summary>
        /// 切換上一頁刀具
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
        /// 切換下一頁刀具
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

        /// <summary>
        /// 嘗試將暫存資料存入資料庫
        /// </summary>
        private void RestoreTmpData()
        {
            while (true)
            {
                if (tdb.IsDatabaseConnected())
                {
                    TempSave save = new TempSave();
                    if (File.Exists("Temp\\TempToolUseData.csv"))
                        save.RestoreToolTemp();

                    if (File.Exists("Temp\\TempWriteHistoryData.csv"))
                        save.RestoreWriteHistoryData();

                    if (File.Exists("Temp\\TempLogData.csv"))
                        save.RestoreSystemLogTemp();
                    restoring = false;
                    break;
                }
                Thread.Sleep(5000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.ShowDialog();
        }
    }
}