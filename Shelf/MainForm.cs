using Shelf.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WinFormAnimation;

namespace Shelf
{
    public partial class MainForm : Form
    {
        //資料庫連線設定
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        TableLayoutPanel table = new TableLayoutPanel();
        List<CircularProgressUserControl> tools = new List<CircularProgressUserControl>(); //刀具UserController List
        ToolDatabase tdb = new ToolDatabase();
        Machine machine = new Machine();
        //genreral setting
        bool keepUpdate = true; //持續更新刀具資料
        int carouselSpeed = 10; //輪播速度 (秒)
        bool simulateRun = true; //模擬程式運行
        int page = 0; //當前頁面
        int toolNumInAPage = 20; //單頁刀具數量
        string sortMode = "lastUpdateDesc";
        private bool restoring = false;
        private bool sidebarExpand = true;
        //Delegate function
        private delegate void updateGridUI();

        //Animate
        Animator2D contentAnimate = new Animator2D();
        Animator sidebarAnimate = new Animator();

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ControlBox = true;
        } 

        private void MainShown(object sender, EventArgs e)
        {
            //顯示第一台機台
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
            tools = new List<CircularProgressUserControl>();
            table = InitialTablePanel();

            //讀取刀具資料
            if (!LoadData(ref tools, machine.Id, page))
                return;

            txtMachineName.Text = machine.Name;
            Bitmap picture = (Bitmap)Properties.Resources.ResourceManager.GetObject(machine.Picture);
            picMachine.Image = picture;
            for (int i = 0; i < tools.Count; i++)
            {
                table.Controls.Add(tools[i]);
                if (i % 5 == 0)
                    table.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            }
            content.Controls.Add(table);
            sortList.Text = "更新時間";
            picSort.Image = Properties.Resources.number_up;
        }

        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="machineId">機台ID</param>
        /// <param name="page">頁數</param>
        /// <returns></returns>
        private bool LoadData(ref List<CircularProgressUserControl> tools, int machineId, int page)
        {
            List<Tool> toolsData = new List<Tool>();
            if (!tdb.GetToolByMachineId(ref toolsData, machineId))
            {
                return false;
            }

            for(int i=(page* toolNumInAPage); i< toolNumInAPage; i++)
            {
                Tool t = toolsData[i];
                
                CircularProgressUserControl g = new CircularProgressUserControl
                {
                    tool = t
                };
                tools.Add(g);
            }
            
            return true;
        }

