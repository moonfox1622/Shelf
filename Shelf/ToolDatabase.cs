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

        /// <summary>
        /// 取得所有刀具
        /// </summary>
        /// <param name="tools"></param>
        /// <returns></returns>
        public bool GetAllTool(ref List<Tool> tools)
        {
            var query = "SELECT id, name, life, remain, warning FROM tool";
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
                                        warning = int.Parse(data["warning"].ToString())
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
        /// 取得所有歷史資料
        /// </summary>
        /// <param name="histories"></param>
        /// <returns></returns>
        public bool GetAllHistory(ref List<ToolHistory> histories)
        {
            var query = "SELECT id, toolId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark, dateTime FROM history WHERE mark != '0'";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (!data.HasRows)
                            {
                                return false;
                            }
                            while (data.Read())
                            {
                                ToolHistory history = new ToolHistory
                                {
                                    toolId = Convert.ToInt32(data["toolId"].ToString()),
                                    name = data["name"].ToString(),
                                    beforeUseLife = Convert.ToInt32(data["beforeUseLife"].ToString()),
                                    afterUseLife = Convert.ToInt32(data["afterUseLife"].ToString()),
                                    warning = Convert.ToInt32(data["warning"].ToString()),
                                    mark = Convert.ToChar(data["mark"].ToString()),
                                    dateTime = Convert.ToDateTime(data["dateTime"].ToString())

                                };
                                if (!string.IsNullOrWhiteSpace(data["startTime"].ToString()))
                                    history.startTime = Convert.ToDateTime(data["startTime"].ToString());
                                if (!string.IsNullOrWhiteSpace(data["endTime"].ToString()))
                                    history.endTime = Convert.ToDateTime(data["endTime"].ToString());
                                histories.Add(history);
                            }
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
        /// 根據條件取得歷史資料
        /// </summary>
        /// <param name="startTime">搜尋起始日期</param>
        /// <param name="endTime">搜尋結束日期</param>
        /// <param name="warning">只選出異常狀態</param>
        /// <returns></returns>
        public bool GetHistory(ref List<ToolHistory> histories, DateTime startTime, DateTime endTime, bool isWarning)
        {
            string query = "SELECT * FROM history WHERE dateTime >= @startTime AND dateTime <= @endTime";
            if (isWarning)
                query += " AND afterUseLife <= warning";
            query += " ORDER BY toolId asc, dateTime desc";


            try
            {
                using(SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@startTime", startTime.ToString("yyyy-MM-dd 00:00:00"));
                        comm.Parameters.AddWithValue("@endTime", endTime.ToString("yyyy-MM-dd 23:59:59"));
                        using(SqlDataReader data = comm.ExecuteReader())
                        {
                            if (!data.HasRows)
                                return false;

                            while (data.Read())
                            {
                                ToolHistory h = new ToolHistory
                                {
                                    toolId = Convert.ToInt32(data["toolId"].ToString()),
                                    name = data["name"].ToString(),
                                    beforeUseLife = Convert.ToInt32(data["beforeUseLife"].ToString()),
                                    afterUseLife = Convert.ToInt32(data["afterUseLife"].ToString()),
                                    warning = Convert.ToInt32(data["warning"].ToString()),
                                    mark = Convert.ToChar(data["mark"].ToString()),
                                    startTime = Convert.ToDateTime(data["startTime"].ToString()),
                                    endTime = Convert.ToDateTime(data["endTime"].ToString()),
                                    dateTime = Convert.ToDateTime(data["dateTime"].ToString())
                                };
                                histories.Add(h);
                            }
                            return true;
                        }
                    }
                }
            }catch (SqlException ex)
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
        /// 檢查重複名稱
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckRepeatName(int id, string name)
        {
            string query = "SELECT * FROM tool WHERE name = @name AND id != @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", name);
                        comm.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
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
        /// 給予ID取得完整的Tool資料
        /// </summary>
        /// <param name="name"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool GetToolById(int id, ref Tool t)
        {
            string query = @"SELECT * FROM tool WHERE id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@id", id);
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
                                        warning = int.Parse(data["warning"].ToString())
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
                                        warning = int.Parse(data["warning"].ToString())
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
        public bool EditTool(Tool t)
        {
            var queryData = @"UPDATE tool SET life = @life, remain = @remain, warning = @warning WHERE name = @name";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        comm.Parameters.AddWithValue("@life", t.life);
                        comm.Parameters.AddWithValue("@remain", t.remain);
                        comm.Parameters.AddWithValue("@warning", t.warning);
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
        /// 更新tool目前數值及狀態
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool UpdateTool(Tool t)
        {
            var queryData = @"UPDATE tool SET remain = @remain, warning = @warning WHERE name = @name";
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
                        comm.Parameters.AddWithValue("@warning", t.warning);
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
            string query = "UPDATE tool SET life = @life, remain = @remain, warning = 0 WHERE name = @name";
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
            string query = @"INSERT INTO tool(id, name, life, remain, warning) VALUES(" + maxId + "+1, @name, @life, @remain, 0)";
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
            var query = @"SELECT TOP(1) * FROM history WHERE name = @name order by id DESC";

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
                                    if(!string.IsNullOrWhiteSpace(data["startTime"].ToString()))
                                        t.startTime = DateTime.Parse(data["startTime"].ToString());
                                    if (!string.IsNullOrWhiteSpace(data["endTime"].ToString()))
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
        public bool HistoryInsert(Tool t, char mark)
        {
            Tool lastToolStatus = new Tool();
            if(!GetToolById(t.id, ref lastToolStatus))
            {
                MessageBox.Show("該刀具不存在");
                return false;
            }

            ToolHistory history = new ToolHistory
            {
                toolId = t.id,
                name = t.name,
                beforeUseLife = lastToolStatus.life,
                afterUseLife = t.life,
                startTime = t.startTime,
                endTime = t.endTime,
                mark = mark
            };

            if (!HistoryUseTool(history))
                return false;

            return true;
        }

        /// <summary>
        /// 新增使用刀具歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HistoryUseTool(ToolHistory h)
        {
            var query = @"INSERT INTO history(toolId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark) VALUES(@toolId, @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @endTime, @mark)";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@toolId", h.toolId);
                        comm.Parameters.AddWithValue("@name", h.name);
                        comm.Parameters.AddWithValue("@beforeUseLife", h.beforeUseLife);
                        comm.Parameters.AddWithValue("@afterUseLife", h.afterUseLife);
                        comm.Parameters.AddWithValue("@warning", h.warning);
                        comm.Parameters.AddWithValue("@startTime",h.startTime);
                        comm.Parameters.AddWithValue("@endTime", h.endTime);
                        comm.Parameters.AddWithValue("@mark", h.mark);

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
            //SaveHistoryToLocal(, '1');
            return false;
        }

        /// <summary>
        /// 新增結束刀具歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HistoryReturnTool(Tool t)
        {
            var query = @"INSERT INTO history(toolId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark) VALUES(@toolId, @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @endTime, @mark)";
            DateTime endTime = t.endTime;
            try
            {
                if (!GetLastHistory(ref t))
                    throw new Exception();
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@toolId", t.id);
                        comm.Parameters.AddWithValue("@name", t.name);
                        comm.Parameters.AddWithValue("@beforeUseLife", t.life);
                        comm.Parameters.AddWithValue("@afterUseLife", t.remain);
                        comm.Parameters.AddWithValue("@warning", t.warning);
                        comm.Parameters.AddWithValue("@startTime", t.startTime);
                        comm.Parameters.AddWithValue("@endTime", endTime);
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
            t.startTime = t.startTime;
            t.endTime = endTime;
            SaveHistoryToLocal(t, '2');
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="mark"></param>
        private void SaveHistoryToLocal(Tool t, char mark)
        {
            TempSave tempSave = new TempSave();
            //tempSave.SaveTempHistory(t, mark);
        }


        /// <summary>
        /// 新增換刀歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        //private bool HistoryChangeTool(Tool t)
        //{
        //    if (!GetLastHistory(ref t))
        //        return false;
        //    var query = @"INSERT INTO history(name, beforeUseLife, afterUseLife, warning, mark) VALUES( @name, @beforeUseLife, @afterUseLife, @warning,  @mark)";
        //    if (t.startTime != null)
        //        query = @"INSERT INTO history(name, beforeUseLife, afterUseLife, warning, startTime, mark) VALUES( @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @mark)";

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectStr))
        //        {
        //            using (SqlCommand comm = new SqlCommand(query, conn))
        //            {
        //                if (conn.State != ConnectionState.Open)
        //                    conn.Open();
        //                comm.Parameters.AddWithValue("@name", t.name);
        //                comm.Parameters.AddWithValue("@beforeUseLife", t.beforeUseLife);
        //                comm.Parameters.AddWithValue("@afterUseLife", t.afterUseLife);
        //                comm.Parameters.AddWithValue("@warning", t.warning);
        //                if (t.startTime != null)
        //                    comm.Parameters.AddWithValue("@startTime", t.startTime);
        //                comm.Parameters.AddWithValue("@mark", '3');

        //                int affectRows = comm.ExecuteNonQuery();
        //                if (affectRows > 0)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("發生錯誤" + ex.Message);
        //    }
        //    return false;
        //}

        //private bool HistoryMachineError(Tool t)
        //{
        //    if (!GetLastHistory(ref t))
        //        return false;
        //    var query = @"INSERT INTO history(name, beforeUseLife, afterUseLife, warning, mark) VALUES( @name, @beforeUseLife, @afterUseLife, @warning,  @mark)";
        //    if (t.startTime == null)
        //        return false;
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectStr))
        //        {
        //            using (SqlCommand comm = new SqlCommand(query, conn))
        //            {
        //                if (conn.State != ConnectionState.Open)
        //                    conn.Open();
        //                comm.Parameters.AddWithValue("@name", t.name);
        //                comm.Parameters.AddWithValue("@beforeUseLife", t.beforeUseLife);
        //                comm.Parameters.AddWithValue("@afterUseLife", t.afterUseLife);
        //                comm.Parameters.AddWithValue("@warning", t.warning);
        //                if (t.startTime != null)
        //                    comm.Parameters.AddWithValue("@startTime", t.startTime);
        //                comm.Parameters.AddWithValue("@mark", '2');

        //                int affectRows = comm.ExecuteNonQuery();
        //                if (affectRows > 0)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("新增歷史紀錄時資料庫處理發生錯誤" + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("發生錯誤" + ex.Message);
        //    }
        //    return false;
        //}

        /// <summary>
        /// 新增歷程 包含(0:軟體開啟紀錄 4:新增刀具, 5:刀具修改, 6: 刀具刪除)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        private bool OtherTypeHistory(Tool t, char mark)
        {
            GetLastHistory(ref t);
            var query = @"INSERT INTO history(toolId, name, beforeUseLife, afterUseLife, warning, mark) VALUES(@toolId, @name, @beforeUseLife, @afterUseLife, @warning,  @mark)";
            if (t.startTime != null)
                query = @"INSERT INTO history(toolId, name, beforeUseLife, afterUseLife, warning, startTime, mark) VALUES( @toolId, @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @mark)";
            if(t.endTime != null)
                query = @"INSERT INTO history(toolId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark) VALUES( @toolId, @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @endTime, @mark)";
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
                        comm.Parameters.AddWithValue("@beforeUseLife", t.life);
                        comm.Parameters.AddWithValue("@afterUseLife", t.remain);
                        comm.Parameters.AddWithValue("@warning", t.warning);
                        if (t.startTime != null)
                            comm.Parameters.AddWithValue("@startTime", t.startTime);
                        if(t.endTime != null)
                            comm.Parameters.AddWithValue("@endTime", t.endTime);
                        comm.Parameters.AddWithValue("@mark", mark);

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

        /// <summary>
        /// 確認資料庫連線
        /// </summary>
        /// <returns></returns>
        public bool IsDatabaseConnected()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    conn.Open();
                    return true;
                }
            }catch (SqlException e)
            {
                return false;
            }
            
        }

    }
}
