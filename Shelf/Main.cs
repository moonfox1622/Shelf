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
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        List<int> lastDatas = new List<int>(); 
        List<Grid> tools = new List<Grid>();
        int[] checkDatas;
        int updateCount = 0;
        int interruptIndex = 0;

        public Main()
        {
            InitializeComponent();
            
        }

        private void MainShown(object sender, EventArgs e)
        {
            initalContent();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void initalContent()
        {
            content.Controls.Clear();
            tools = new List<Grid>();
            LoadData(ref tools, ref lastDatas);
            UpdateStatus(true, tools);

            Random randNum = new Random();
            checkDatas = Enumerable
                .Repeat(0, tools.Count)
                .Select(i => randNum.Next(0, 49))
                .ToArray();
            Point loc = new Point(0, 23);
            for (int i = 0; i < tools.Count; i++)
            {
                tools[i].check = checkDatas[i];
                tools[i].Location = loc;

                content.Controls.Add(tools[i]);
                //設定方框位置，每六個換一行
                if ((i + 1) % 6 == 0)
                {
                    loc.X = 0;
                    loc.Y += tools[i].Height + 15;
                }
                else
                {
                    loc.X += tools[i].Width + 5;
                }
            }
        }

        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private List<Grid> LoadData(ref List<Grid> tools, ref List<int> lastDatas)
        {
            var query = "SELECT id, TRIM(name) as name, life, remain, alarm FROM tool";
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
            return tools;
        }

        
        /// <summary>
        ///  資料更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRunClick(object sender, EventArgs e)
        {
            updateCount++;
            for(int i = 0; i < tools.Count; i++)
            {
                lastDatas.Add(tools[i].tool.remain);
                tools[i].tool.remain -= 3 * updateCount;
                if(tools[i].tool.remain <= checkDatas[i])
                {
                    tools[i].tool.alarm = true;
                }
                tools[i].CheckStatus();
            }
            UpdateStatus(false, tools);
        }

        /// <summary>
        /// 更新狀態
        /// </summary>
        /// <param name="start"></param>
        /// <param name="tools"></param>
        private void UpdateStatus(bool start, List<Grid> tools)
        {
            var queryHis = @"INSERT INTO history(toolId, name, life, remain, alarm, mark) VALUES(@toolId, @name, @life, @remain, @alarm, @mark)";
            var queryData = @"UPDATE tool SET remain = @remain, alarm = @alarm WHERE id = @toolId";
            
            try{
                for (int i = interruptIndex; i < tools.Count; i++)
                {
                    interruptIndex = i;
                    using (SqlConnection conn = new SqlConnection(_connectStr))
                    {
                        //更新 tool data
                        using (SqlCommand comm = new SqlCommand(queryData, conn))
                        {
                            if(conn.State != ConnectionState.Open)
                                conn.Open();
                            comm.Parameters.AddWithValue("@remain", tools[i].tool.remain);
                            comm.Parameters.AddWithValue("@alarm", tools[i].tool.alarm);
                            comm.Parameters.AddWithValue("@toolId", tools[i].tool.id);
                            int affectRows = comm.ExecuteNonQuery();
                            if (affectRows == 0)
                            {
                                MessageBox.Show("儲存發生錯誤，請進行重新上傳");
                                btnReupload.Visible = true;
                                btnRun.Enabled = false;
                                throw new Exception("儲存失敗");
                            }
                        }

                        //新增歷史資料
                        using (SqlCommand comm = new SqlCommand(queryHis, conn))
                        {
                            comm.Parameters.AddWithValue("@toolId", tools[i].tool.id);
                            comm.Parameters.AddWithValue("@name", tools[i].tool.name);
                            comm.Parameters.AddWithValue("@life", tools[i].tool.life);
                            comm.Parameters.AddWithValue("@remain", tools[i].tool.remain);
                            comm.Parameters.AddWithValue("@alarm", tools[i].tool.alarm);
                            comm.Parameters.AddWithValue("@mark", start);

                            int affectRows = comm.ExecuteNonQuery();
                            if (affectRows == 0)
                            {
                                MessageBox.Show("儲存發生錯誤，請進行重新上傳");
                                btnReupload.Visible = true;
                                btnRun.Enabled = false;
                                throw new Exception("儲存失敗");
                            }
                        }
                    }
                }
                interruptIndex = 0;
                btnReupload.Visible = false;
                btnRun.Enabled = true;
            }
            catch(Exception ex)
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
            UpdateStatus(false, tools);
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
                }catch(SqlException ex)
                {
                    MessageBox.Show("資料庫發生問題，新增失敗：" + ex.Message);
                }catch(Exception ex)
                {
                    MessageBox.Show("新增失敗：" + ex.Message);
                }
                if(insertCount != reset.resetCount)
                {
                    MessageBox.Show("新增過程中發生錯誤，未新增完全");
                }
                else
                {
                    MessageBox.Show("新增成功");
                    initalContent();
                }
            }
            else
            {
                MessageBox.Show("未進行任何改變");
            }

        }
    }
}