        /// <summary>
        /// 刀具方框排版設定
        /// </summary>
        /// <returns></returns>
        private TableLayoutPanel InitialTablePanel()
        {
            TableLayoutPanel table = new TableLayoutPanel();
            table.ColumnCount = 5;
            table.RowCount = 4;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));
            table.AutoScroll = false;
            table.Dock = DockStyle.Fill;
            //table.ControlRemoved += TableControlRemoved;
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
        /// <param name="sort">排序依據</param>
        /// <param name="order">asc or desc</param>
        private void ToolUpdate()
        {
            //try
            //{
                List<Tool> toolData = new List<Tool>();
                txtMachineName.Text = machine.Name;
                Bitmap picture = (Bitmap)Properties.Resources.ResourceManager.GetObject(machine.Picture);
                picMachine.Image = picture;
                if (!tdb.GetToolByMachineId(ref toolData, machine.Id))
                    return;
                toolData = SortTools(toolData, sortMode);
                List<Tool> pagedTools = PageTool(toolData, page);
                
                int toolsCount = TableCellShowCount(table);
                //若讀取資料比原來的多，多顯示 n 個GridUserControl
                if (pagedTools.Count > toolsCount)
                {
                    for (int i = toolsCount; i <= (pagedTools.Count - 1); i++)
                    {
                        table.GetControlFromPosition(i % 5, i / 5).Visible = true;
                    }
                }

                //若讀取資料比原來的少，隱藏 n 個GridUserControl
                if (pagedTools.Count < toolsCount)
                {
                    for (int i = toolsCount - 1; i > (pagedTools.Count - 1); i--)
                    {
                        table.GetControlFromPosition(i % 5, i / 5).Visible = false;
                    }
                }

                for (int i = 0; i < pagedTools.Count; i++)
                {
                    tools[i].tool = pagedTools[i];
                    tools[i].CheckStatus();
                }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}
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

        /// <summary>
        /// 顯示分頁
        /// </summary>
        /// <param name="status"></param>
        private void showPages(bool status)
        {
            if (status)
            {
                int num = tdb.GetToolCountByMachine(machine.Id);
                int maxPage = num / toolNumInAPage;
                if (num % toolNumInAPage != 0)
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
                MachineId = t.MachineId,
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

        /// <summary>
        /// 縮放Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClick(object sender, EventArgs e)
        {
            //sidebarTimer.Start();
            
            if (sidebarAnimate.CurrentStatus == AnimatorStatus.Playing || contentAnimate.CurrentStatus == AnimatorStatus.Playing)
                return;
            if (sidebarExpand)
            {
                sidebarExpand = false;
                picMenu.Image = Shelf.Properties.Resources.menu;
                panelContent.Width = 1818;
                content.Width = 1810;
                sidebarAnimate.Paths = new WinFormAnimation.Path(188, 53, 100, AnimationFunctions.Liner).ContinueTo();
                contentAnimate.Paths = new Path2D(202, 71, 12, 12, 300, AnimationFunctions.CubicEaseOut).ContinueTo();
                
            }
            else
            {
                sidebarExpand = true;
                sidebarAnimate.Paths = new WinFormAnimation.Path(53, 188, 100, AnimationFunctions.Liner).ContinueTo();
                contentAnimate.Paths = new Path2D(71, 202, 12, 12, 300, AnimationFunctions.CubicEaseOut).ContinueTo();
                picMenu.Image = Properties.Resources.arrowToLeft;
                panelContent.Width = 1690;
                content.Width = 1682;
            }
            contentAnimate.Play(panelContent, Animator2D.KnownProperties.Location);
            sidebarAnimate.Play(sidebarPanel,"Width");
        }

        /// <summary>
        /// 刀具設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMuiltToolClick(object sender, EventArgs e)
        {
            MuiltToolSettingForm muiltTool = new MuiltToolSettingForm();
            muiltTool.ShowDialog();
        }
        
        /// <summary>
        /// 按下ESC關閉頁面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("確定要關閉嗎?", "關閉程式", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;
                this.Close();
            }
        }

        private List<Tool> PageTool(List<Tool> tools,int page)
        {
            int start = page * toolNumInAPage;
            int end = start + toolNumInAPage;
            if (tools.Count < end)
                end = tools.Count;

            List<Tool> pagedTool = new List<Tool>();
            for(int i = start; i < end; i++)
                pagedTool.Add(tools[i]);

            return pagedTool;
        }

        private List<Tool> SortTools(List<Tool> tools, string sortMode)
        {
            if (sortMode == "natureAsc")
                tools = tools.OrderBy(e => e.Name, new NaturalStringComparer()).ToList();
            else if (sortMode == "natureDesc")
                tools = tools.OrderBy(e => e.Name, new NaturalStringComparerDesc()).ToList();
            else if (sortMode == "lastUpdateAsc")
                tools = tools.OrderBy(e => e.Taken).ThenBy(e => e.LastUpdate).ToList();
            else if (sortMode == "lastUpdateDesc")
                tools = tools.OrderByDescending(e => e.Taken).ThenByDescending(e => e.LastUpdate).ToList();

            return tools;
        }

        /// <summary>
        /// 選擇刀具排版方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortListSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = sortList.SelectedIndex;
            if (index == 0)
            {
                sortMode = "lastUpdateDesc";
                picSort.Image = Properties.Resources.number_up;
            }
            else if(index == 1)
            {
                sortMode = "natureAsc";
                picSort.Image = Properties.Resources.alpha_down;
            }
            ToolUpdate();
        }

        private void PicSortClick(object sender, EventArgs e)
        {
            switch (sortMode)
            {
                case "lastUpdateDesc":
                    sortMode = "lastUpdateAsc";
                    picSort.Image = Properties.Resources.number_down;
                    break;
                case "lastUpdateAsc":
                    sortMode = "lastUpdateDesc";
                    picSort.Image = Properties.Resources.number_up;
                    break;
                case "natureAsc":
                    sortMode = "natureDesc";
                    picSort.Image = Properties.Resources.alpha_up;
                    break;
                case "natureDesc":
                    sortMode = "natureAsc";
                    picSort.Image = Properties.Resources.alpha_down;
                    break;
            }
            ToolUpdate();
        }
    }
}