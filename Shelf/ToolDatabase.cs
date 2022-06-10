using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    class ToolDatabase
    {
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定

        public bool GetAllMachine(ref List<Machine> machines)
        {
            string query = "SELECT * FROM machine";
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
                                    Machine machine = new Machine
                                    {
                                        id = Convert.ToInt32(data["id"].ToString()),
                                        name = data["name"].ToString()
                                    };
                                    machines.Add(machine);
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

        public bool GetTopMachine(ref Machine machine)
        {
            string query = "SELECT TOP(1) * FROM machine";
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
                                    machine = new Machine
                                    {
                                        id = Convert.ToInt32(data["id"].ToString()),
                                        name = data["name"].ToString()
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
        /// 取得指定機台的所有刀具
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="machineId"></param>
        /// <returns></returns>
        public bool GetToolByMachineId(ref List<Tool> tools, int machineId)
        {
            var query = "SELECT id, name, life, remain, warning, taken, lastUpdate FROM tool WHERE machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        comm.Parameters.AddWithValue("@machineId", machineId);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    Tool tool = new Tool
                                    {
                                        id = Convert.ToInt32(data["id"].ToString()),
                                        name = data["name"].ToString(),
                                        life = Convert.ToInt32(data["life"].ToString()),
                                        remain = Convert.ToInt32(data["remain"].ToString()),
                                        warning = Convert.ToInt32(data["warning"].ToString()),
                                        taken = Convert.ToBoolean(data["taken"].ToString()),
                                        lastUpdate = Convert.ToDateTime(data["lastUpdate"].ToString())
                                    };
                                    tools.Add(tool);
                                }
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
        /// 檢查刀具是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
        /// <param name="isWarning">只選出異常狀態</param>
        /// <returns></returns>
        public bool GetHistory(ref List<ToolHistory> histories, DateTime startTime, DateTime endTime, int machineId, bool isWarning)
        {
            string query = "SELECT * FROM history h LEFT JOIN tool t ON t.id = h.toolId WHERE h.dateTime >= @startTime AND h.dateTime <= @endTime AND t.machineId = @machineId";
            if (isWarning)
                query += " AND h.afterUseLife <= h.warning";
            query += " ORDER BY h.dateTime asc";


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
                        comm.Parameters.AddWithValue("@machineId", machineId);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (!data.HasRows)
                                return false;

                            while (data.Read())
                            {
                                if (string.IsNullOrWhiteSpace(data["endTime"].ToString()))
                                    continue;
                                ToolHistory h = new ToolHistory
                                {
                                    toolId = Convert.ToInt32(data["toolId"].ToString()),
                                    name = data["name"].ToString(),
                                    beforeUseLife = Convert.ToInt32(data["beforeUseLife"].ToString()),
                                    afterUseLife = Convert.ToInt32(data["afterUseLife"].ToString()),
                                    endTime = Convert.ToDateTime(data["endTime"].ToString()),
                                    warning = Convert.ToInt32(data["warning"].ToString()),
                                    mark = Convert.ToChar(data["mark"].ToString()),
                                    startTime = Convert.ToDateTime(data["startTime"].ToString()),
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
                                        id = Convert.ToInt32(data["id"].ToString()),
                                        name = data["name"].ToString(),
                                        life = Convert.ToInt32(data["life"].ToString()),
                                        remain = Convert.ToInt32(data["remain"].ToString()),
                                        warning = Convert.ToInt32(data["warning"].ToString()),
                                        taken = Convert.ToBoolean(data["taken"].ToString()),
                                        lastUpdate = Convert.ToDateTime(data["lastUpdate"].ToString())
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
        public bool GetToolByName(string name, int machineId, ref Tool t)
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
                                        id = Convert.ToInt32(data["id"].ToString()),
                                        name = data["name"].ToString(),
                                        life = Convert.ToInt32(data["life"].ToString()),
                                        remain = Convert.ToInt32(data["remain"].ToString()),
                                        warning = Convert.ToInt32(data["warning"].ToString()),
                                        taken = Convert.ToBoolean(data["taken"].ToString()),
                                        lastUpdate = Convert.ToDateTime(data["lastUpdate"].ToString())
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
        public bool UpdateTool(Tool t, bool taken)
        {
            var queryData = @"UPDATE tool SET remain = @remain, warning = @warning, taken = @taken, lastUpdate = @lastUpdate WHERE name = @name";
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
                        comm.Parameters.AddWithValue("@taken", taken);
                        comm.Parameters.AddWithValue("@lastUpdate", t.lastUpdate.ToString("yyyy-MM-dd HH:mm:ss"));
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

        public bool UnuseTool()
        {
            var queryData = @"UPDATE tool SET taken = 0 WHERE taken = 1";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
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
            string query = "UPDATE tool SET remain = @remain WHERE name = @name";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
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
        public bool InsertTool(Tool t, int machineId)
        {
            string maxId = "(SELECT MAX(id) FROM tool)";
            string query = @"INSERT INTO tool(id, name, machineId, life, remain, warning) VALUES(" + maxId + "+1, @name, @machineId, @life, @remain, @warning)";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", t.name);
                        comm.Parameters.AddWithValue("@machineId", machineId);
                        comm.Parameters.AddWithValue("@life", t.life);
                        comm.Parameters.AddWithValue("@remain", t.remain);
                        comm.Parameters.AddWithValue("@warning", t.warning);

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

        public bool GetLastHistory(ref ToolHistory h)
        {
            var query = @"SELECT TOP(1) * FROM history WHERE name = @name order by id DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        comm.Parameters.AddWithValue("@name", h.name);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    h = new ToolHistory
                                    {
                                        id = Convert.ToInt32(data["id"].ToString()),
                                        toolId = Convert.ToInt32(data["toolId"].ToString()),
                                        name = data["name"].ToString(),
                                        warning = Convert.ToInt32(data["warning"].ToString()),
                                        startTime = Convert.ToDateTime(data["startTime"].ToString()),
                                        mark = Convert.ToChar(data["mark"].ToString()),
                                    };
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

        public bool HistoryTool(ToolHistory h)
        {
            string query = "INSERT INTO  history (toolId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark, dateTime) VALUES (@toolId, @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @endTime, @mark, @dateTime)";
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
                        comm.Parameters.AddWithValue("@startTime", h.startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@endTime", h.endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@mark", h.mark);
                        comm.Parameters.AddWithValue("@dateTime", h.dateTime.ToString("yyyy-MM-dd HH:mm:ss"));

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
        /// 新增使用刀具歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HistoryUseTool(Tool t)
        {
            var query = @"INSERT INTO history(toolId, name, beforeUseLife, warning, startTime, mark) VALUES(@toolId, @name, @beforeUseLife,  @warning, @startTime, @mark)";
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
                        comm.Parameters.AddWithValue("@beforeUseLife", t.remain);
                        comm.Parameters.AddWithValue("@warning", t.warning);
                        comm.Parameters.AddWithValue("@startTime",t.startTime);
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
            //SaveHistoryToLocal(, '1');
            return false;
        }

        /// <summary>
        /// 新增結束刀具歷史
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool HistoryReturnTool(Tool t, DateTime endTime)
        {
            var query = @"UPDATE history SET afterUseLife = @aftereUseLife, endTime = @endTime, dateTime = getdate() WHERE id = @historyId";
            ToolHistory h = new ToolHistory { name = t.name };
            try
            {
                if (!GetLastHistory(ref h))
                    throw new Exception();
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@aftereUseLife", t.remain);
                        comm.Parameters.AddWithValue("@endTime", endTime);
                        comm.Parameters.AddWithValue("@historyId", h.id);

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
            t.endTime = t.endTime;
            SaveHistoryToLocal(t, '2');
            return false;
        }

        public bool HistoryChangeTool(Tool t, int beforeChangeLife)
        {
            var query = @"INSERT INTO history(toolId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark, dateTime) VALUES (@toolId, @name, @beforeUseLife,  @afterUseLife, @warning, @startTime, @endTime, @mark, @dateTime)";
            
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
                        comm.Parameters.AddWithValue("@beforeUseLife", beforeChangeLife);
                        comm.Parameters.AddWithValue("@afterUseLife", t.life);
                        comm.Parameters.AddWithValue("@warning", t.warning);
                        comm.Parameters.AddWithValue("@startTime", t.startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@endTime", t.endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        comm.Parameters.AddWithValue("@mark", 2);
                        comm.Parameters.AddWithValue("@dateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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
            return true;
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
