using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class Main : Form
    {
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        List<int> lastDatas = new List<int>(); 
        List<Grid> datas = new List<Grid>();
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

        private void initalContent()
        {
            content.Controls.Clear();
            datas = new List<Grid>();
            LoadData(ref datas, ref lastDatas);
            UploadHistory(true, datas);

            Random randNum = new Random();
            checkDatas = Enumerable
                .Repeat(0, datas.Count)
                .Select(i => randNum.Next(0, 49))
                .ToArray();
            Point loc = new Point(23, 23);
            for (int i = 0; i < datas.Count; i++)
            {
                datas[i].check = checkDatas[i];
                datas[i].Location = loc;
                content.Controls.Add(datas[i]);
                //設定方框位置，每六個換一行
                if ((i + 1) % 6 == 0)
                {
                    loc.X = 23;
                    loc.Y += datas[i].Height + 40;
                }
                else
                {
                    loc.X += datas[i].Width + 32;
                }
            }
        }

        private List<Grid> LoadData(ref List<Grid> datas, ref List<int> lastDatas)
        {
            var query = "SELECT TRIM(name) as name, count, alarm FROM data";
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
                                Grid d = new Grid
                                {
                                    name = data["name"].ToString(),
                                    count = int.Parse(data["count"].ToString()),
                                    alarm = bool.Parse(data["alarm"].ToString())
                                };

                                datas.Add(d);
                                lastDatas.Add(int.Parse(data["count"].ToString()));
                            }
                        }
                    }
                }
            }
            return datas;
        }

        

        private void BtnRunClick(object sender, EventArgs e)
        {
            updateCount++;
            for(int i = 0; i < datas.Count; i++)
            {
                lastDatas.Add(datas[i].count);
                datas[i].count -= 3 * updateCount;
                if(datas[i].count <= checkDatas[i])
                {
                    datas[i].alarm = true;
                }
                datas[i].CheckStatus();
            }
            UploadHistory(false, datas);
        }

        private void UploadHistory(bool start, List<Grid> datas)
        {
            var query = @"INSERT INTO history(name, count, alarm, mark) VALUES(@name, @count, @alarm, @mark)";

            try{
                for (int i = interruptIndex; i < datas.Count; i++)
                {
                    string name = datas[i].name;
                    //if (i == 5) name = null;
                    interruptIndex = i;
                    using (SqlConnection conn = new SqlConnection(_connectStr))
                    {
                        using (SqlCommand comm = new SqlCommand(query, conn))
                        {
                            if (conn.State != ConnectionState.Open)
                                conn.Open();
                            comm.Parameters.AddWithValue("@name", name);
                            comm.Parameters.AddWithValue("@count", datas[i].count);
                            comm.Parameters.AddWithValue("@alarm", datas[i].alarm);
                            comm.Parameters.AddWithValue("@mark", start);

                            int affectRows = comm.ExecuteNonQuery();
                            if (affectRows == 0)
                            {
                                
                                MessageBox.Show("儲存發生錯誤，請進行重新上傳");
                                btnReupload.Visible = true;
                                btnRun.Enabled = false;
                                break;
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

        private void BtnReuploadClick(object sender, EventArgs e)
        {
            UploadHistory(false, datas);
        }

        
        private void BtnResetClick(object sender, EventArgs e)
        {
            Reset reset = new Reset();
            reset.ShowDialog();
            if (reset.resetCount != 0)
            {
                int insertCount = 0;
                List<Data> newDatas = new List<Data>();
                Random randNum = new Random();
                for (int i = 0; i < reset.resetCount; i++)
                {
                    Data data = new Data
                    {
                        name = "I" + i,
                        count = randNum.Next(80, 100),
                        alarm = true
                    };
                    newDatas.Add(data);
                }
                var query = @"DELETE FROM data";
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

                        foreach (Data data in newDatas)
                        {
                            query = @"INSERT INTO data(name, count, alarm) VALUES (@name, @count, @alarm)";
                            using (SqlCommand comm = new SqlCommand(query, conn))
                            {
                                comm.Parameters.AddWithValue("@name", data.name);
                                comm.Parameters.AddWithValue("@count", data.count);
                                comm.Parameters.AddWithValue("@alarm", data.alarm);
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