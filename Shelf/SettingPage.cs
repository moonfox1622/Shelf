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
        List<EditGrid> tools = new List<EditGrid>();
        ToolDatabase tdb = new ToolDatabase();
        List<int> lastDatas = new List<int>();
        int[] checkDatas;
        int updateCount = 0;
        int interruptIndex = 0;
        TableLayoutPanel table = new TableLayoutPanel();

        public SettingPage()
        {
            InitializeComponent();
        }

        private void SettingPage_Load(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// 取得刀具資料
        /// </summary>
        /// <param name="tools"></param>
        /// <param name="lastDatas"></param>
        /// <returns></returns>
        private void LoadData(ref List<EditGrid> tools, ref List<int> lastDatas)
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
                                EditGrid ed = new EditGrid
                                {
                                    tool = tool
                                };

                                tools.Add(ed);
                                lastDatas.Add(int.Parse(data["remain"].ToString()));
                            }
                        }
                    }
                }
            }
        }


        
       

        /// <summary>
        /// 開啟修改刀具頁面
        /// </summary>
        /// <param name="row"></param>
        /// <param name="t"></param>
        private void EditTool(DataGridViewCellCollection row, Tool t)
        {
            EditTool setting = new EditTool();
            setting.tool = t;
            setting.ShowDialog();
            if (setting.hasUpdate)
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
    }
}
