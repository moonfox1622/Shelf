using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class Main : Form
    {
        //資料庫連線設定
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        List<int> lastDatas = new List<int>(); //預防更新失敗之暫存資料
        List<Grid> tools = new List<Grid>(); //刀具UserController List
        List<int> checkDatas; //觸發警報數值(隨機生成)
        int updateCount = 0;//更新次數
        int interruptIndex = 0;//更新資料庫失敗中斷點
        TableLayoutPanel table = new TableLayoutPanel();
        ToolDatabase tdb = new ToolDatabase();

        
        public Main()
        {
            InitializeComponent();
        }

        private void MainShown(object sender, EventArgs e)
        {
            initalContent(true);
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="save">紀錄歷史</param>
        /// <param name="edit">設定模式</param>
        private void initalContent(bool save, bool edit)
        {
            content.Controls.Clear();
            tools = new List<Grid>();
            LoadData(ref tools, ref lastDatas);
            if (save)
            {
                UpdateStatus('1', tools);
            }

            TableLayoutPanel table = InitalTablePanel();

            Random randNum = new Random();
            checkDatas = Enumerable
                .Repeat(0, tools.Count)
                .Select(i => randNum.Next(0, 49))
                .ToList();
            Point loc = new Point(0, 23);
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].check = checkDatas[i];
                tools[i].Location = loc;
                
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

        private TableLayoutPanel InitalTablePanel()
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

            return table;
        }

        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private void LoadData(ref List<Grid> tools, ref List<int> lastDatas)
        {
            var query = "SELECT id, name, life, remain, alarm FROM tool";
            using (SqlConnection conn = new SqlConnection(_connectStr))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader data = comm.ExecuteReader())
                    {
                        if (data.HasRows)
                        {
                            while (data.Read())
                            {
                                Tool tool = new Tool
                                {
                                    id = int.Parse(data["id"].ToString()),
                                    name = data["name"].ToString(),
                                    life = int.Parse(data["life"].ToString()),
                                    remain = int.Parse(data["remain"].ToString()),
                                    alarm = bool.Parse(data["alarm"].ToString())
                                };
                                Grid d = new Grid
                                {
                                    tool = tool
                                };

                                tools.Add(d);
                                lastDatas.Add(int.Parse(data["remain"].ToString()));
                            }
                        }
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
            updateCount++;
            Random random = new Random();
            int randIndex = random.Next(0, tools.Count);
            tools[randIndex].tool.remain -= 3 * updateCount;
            if (tools[randIndex].tool.remain <= checkDatas[randIndex])
            {
                tools[randIndex].tool.alarm = true;
            }
            tools[randIndex].CheckStatus();
            Tool t = tools[randIndex].tool;
            tdb.UpdateTool(t);
            tdb.InsertHistory(t, '0');
            //for (int i = 0; i < tools.Count; i++)
            //{
            //    lastDatas.Add(tools[i].tool.remain);
            //    tools[i].tool.remain -= 3 * updateCount;
            //    if (tools[i].tool.remain <= checkDatas[i])
            //    {
            //        tools[i].tool.alarm = true;
            //    }
            //    tools[i].CheckStatus();
            //}
            //UpdateStatus('0', tools);
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
                        
                    if (!tdb.InsertHistory(tools[interruptIndex].tool, start))
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
                updateCount = 0;
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
                    initalContent(true);
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
            initalContent(false);
        }

        /// <summary>
        /// 執行換刀或新增刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            if(btnSetting.Text == "開啟設定")
            {
                foreach (Grid g in tools)
                {
                    g.OpenSetting();
                }
                picNew.Visible = true;
                btnSetting.Text = "關閉設定";
            }
            else
            {
                foreach (Grid g in tools)
                {
                    g.CloseSetting();
                }
                picNew.Visible = false;
                btnSetting.Text = "開啟設定";
            }
            
            //SettingPage settingPage = new SettingPage();
            //content.Controls.Clear();
            //settingPage.Dock = DockStyle.Fill;
            //content.Controls.Add(settingPage);
            //Setting setting = new Setting();
            //setting.ShowDialog();
            //if(setting.tools.Count > 0)
            //{
            //    bool check = true;
            //    foreach (NewData d in setting.datas)
            //    {
            //        Tool t = new Tool
            //        {
            //            name = d.name,
            //            life = d.life,
            //            remain = d.life,
            //            alarm = false
            //        };
            //        check = SendData(t);
            //        if (!check)
            //        {
            //            MessageBox.Show("發生錯誤");
            //            break;
            //        }
            //    }
            //    initalContent(false);
            //    if (check)
            //        MessageBox.Show("上傳完成");
            //}
            //else
            //{
            //    MessageBox.Show("未給予資料");
            //}
            
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
                        tdb.InsertHistory(originData, '2');
                        tdb.InsertHistory(t, '3');
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
                        tdb.InsertHistory(newTool, '1');
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.ShowDialog();
            if (!string.IsNullOrWhiteSpace(delete.name))
            {
                Tool t = new Tool();
                tdb.GetToolByName(delete.name, ref t);
                if (tdb.DeleteTool(delete.name))
                {
                    MessageBox.Show("刪除成功");
                    tdb.InsertHistory(t, '2');
                    initalContent(false);
                }
                else
                {
                    MessageBox.Show("刪除失敗或是該刀具不存在");
                }
            }
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
                lastDatas.Add(newTool.tool.remain);
                Random randNum = new Random(); //隨機檢查數值
                checkDatas.Add(randNum.Next(0, 49));
                g.OpenSetting();
            }

        }

        //以下都為資料庫操作

        /// <summary>
        /// 給予名稱取得完整的Tool資料
        /// </summary>
        /// <param name="name"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool GetToolByName(string name, ref Tool t)
        {
            string query = @"SELECT * FROM tool WHERE name = @name";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", name);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    t = new Tool
                                    {
                                        id = int.Parse(data["id"].ToString()),
                                        name = data["name"].ToString(),
                                        life = int.Parse(data["life"].ToString()),
                                        remain = int.Parse(data["remain"].ToString()),
                                        alarm = bool.Parse(data["alarm"].ToString())
                                    };
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫發生問題" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            
            return false;
        }

        /// <summary>
        /// 更新tool目前數值及狀態
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool UpdateTool(Tool t)
        {
            var queryData = @"UPDATE tool SET remain = @remain, alarm = @alarm WHERE id = @toolId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@remain", t.remain);
                        comm.Parameters.AddWithValue("@alarm", t.alarm);
                        comm.Parameters.AddWithValue("@toolId", t.id);
                        int affectRows = comm.ExecuteNonQuery();
                        if (affectRows > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫發生問題" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }

            return false;
        }

        /// <summary>
        /// 換刀
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool ChangeTool(Tool t)
        {
            string query = "UPDATE tool SET life = @life, remain = @remain, alarm = 0 WHERE name = @name";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@life", t.life);
                        comm.Parameters.AddWithValue("@remain", t.life);
                        comm.Parameters.AddWithValue("@name", t.name);
                        int affectRows = comm.ExecuteNonQuery();
                        if (affectRows > 0)
                        {
                            //Success
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫發生問題" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            //Failed
            return false;
        }

        /// <summary>
        /// 新增 Tool 資料 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool InsertTool(Tool t)
        {
            string maxId = "(SELECT MAX(id) FROM tool)";
            string query = @"INSERT INTO tool(id, name, life, remain, alarm) VALUES(" + maxId + "+1, @name, @life, @remain, 0)";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", t.name);
                        comm.Parameters.AddWithValue("@life", t.life);
                        comm.Parameters.AddWithValue("@remain", t.remain);

                        int affectRows = comm.ExecuteNonQuery();
                        if (affectRows > 0)
                        {
                            //Success
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            //Failed
            return false;
        }

        /// <summary>
        /// 新增歷程
        /// </summary>
        /// <param name="t"></param>
        /// <param name="mark">0:損耗更新, 1:軟體開啟紀錄, 2:刀具移除, 3:執行換刀</param>>
        /// <returns></returns>
        private bool InsertHistory(Tool t, char mark)
        {
            var query = @"INSERT INTO history(toolId, name, life, remain, alarm, mark) VALUES(@toolId, @name, @life, @remain, @alarm, @mark)";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@toolId", t.id);
                        comm.Parameters.AddWithValue("@name", t.name);
                        comm.Parameters.AddWithValue("@life", t.life);
                        comm.Parameters.AddWithValue("@remain", t.remain);
                        comm.Parameters.AddWithValue("@alarm", t.alarm);
                        comm.Parameters.AddWithValue("@mark", mark);

                        int affectRows = comm.ExecuteNonQuery();
                        if (affectRows == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            
            return true;
        }

        /// <summary>
        /// 刪除刀具
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool DeleteTool(string name)
        {
            string query = "DELETE FROM tool WHERE name = @name";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@name", name);
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        int affectRows = comm.ExecuteNonQuery();
                        if (affectRows > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            
            return false;
        }


    }
}