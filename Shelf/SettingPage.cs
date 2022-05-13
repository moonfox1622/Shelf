using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shelf
{
    public partial class SettingPage : UserControl
    {
        private readonly string _connectStr = @"Data Source = 127.0.0.1; Initial Catalog = Shelf; User ID = MES2014; Password = PMCMES;"; //資料庫連線設定
        List<Tool> tools = new List<Tool>();

        public SettingPage()
        {
            InitializeComponent();
        }

        public void InitalDataTable()
        {
            
        }

        private void SettingPage_Load(object sender, EventArgs e)
        {
            LoadTool();
        }

        public void LoadTool()
        {
            string query = @"SELECT * FROM tool";
            
            using (SqlConnection conn = new SqlConnection(_connectStr))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    using(SqlDataReader data = comm.ExecuteReader())
                    {
                        if (data.HasRows)
                        {
                            while (data.Read())
                            {
                                Tool t = new Tool
                                {
                                    id = int.Parse(data["id"].ToString()),
                                    name = data["name"].ToString(),
                                    life = int.Parse(data["life"].ToString()),
                                    remain = int.Parse(data["remain"].ToString()),
                                    alarm = bool.Parse(data["alarm"].ToString())
                                };
                                tableView.Rows.Add(t.name, t.life, t.remain, t.alarm);
                            }
                        }
                        

                    }
                }
            }
        }

        
    }
}
