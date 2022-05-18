using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shelf
{
    class ToolDatabase
    {
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

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

        /// <summary>
        /// 新增歷程 0:損耗更新, 1:軟體開啟紀錄, 2:刀具移除, 3:執行換刀
        /// </summary>
        /// <param name="t"></param>
        /// <param name="mark">0:損耗更新, 1:軟體開啟紀錄, 2:刀具移除, 3:執行換刀</param>>
        /// <returns></returns>
        public bool InsertHistory(Tool t, char mark)
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
                MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
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
