using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class Main : Form
    {
        //資料庫連線設定
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        //List<int> lastDatas = new List<int>(); //預防更新失敗之暫存資料
        List<Grid> tools = new List<Grid>(); //刀具UserController List
        List<int> checkDatas; //觸發警報數值(隨機生成)
        //int updateCount = 0; //更新次數
        int interruptIndex = 0; //更新資料庫失敗中斷點
        bool keepUpdate = true; //持續更新刀具資料
        TableLayoutPanel table = new TableLayoutPanel();
        ToolDatabase tdb = new ToolDatabase();
        bool simulateRun = true;

        //Delegate function
        private delegate void updateGridUI();
        private delegate void deleInitialContent(bool save);

        public Main()
        {
            InitializeComponent();
        }

        private void MainShown(object sender, EventArgs e)
        {
            SetDoubleBuffered(content);
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
            tools = new List<Grid>();
            LoadData(ref tools);
            
            if (save)
            {
                UpdateStatus('0', tools);
            }

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

        private TableLayoutPanel reloadtable(List<Grid> tools)
        {
            TableLayoutPanel newtable = new TableLayoutPanel();
            Point loc = new Point(0, 23);
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].check = checkDatas[i];

                newtable.Controls.Add(tools[i], i % 6, table.RowCount);

                //設定方框位置，每六個換一行
                if ((i + 1) % 6 == 0)
                {
                    newtable.RowCount += 1;
                    newtable.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
                }
            }
            return newtable;
        }

        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private void LoadData(ref List<Grid> tools)
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
                Grid g = new Grid
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
                    tools[i].tool.alarm = toolData[i].alarm;
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
        /// 更新狀態
        /// </summary>
        /// <param name="start"></param>
        /// <param name="tools"></param>
        private void UpdateStatus(char start, List<Grid> tools)
        {
            
            try {
                while (interruptIndex < tools.Count) 
                { 
                    if (!tdb.UpdateTool(tools[interruptIndex].tool))
                    {
                        MessageBox.Show("儲存發生錯誤，請進行重新上傳");
                        btnReupload.Visible = true;
                        btnRun.Enabled = false;
                        throw new Exception("儲存失敗");
                    }
                        
                    if (!tdb.HistoryInsert(tools[interruptIndex].tool, start))
                    {
                        MessageBox.Show("儲存發生錯誤，請進行重新上傳");
                        btnReupload.Visible = true;
                        btnRun.Enabled = false;
                        throw new Exception("儲存失敗");
                    }
                    interruptIndex++;
                }
                interruptIndex = 0;
                btnReupload.Visible = false;
                btnRun.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存發生錯誤，請進行重新上傳：" + ex.Message);
                btnReupload.Visible = true;
                btnRun.Enabled = false;
            }
        }

        /// <summary>
        /// 重新上傳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReuploadClick(object sender, EventArgs e)
        {
            UpdateStatus('0', tools);
        }

        /// <summary>
        /// 重新設定刀具庫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClick(object sender, EventArgs e)
        {
            Reset reset = new Reset();
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
                    Tool data = new Tool
                    {
                        name = "I" + i,
                        life = randLife,
                        remain = randLife,
                        alarm = true
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
                            query = @"INSERT INTO tool(id, name, life, remain, alarm) VALUES (@id, @name, @life, @remain, @alarm)";
                            using (SqlCommand comm = new SqlCommand(query, conn))
                            {
                                comm.Parameters.AddWithValue("@id", insertCount);
                                comm.Parameters.AddWithValue("@name", data.name);
                                comm.Parameters.AddWithValue("@life", data.life);
                                comm.Parameters.AddWithValue("@remain", data.remain);
                                comm.Parameters.AddWithValue("@alarm", 0);
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
            picNew.Visible = false;
        }


        /// <summary>
        /// 確認資料庫內是否有同樣資料存在
        /// </summary>
        /// <param name="t">刀具資料</param>
        private bool SendData(Tool t)
        {
            Tool originData = new Tool();
            bool check = tdb.GetToolByName(t.name, ref originData);
            try
            {
                if (check)
                {
                    check = tdb.ChangeTool(t);
                    //執行換刀

                    if (check)
                    {
                        //新增換刀歷程
                        tdb.HistoryInsert(originData, '2');
                        tdb.HistoryInsert(t, '3');
                        return true;
                    }
                }
                else
                {
                    //insert data
                    if (tdb.InsertTool(t))
                    {
                        Tool newTool = new Tool();
                        tdb.GetToolByName(t.name, ref newTool);
                        tdb.HistoryInsert(newTool, '1');
                        return true;
                    }
                }
            }catch(SqlException ex)
            {
                MessageBox.Show("資料庫發生問題" + ex.Message);
            }catch(Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            return false;
        }


        /// <summary>
        /// 新增刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTool(object sender, EventArgs e)
        {
            NewTool newTool = new NewTool();
            newTool.ShowDialog();
            if (newTool.hasNew)
            {
                Grid g = new Grid
                {
                    tool = newTool.tool
                };
                if (tools.Count % 6 == 0)
                {
                    table.RowCount += 1;
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
                }
                table.Controls.Add(g, tools.Count % 6, table.RowCount);
                tools.Add(g);
                //lastDatas.Add(newTool.tool.remain);
                Random randNum = new Random(); //隨機檢查數值
                checkDatas.Add(randNum.Next(0, 49));
            }
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;
            PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        private void simulate()
        {
            while (simulateRun)
            {
                Random rand = new Random();
                int randNum = rand.Next(0, tools.Count);
                Tool randTool = tools[randNum].tool;
                UseTool(randTool.name);
                Thread.Sleep(3000);

                ReturnTool(randTool.name, 3);
            }
        }

        private void UseTool(string name)
        {
            Tool t = new Tool();
            if(!tdb.GetToolByName(name, ref t))
            {
                return;
            }
            tdb.HistoryInsert(t, '1');
        }

        private void ReturnTool(string name, int decrease)
        {
            Tool t = new Tool();
            if (!tdb.GetToolByName(name, ref t))
            {
                return;
            }
            t.remain -= decrease;

            if (!tdb.UpdateTool(t))
            {
                return;
            }

            tdb.HistoryInsert(t, '2');
        }

        private void BtnHistoryClick(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
        }
    }
}