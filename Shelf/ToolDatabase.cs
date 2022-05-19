using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shelf
{
    class ToolDatabase
    {
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        public bool GetAllTool(ref List<Tool> tools)
        {
            var query = "SELECT id, name, life, remain, alarm FROM tool";
            try
            {
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
                                    tools.Add(tool);
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

        public bool checkExist(string name)
        {
            string query = "SELECT * FROM tool WHERE name = @name";
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
                                return true;
                            }
                            return false;
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
        /// 給予名稱取得完整的Tool資料
        /// </summary>
        /// <param name="name"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool GetToolByName(string name, ref Tool t)
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
        /// 修改刀具
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool EditTool(string originName, Tool t)
        {
            var queryData = @"UPDATE tool SET name = @name, life = @life, remain = @remain, alarm = @alarm WHERE name = @originName";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        comm.Parameters.AddWithValue("@name", t.name);
                        comm.Parameters.AddWithValue("@life", t.life);
                        comm.Parameters.AddWithValue("@remain", t.remain);
                        comm.Parameters.AddWithValue("@alarm", t.alarm);
                        comm.Parameters.AddWithValue("@originName", originName);
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
        /// 更新tool目前數值及狀態
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool UpdateTool(Tool t)
        {
            var queryData = @"UPDATE tool SET remain = @remain, alarm = @alarm WHERE name = @name";
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
                        comm.Parameters.AddWithValue("@name", t.name);
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
        public bool ChangeTool(Tool t)
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
        public bool InsertTool(Tool t)
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

        public bool GetLastHistory(ref Tool t)
        {
            var query = @"SELECT TOP(1) * FROM history WHERE name = @name DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        comm.Parameters.AddWithValue("@name", t.name);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    t.startTime = DateTime.Parse(data["startTime"].ToString());
                                    t.endTime = DateTime.Parse(data["endTime"].ToString());
                                };

                                return true;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            
            return false;
        }

        /// <summary>
        /// 新增歷程
        /// </summary>
        /// <param name="t"></param>
        /// <param name="mark">0:軟體開啟紀錄, 1:取出刀具, 2:放回刀具, 3:執行換刀, 4:新增刀具, 5:刀具修改, 6: 刀具刪除, 7: 機台錯誤</param>>
        /// <returns></returns>
        public bool InsertHistory(Tool t, char mark)
        {
            if(mark == 1)
            {
                if (!UseToolHistory(t))
                    return false;
                return true;
            }
            if(mark == 2)
            {
                if (!ReturnToolHistory(t))
                    return false;
                return true;
            }
            if(mark == 3)
            {
                
            }
            var query = @"INSERT INTO history(name, life, remain, alarm, mark) VALUES( @name, @life, @remain, @alarm, @mark)";
            
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
                MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }

            return true;
        }

        /// <summary>
        /// 新增使用刀具歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool UseToolHistory(Tool t)
        {

            var query = @"INSERT INTO history(name, life, remain, alarm, startTime, mark) VALUES( @name, @life, @remain, @alarm, @startTime, @mark)";
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
                        comm.Parameters.AddWithValue("@alarm", t.alarm);
                        comm.Parameters.AddWithValue("@startTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@mark", '1');

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
                MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 新增結束刀具歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool ReturnToolHistory(Tool t)
        {
            var query = @"INSERT INTO history(name, life, remain, alarm, startTime, endTime, mark) VALUES( @name, @life, @remain, @alarm, @startTime, @endTime, @mark)";
            if (!GetLastHistory(ref t))
                return false;
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
                        comm.Parameters.AddWithValue("@alarm", t.alarm);
                        comm.Parameters.AddWithValue("@startTime", t.startTime);
                        comm.Parameters.AddWithValue("@endTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@mark", '2');

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
                MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤" + ex.Message);
            }
            return false;
        }

        private bool ChangeToolHistory(Tool t)
        {
            if (!GetLastHistory(ref t))
                return false;
           if(t.startTime == null)
           {

           }
        }

        /// <summary>
        /// 刪除刀具
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool DeleteTool(string name)
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
