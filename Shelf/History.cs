using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shelf
{
    public partial class History : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        public DataTable table = new DataTable();
        public BindingSource bs = new BindingSource();
        public History()
        {
            InitializeComponent();
        }

        private void HistoryShown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            table = CreateColumn(table);
            List<ToolHistory> histories = new List<ToolHistory>();

            if (!tdb.GetAllHistory(ref histories))
            {
                MessageBox.Show("讀取歷史資料失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (ToolHistory th in histories)
            {
                table.Rows.Add(th.id, th.name, th.life, th.remain, th.alarm, th.startTime, th.endTime, th.mark, th.dateTime);
            }
            bs.DataSource = table;
            TableViewStyle();

        }

        private void TableViewStyle()
        {
            tableView.DataSource = bs;
            tableView.Columns["id"].HeaderText = "ID";
            tableView.Columns["name"].HeaderText = "刀具名稱";
            tableView.Columns["life"].HeaderText = "最大損耗";
            tableView.Columns["remain"].HeaderText = "剩餘損耗";
            tableView.Columns["alarm"].HeaderText = "警報狀態";
            tableView.Columns["startTime"].HeaderText = "開始使用時間";
            tableView.Columns["endTime"].HeaderText = "結束使用時間";
            tableView.Columns["mark"].HeaderText = "類別";
            tableView.Columns["dateTime"].HeaderText = "紀錄時間";

            int width = 100;
            tableView.Columns["id"].Width = width;
            tableView.Columns["name"].Width = width;
            tableView.Columns["life"].Width = width;
            tableView.Columns["remain"].Width = width;
            tableView.Columns["alarm"].Width = width;
            tableView.Columns["mark"].Width = width;
            width = (tableView.Width - (width * 6)) / 3;
            tableView.Columns["startTime"].Width = width;
            tableView.Columns["endTime"].Width = width;
            tableView.Columns["dateTime"].Width = width;
        }

        private DataTable CreateColumn(DataTable dt)
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = "id";
            dc.DataType = dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            

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
            dc.DataType = Type.GetType("System.DateTime");
            dc.ColumnName = "startTime";            
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.DateTime");
            dc.ColumnName = "endTime";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Char");
            dc.ColumnName = "mark";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.DateTime");
            dc.ColumnName = "dateTime";
            dt.Columns.Add(dc);

            return dt;
        }

        private void QuickSearch(object sender, EventArgs e)
        {

        }
    }
}
