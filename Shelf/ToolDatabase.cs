using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Shelf.Model;
using System.Configuration;

namespace Shelf
{
    class ToolDatabase
    {
        //private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定
        private readonly string _connectStr = ConfigurationManager.ConnectionStrings["ShelfDBConnection"].ConnectionString;

        /// <summary>
        /// 取得所有機台
        /// </summary>
        /// <param name="machines"></param>
        /// <returns></returns>
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
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        Name = data["name"].ToString(),
                                        Describe = data["describe"].ToString(),
                                        Picture = data["picture"].ToString()
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

        /// <summary>
        /// 以機台名稱取得機台資料
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public bool GetMachineByName(ref Machine machine, string machineName)
        {
            string query = "SELECT * FROM machine WHERE name = @name";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        comm.Parameters.AddWithValue("@name", machineName);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    machine = new Machine
                                    {
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        Name = data["name"].ToString(),
                                        Describe = data["describe"].ToString(),
                                        Picture = data["picture"].ToString()
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
        /// 以機台ID取得機台資料
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="machineId"></param>
        /// <returns></returns>
        public bool GetMachineById(ref Machine machine, int machineId)
        {
            string query = "SELECT * FROM machine WHERE id = @machineId";
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
                                    machine = new Machine
                                    {
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        Name = data["name"].ToString(),
                                        Describe = data["describe"].ToString(),
                                        Picture = data["picture"].ToString()
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
        /// 依分頁取得刀具
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="machineId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public bool GetToolByPage(ref List<Tool> tools, int machineId, int page, int num)
        {
            int start = page * num;
            int end = start + num;

            var query = "SELECT id, machineId, name, life, remain, warning, taken, lastUpdate FROM tool WHERE machineId = @machineId ORDER BY taken DESC, lastUpdate DESC";
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
                                List<Tool> allTools = new List<Tool>();
                                while (data.Read())
                                {
                                    Tool t = new Tool
                                    {
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        MachineId = Convert.ToInt32(data["machineId"].ToString()),
                                        Name = data["name"].ToString(),
                                        Life = Convert.ToInt32(data["life"].ToString()),
                                        Remain = Convert.ToInt32(data["remain"].ToString()),
                                        Warning = Convert.ToInt32(data["warning"].ToString()),
                                        Taken = Convert.ToBoolean(data["taken"].ToString()),
                                        LastUpdate = Convert.ToDateTime(data["lastUpdate"].ToString())
                                    };
                                    allTools.Add(t);
                                }
                                if (end > allTools.Count)
                                    end = allTools.Count;
                                for(int i = start; i < end; i++)
                                {
                                    tools.Add(allTools[i]);
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
        /// 取得第一台機台
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
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
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        Name = data["name"].ToString(),
                                        Describe = data["describe"].ToString(),
                                        Picture = data["picture"].ToString()
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
            var query = "SELECT id, machineId, name, life, remain, warning, taken, lastUpdate FROM tool WHERE machineId = @machineId ORDER BY id ASC";
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
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        MachineId = Convert.ToInt32(data["machineId"].ToString()),
                                        Name = data["name"].ToString(),
                                        Life = Convert.ToInt32(data["life"].ToString()),
                                        Remain = Convert.ToInt32(data["remain"].ToString()),
                                        Warning = Convert.ToInt32(data["warning"].ToString()),
                                        Taken = Convert.ToBoolean(data["taken"].ToString()),
                                        LastUpdate = data.GetDateTime(data.GetOrdinal("lastUpdate"))
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
        
        public int GetToolCountByMachine(int machineId)
        {
            int num = 0;

            var query = "SELECT COUNT(id) as num FROM tool WHERE machineId = @machineId";
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
                                    num = Convert.ToInt32(data["num"].ToString());
                                }
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
            return num;
        }

        /// <summary>
        /// 檢查刀具是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool checkRepeat(string name, int machineId)
        {
            string query = "SELECT * FROM tool WHERE name = @name AND machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", name);
                        comm.Parameters.AddWithValue("@machineId", machineId);
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
        /// 根據條件取得歷史資料
        /// </summary>
        /// <param name="startTime">搜尋起始日期</param>
        /// <param name="endTime">搜尋結束日期</param>
        /// <param name="isWarning">只選出異常狀態</param>
        /// <returns></returns>
        public bool GetHistory(ref List<ToolHistory> histories, DateTime startTime, DateTime endTime, int machineId, bool isWarning)
        {
            string query = "SELECT * FROM history WHERE createTime >= @startTime AND createTime <= @endTime AND machineId = @machineId";
            if (isWarning)
                query += " AND afterUseLife <= warning";
            query += " ORDER BY createTime asc";


            try
            {
                using(SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@startTime", startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        comm.Parameters.AddWithValue("@endTime", endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
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
                                    MachineId = Convert.ToInt32(data["machineId"].ToString()),
                                    Name = data["name"].ToString(),
                                    BeforeUseLife = Convert.ToInt32(data["beforeUseLife"].ToString()),
                                    AfterUseLife = Convert.ToInt32(data["afterUseLife"].ToString()),
                                    endTime = Convert.ToDateTime(data["endTime"].ToString()),
                                    Warning = Convert.ToInt32(data["warning"].ToString()),
                                    Mark = Convert.ToChar(data["mark"].ToString()),
                                    StartTime = Convert.ToDateTime(data["startTime"].ToString()),
                                    CreateTime = Convert.ToDateTime(data["createTime"])
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


        


        public bool GetLog(ref List<Log> logs, DateTime startTime, DateTime endTime, int machineId)
        {
            string query = "SELECT * FROM log WHERE createTime >= @startTime AND createTime <= @endTime AND machineId = @machineId ORDER BY createTime DESC";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@startTime", startTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        comm.Parameters.AddWithValue("@endTime", endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        comm.Parameters.AddWithValue("@machineId", machineId);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (!data.HasRows)
                                return false;

                            while (data.Read())
                            {
                                Log l = new Log
                                {
                                    Name = data["name"].ToString(),
                                    MachineId = Convert.ToInt32(data["machineId"].ToString()),
                                    Life = Convert.ToInt32(data["life"].ToString()),
                                    Remain = Convert.ToInt32(data["remain"].ToString()),
                                    Warning = Convert.ToInt32(data["warning"].ToString()),
                                    Mark = data["mark"].ToString(),
                                    CreateTime = Convert.ToDateTime(data["createTime"].ToString())
                                };


                                logs.Add(l);
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
        /// 檢查重複名稱
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckRepeatName(int id, string name, int machineId)
        {
            string query = "SELECT * FROM tool WHERE name = @name AND id != @id AND machineId = @machineId";
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
                        comm.Parameters.AddWithValue("@machineId", machineId);
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
        /// 給予名稱取得完整的Tool資料
        /// </summary>
        /// <param name="name"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool GetToolByName(string name, int machineId, ref Tool t)
        {
            string query = @"SELECT * FROM tool WHERE name = @name AND machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", name);
                        comm.Parameters.AddWithValue("@machineId", machineId);
                        using (SqlDataReader data = comm.ExecuteReader())
                        {
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    t = new Tool
                                    {
                                        Id = Convert.ToInt32(data["id"].ToString()),
                                        MachineId = Convert.ToInt32(data["machineId"].ToString()),
                                        Name = data["name"].ToString(),
                                        Life = Convert.ToInt32(data["life"].ToString()),
                                        Remain = Convert.ToInt32(data["remain"].ToString()),
                                        Warning = Convert.ToInt32(data["warning"].ToString()),
                                        Taken = Convert.ToBoolean(data["taken"].ToString()),
                                        LastUpdate = Convert.ToDateTime(data["lastUpdate"].ToString())
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
            var queryData = @"UPDATE tool SET life = @life, remain = @remain, warning = @warning , lastUpdate = @lastUpdate WHERE name = @name AND @machineId = machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        comm.Parameters.AddWithValue("@life", t.Life);
                        comm.Parameters.AddWithValue("@remain", t.Remain);
                        comm.Parameters.AddWithValue("@warning", t.Warning);
                        comm.Parameters.AddWithValue("@lastUpdate", t.LastUpdate);
                        comm.Parameters.AddWithValue("@name", t.Name);
                        comm.Parameters.AddWithValue("@machineId", t.MachineId);
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
            var queryData = @"UPDATE tool SET remain = @remain, taken = @taken, lastUpdate = @lastUpdate WHERE name = @name AND machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES"))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();

                        comm.Parameters.AddWithValue("@remain", t.Remain);
                        comm.Parameters.AddWithValue("@taken", t.Taken);
                        comm.Parameters.AddWithValue("@lastUpdate", t.LastUpdate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        comm.Parameters.AddWithValue("@name", t.Name);
                        comm.Parameters.AddWithValue("@machineId", t.MachineId);
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
        /// 取消其他使用中的刀具
        /// </summary>
        /// <param name="machineId"></param>
        /// <returns></returns>
        public bool UnuseTool(int machineId)
        {
            var queryData = @"UPDATE tool SET taken = 0 WHERE taken = 1 AND machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    //更新 tool data
                    using (SqlCommand comm = new SqlCommand(queryData, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@machineId", machineId);
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
            string query = "UPDATE tool SET remain = @remain WHERE name = @name AND machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@remain", t.Life);
                        comm.Parameters.AddWithValue("@name", t.Name);
                        comm.Parameters.AddWithValue("@machineId", t.MachineId);
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
                        comm.Parameters.AddWithValue("@name", t.Name);
                        comm.Parameters.AddWithValue("@machineId", machineId);
                        comm.Parameters.AddWithValue("@life", t.Life);
                        comm.Parameters.AddWithValue("@remain", t.Remain);
                        comm.Parameters.AddWithValue("@warning", t.Warning);

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
        /// 新增歷史紀錄
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public bool HistoryTool(ToolHistory h)
        {
            string query = "INSERT INTO  history (machineId, name, beforeUseLife, afterUseLife, warning, startTime, endTime, mark, createTime) VALUES (@MachineId, @name, @beforeUseLife, @afterUseLife, @warning, @startTime, @endTime, @mark, @createTime)";
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES"))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@MachineId", h.MachineId);
                        comm.Parameters.AddWithValue("@name", h.Name);
                        comm.Parameters.AddWithValue("@beforeUseLife", h.BeforeUseLife);
                        comm.Parameters.AddWithValue("@afterUseLife", h.AfterUseLife);
                        comm.Parameters.AddWithValue("@warning", h.Warning);
                        comm.Parameters.AddWithValue("@startTime", h.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        comm.Parameters.AddWithValue("@endTime", h.endTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        comm.Parameters.AddWithValue("@mark", h.Mark);
                        comm.Parameters.AddWithValue("@createTime", h.CreateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

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
        /// 新增系統紀錄
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public bool InsertSystemLog(Log l)
        {
            var query = @"INSERT INTO log (name, machineId, life, remain, warning, mark, createTime) VALUES (@name, @machineId, @life, @remain, @warning, @mark, @createTime)";
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        comm.Parameters.AddWithValue("@name", l.Name);
                        comm.Parameters.AddWithValue("@machineId", l.MachineId);
                        comm.Parameters.AddWithValue("@life", l.Life);
                        comm.Parameters.AddWithValue("@remain", l.Remain);
                        comm.Parameters.AddWithValue("@warning", l.Warning);
                        comm.Parameters.AddWithValue("@mark", l.Mark);
                        comm.Parameters.AddWithValue("@createTime", l.CreateTime);

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
        public bool DeleteTool(string name, int machineId)
        {
            string query = "DELETE FROM tool WHERE name = @name AND machineId = @machineId";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectStr))
                {
                    using (SqlCommand comm = new SqlCommand(query, conn))
                    {
                        comm.Parameters.AddWithValue("@name", name);
                        comm.Parameters.AddWithValue("@machineId", machineId);
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
            catch(Exception e)
            {
                return false;
            }
            
        }

    }
}
