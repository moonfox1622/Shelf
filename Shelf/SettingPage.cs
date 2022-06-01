using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class SettingPage : UserControl
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable toolData = new DataTable();
        private BindingSource bs = new BindingSource();

        public SettingPage()
        {
            InitializeComponent();
        }

        private void SettingPageLoad(object sender, EventArgs e)
        {
            toolData = ToolsDataTable();
            toolData = LoadToolData(toolData);
            GridViewSetting();
        }

        private DataTable ToolsDataTable()
        {
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn();
            dc = new DataColumn();
            dc.ColumnName = "name";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "life";
            dc.DataType = dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "remain";
            dc.DataType = dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "alarm";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "setting";
            dt.Columns.Add(dc);

            return dt;
        }

        private DataTable LoadToolData(DataTable dt)
        {
            List<Tool> tools = new List<Tool>();
            tdb.GetAllTool(ref tools);

            for(int i = 0; i < tools.Count; i++)
            {
                dt.Rows.Add(tools[i].name, tools[i].life, tools[i].remain, tools[i].alarm, "設定");
            }
            return dt;
        }


        /// <summary>
        /// GridView 資料來源及Column設置
        /// </summary>
        public void GridViewSetting()
        {
            bs.DataSource = toolData;
            toolGridView.DataSource = bs;

            //Set column header name
            toolGridView.Columns["name"].HeaderText = "刀具名稱";
            toolGridView.Columns["life"].HeaderText = "最大損耗";
            toolGridView.Columns["remain"].HeaderText = "剩餘損耗";
            toolGridView.Columns["alarm"].HeaderText = "警報狀態";
            toolGridView.Columns["setting"].HeaderText = "設定";

            int width = 110;
            toolGridView.Columns["alarm"].Width = width;
            toolGridView.Columns["setting"].Width = width;
        }

        /// <summary>
        /// GridView 樣式設置
        /// </summary>
        public void GridViewStyle()
        {
            //Set Cell alarm, setting as buttonCell
            foreach (DataGridViewRow row in toolGridView.Rows)
            {
                DataGridViewButtonCell alarmButtonCell = new DataGridViewButtonCell();

                if (row.Cells["alarm"].Value.ToString() == "True")
                {
                    alarmButtonCell.Style.BackColor = Color.FromArgb(216, 30, 91);
                    alarmButtonCell.Style.ForeColor = Color.FromArgb(216, 30, 91);
                    alarmButtonCell.Style.SelectionBackColor = Color.FromArgb(216, 30, 91);
                    alarmButtonCell.Style.SelectionForeColor = Color.FromArgb(216, 30, 91);
                    alarmButtonCell.FlatStyle = FlatStyle.Popup;

                    row.DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(216, 30, 91);
                }
                else
                {
                    alarmButtonCell.Style.BackColor = Color.FromArgb(89, 201, 165);
                    alarmButtonCell.Style.ForeColor = Color.FromArgb(89, 201, 165);
                    alarmButtonCell.Style.SelectionBackColor = Color.FromArgb(89, 201, 165);
                    alarmButtonCell.Style.SelectionForeColor = Color.FromArgb(89, 201, 165);
                    alarmButtonCell.FlatStyle = FlatStyle.Popup;

                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                row.Cells["alarm"] = alarmButtonCell;
                DataGridViewButtonCell settingButtonCell = new DataGridViewButtonCell();
                settingButtonCell.FlatStyle = FlatStyle.Popup;
                settingButtonCell.Style.BackColor = Color.FromArgb(223, 224, 227);
                settingButtonCell.Style.ForeColor = Color.Black;
                settingButtonCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                settingButtonCell.Style.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
                row.Cells["setting"] = settingButtonCell;
            }

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.FromArgb(241, 241, 241);
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
            cellStyle.SelectionForeColor = Color.Black;
            toolGridView.DefaultCellStyle = cellStyle;
        }

        private void ToolGridViewColumnClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GridViewStyle();
        }

        private void CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (col == 4 && row != -1)
            {
                Setting setting = new Setting
                {
                    name = toolGridView[0, row].Value.ToString()
                };
                setting.ShowDialog();
                if (setting.isDelete)
                {
                    toolGridView.Rows.Remove(toolGridView.Rows[row]);
                    return;
                }
                Tool t = new Tool();
                tdb.GetToolByName(toolGridView[0, row].Value.ToString(), ref t);
                toolGridView.Rows[row].Cells["name"].Value = t.name;
                toolGridView.Rows[row].Cells["life"].Value = t.life;
                toolGridView.Rows[row].Cells["remain"].Value = t.remain;
                toolGridView.Rows[row].Cells["alarm"].Value = t.alarm;
                GridViewStyle();
            }
        }

        private void AddTool(object sender, EventArgs e)
        {
            NewTool newTool = new NewTool();
            newTool.ShowDialog();
            if (newTool.hasNew)
            {
                Tool t = newTool.tool;
                toolData.Rows.Add(t.name, t.life, t.remain, t.alarm, "設定");
                GridViewStyle();
            }
        }
    }
}
