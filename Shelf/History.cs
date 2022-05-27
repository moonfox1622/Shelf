using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shelf
{
    public partial class History : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable table = new DataTable();
        private BindingSource bs = new BindingSource();

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
            table = HistoryDataTable();
            List<ToolHistory> histories = new List<ToolHistory>();

            if (!tdb.GetAllHistory(ref histories))
            {
                MessageBox.Show("讀取歷史資料失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (ToolHistory th in histories)
            {
                string mark = "";
                switch (th.mark)
                {
                    case "1":
                        mark = "取出刀具";
                        break;
                    case "2":
                        mark = "放回刀具";
                        break;
                    case "3":
                        mark = "執行換刀";
                        break;
                    case "4":
                        mark = "新增刀具";
                        break;
                    case "5":
                        mark = "刀具修改";
                        break;
                    case "6":
                        mark = "刀具刪除";
                        break;
                    case "7":
                        mark = "機台錯誤";
                        break;
                }

                table.Rows.Add(th.name, th.life, th.remain, th.alarm, th.startTime, th.endTime, mark, th.dateTime);
            }
            bs.DataSource = table;
            TableViewStyle();
            TableMark();
        }

        private void TableMark()
        {
            foreach(DataGridViewRow row in tableView.Rows)
            {
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();

                if (row.Cells["alarm"].Value.ToString() == "True")
                {
                    buttonCell.Style.BackColor = Color.FromArgb(216, 30, 91);
                    buttonCell.Style.ForeColor = Color.FromArgb(216, 30, 91);
                    buttonCell.Style.SelectionBackColor = Color.FromArgb(216, 30, 91);
                    buttonCell.Style.SelectionForeColor = Color.FromArgb(216, 30, 91);
                    buttonCell.FlatStyle = FlatStyle.Popup;

                    row.DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(216, 30, 91);
                }
                else
                {
                    buttonCell.Style.BackColor = Color.FromArgb(89, 201, 165);
                    buttonCell.Style.ForeColor = Color.FromArgb(89, 201, 165);
                    buttonCell.Style.SelectionBackColor = Color.FromArgb(89, 201, 165);
                    buttonCell.Style.SelectionForeColor = Color.FromArgb(89, 201, 165);
                    buttonCell.FlatStyle = FlatStyle.Popup;
                }
                row.Cells["alarm"] = buttonCell;
            }
        }

        /// <summary>
        /// DataGridView Style Setting
        /// </summary>
        private void TableViewStyle()
        {
            tableView.DataSource = bs;
            tableView.Columns["name"].HeaderText = "刀具名稱";
            tableView.Columns["life"].HeaderText = "最大損耗";
            tableView.Columns["remain"].HeaderText = "剩餘損耗";
            tableView.Columns["alarm"].HeaderText = "警報狀態";
            tableView.Columns["startTime"].HeaderText = "開始使用時間";
            tableView.Columns["endTime"].HeaderText = "結束使用時間";
            tableView.Columns["mark"].HeaderText = "類別";
            tableView.Columns["dateTime"].HeaderText = "紀錄時間";

            int width = 110;
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

        private void TableViewColClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TableMark();
        }

        /// <summary>
        /// 建立DataTable Column
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable HistoryDataTable()
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
            dc.DataType = Type.GetType("System.DateTime");
            dc.ColumnName = "startTime";            
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.DateTime");
            dc.ColumnName = "endTime";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "mark";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.DateTime");
            dc.ColumnName = "dateTime";
            dt.Columns.Add(dc);

            return dt;
        }

        /// <summary>
        /// 快速搜尋
        /// </summary>
        private void QuickSearch(object sender, EventArgs e)
        {
            bool useSearchBox = string.IsNullOrWhiteSpace(searchBox.Text);
            bool useAnyTime = anyTimeSelect.Checked;
            bool useError = errorSelect.Checked;
            if (useAnyTime)
            {
                labelStartTime.Enabled = false;
                labelEndTime.Enabled = false;
                startDateTimePicker.Enabled = false;
                endDateTimePicker.Enabled = false;
            }
            else
            {
                labelStartTime.Enabled = true;
                labelEndTime.Enabled = true;
                startDateTimePicker.Enabled = true;
                endDateTimePicker.Enabled = true;
            }

            try
            {
                bs.Filter = string.Format("(convert(id, 'System.String') LIKE '%{0}%' OR convert(name, 'System.String') LIKE '%{0}%' OR convert(life, 'System.String')  LIKE '%{0}%' OR convert(remain, 'System.String') LIKE '%{0}%' OR" +
                       " convert(mark, 'System.String') LIKE '%{0}%')", searchBox.Text);
                if (!useAnyTime)
                    bs.Filter += string.Format("AND (dateTime >= '{0:yyyy-MM-dd} 00:00:00' AND dateTime <= '{1:yyyy-MM-dd} 23:59:59')", startDateTimePicker.Value, endDateTimePicker.Value);
                //bs.Filter = string.Format("({0}) AND ({1})", SearchBoxFilter, dateFilter);
                if (useError)
                    bs.Filter += string.Format("AND (mark = '機台錯誤' OR alarm = 'true')");
                TableMark();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDownloadClick(object sender, EventArgs e)
        {
            DataTable selectedData = HistoryDataTable();
            string[] colName = new string[tableView.Columns.Count];
            for (int i = 0; i < colName.Length; i++)
            {
                colName[i] = tableView.Columns[i].HeaderText;
            }

            for(int i = 0; i < tableView.Rows.Count; i++)
            {
                DataGridViewCellCollection row = tableView.Rows[i].Cells;
                selectedData.Rows.Add(
                    row["name"].Value, row["life"].Value, row["remain"].Value, row["alarm"].Value, row["startTime"].Value, row["endTime"].Value, row["mark"].Value, row["dateTime"].Value
                    );
            }

            fileDialog.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            fileDialog.FileName = "刀具歷史紀錄" + string.Format("{0:yy-MM-dd-H-mm-ss}", DateTime.Now);
            fileDialog.CheckPathExists = true;
            fileDialog.InitialDirectory = "c:\\";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.dt = selectedData;
            loadingForm.colName = colName;
            loadingForm.fileName = fileDialog.FileName;
            loadingForm.Show();
        }

        
    }
}
