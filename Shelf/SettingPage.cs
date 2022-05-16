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

                                //if alarm == False (正常)
                                DataGridViewCell cell = tableView.Rows[tableView.Rows.Count-1].Cells["alarm"];
                                if (cell.Value.ToString() == "False")
                                {
                                    cell.Style.ForeColor = Color.FromArgb(89, 201, 165);
                                    cell.Style.BackColor = Color.FromArgb(89, 201, 165);
                                    cell.Style.SelectionForeColor = Color.FromArgb(89, 201, 165);
                                    cell.Style.SelectionBackColor = Color.FromArgb(89, 201, 165);
                                }
                                else
                                {
                                    cell.Style.ForeColor = Color.FromArgb(216, 30, 91);
                                    cell.Style.BackColor = Color.FromArgb(216, 30, 91);
                                    cell.Style.SelectionForeColor = Color.FromArgb(216, 30, 91);
                                    cell.Style.SelectionBackColor = Color.FromArgb(216, 30, 91);
                                }
                            }
                        }
                        

                    }
                }
            }
        }

        private void TableViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewCellCollection row = tableView.Rows[e.RowIndex].Cells;
            Tool originTool = new Tool
            {
                name = row["name"].Value.ToString(),
                life = int.Parse(row["life"].Value.ToString()),
                remain = int.Parse(row["remain"].Value.ToString()),
                alarm = bool.Parse(row["alarm"].Value.ToString())
            };
            // e.ColumnIndex 4:換刀 5:修改 6:刪除
            if(e.ColumnIndex == 4)
            {

            }
            else if (e.ColumnIndex == 5)
            {
                EditTool(row, originTool);
            }
            else if(e.ColumnIndex == 6)
            {

            }
        }

        /// <summary>
        /// 開啟修改刀具頁面
        /// </summary>
        /// <param name="row"></param>
        /// <param name="t"></param>
        private void EditTool(DataGridViewCellCollection row, Tool t)
        {
            Edit setting = new Edit();
            setting.tool = t;
            setting.ShowDialog();
            if (setting.update)
            {
                row["name"].Value = setting.tool.name;
                row["life"].Value = setting.tool.life;
                row["remain"].Value = setting.tool.remain;
                row["alarm"].Value = setting.tool.alarm;

                if (row["alarm"].Value.ToString() == "False")
                {
                    row["alarm"].Style.ForeColor = Color.FromArgb(89, 201, 165);
                    row["alarm"].Style.BackColor = Color.FromArgb(89, 201, 165);
                    row["alarm"].Style.SelectionForeColor = Color.FromArgb(89, 201, 165);
                    row["alarm"].Style.SelectionBackColor = Color.FromArgb(89, 201, 165);
                }
                else
                {
                    row["alarm"].Style.ForeColor = Color.FromArgb(216, 30, 91);
                    row["alarm"].Style.BackColor = Color.FromArgb(216, 30, 91);
                    row["alarm"].Style.SelectionForeColor = Color.FromArgb(216, 30, 91);
                    row["alarm"].Style.SelectionBackColor = Color.FromArgb(216, 30, 91);
                }
            }
        }

        private void NewTool(object sender, EventArgs e)
        {

        }
    }
}
