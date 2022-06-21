using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class SystemLogForm : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable table = new DataTable();
        private BindingSource bs = new BindingSource();

        public SystemLogForm()
        {
            InitializeComponent();
        }

        private void SystemLogShown(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            var thisWeekStart = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            startDateTimePicker.Value = thisWeekStart;
            endDateTimePicker.Value = thisWeekEnd;

            LoadMachine();
        }

        /// <summary>
        /// 條件搜尋按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick(object sender, EventArgs e)
        {
            DateTime startTime = startDateTimePicker.Value;
            DateTime endTime = endDateTimePicker.Value;
            LoadData(startTime, endTime, (machineList.SelectedItem as Machine).id);
            btnDownload.Visible = true;
        }

        /// <summary>
        /// 標註異常狀態
        /// </summary>
        private void TableMark()
        {
            foreach (DataGridViewRow row in tableView.Rows)
            {
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
            }
        }

        private void QuickSearch(object sender, EventArgs e)
        {
            try
            {
                bs.Filter = string.Format("(convert(name, 'System.String') LIKE '%{0}%' OR convert(mark, 'System.String') LIKE '%{0}%')", searchBox.Text);

                //TableMark();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridView Style Setting
        /// </summary>
        private void TableViewStyle()
        {
            tableView.DataSource = bs;

            tableView.Columns["name"].HeaderText = "刀具名稱";
            tableView.Columns["life"].HeaderText = "最大損耗值";
            tableView.Columns["remain"].HeaderText = "剩餘損耗";
            tableView.Columns["warning"].HeaderText = "警戒值";
            tableView.Columns["mark"].HeaderText = "類別";
            tableView.Columns["dateTime"].HeaderText = "紀錄時間";

            int width = 95;
            tableView.Columns["name"].Width = width;
            tableView.Columns["life"].Width = width;
            tableView.Columns["remain"].Width = width;
            tableView.Columns["warning"].Width = width;
            tableView.Columns["mark"].Width = width;
            width = (tableView.Width - (width * 6)) / 3;
            tableView.Columns["dateTime"].Width = width;

            tableView.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["life"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["remain"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["warning"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["mark"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["dateTime"].SortMode = DataGridViewColumnSortMode.Automatic;

            tableView.Columns["name"].DefaultCellStyle.BackColor = Color.FromArgb(235, 237, 237);
            tableView.Columns["name"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 237, 237);
        }

        /// <summary>
        /// 依照條件讀取資料
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isWarning"></param>
        private void LoadData(DateTime startTime, DateTime endTime, int machineId)
        {
            table = LogDataTable();
            List<Log> logs = new List<Log>();

            if (!tdb.GetLog(ref logs, startTime, endTime, machineId))
            {
                MessageBox.Show("查無系統紀錄資料", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            foreach (Log l in logs)
            {
                table.Rows.Add(l.name, l.life, l.remain, l.warning, l.mark, l.dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
            bs.DataSource = table;
            TableViewStyle();
            //TableMark();
        }

        /// <summary>
        /// 讀取機台
        /// </summary>
        private void LoadMachine()
        {
            List<Machine> machines = new List<Machine>();
            if (!tdb.GetAllMachine(ref machines))
            {
                SetUIEnabled(false);
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetUIEnabled(true);
            machineList.DataSource = machines;
        }


        private DataTable LogDataTable()
        {
            DataTable dt = new DataTable();

            DataColumn dc;
            dc = new DataColumn();
            dc.ColumnName = "name";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "life";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "remain";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);
            
            dc = new DataColumn();
            dc.ColumnName = "warning";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "mark";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "dateTime";
            dt.Columns.Add(dc);

            return dt;
        }

        private void SetUIEnabled(bool status)
        {
            btnSearch.Enabled = status;
            btnDownload.Enabled = status;
            startDateTimePicker.Enabled = status;
            endDateTimePicker.Enabled = status;
            machineList.Enabled = status;
        }

        private void BtnDownloadClick(object sender, EventArgs e)
        {
            List<Log> logs = new List<Log>();
            string[] colName = new string[tableView.Columns.Count];
            for (int i = 0; i < colName.Length; i++)
            {
                colName[i] = tableView.Columns[i].HeaderText;
            }

            for (int i = 0; i < tableView.Rows.Count; i++)
            {
                DataGridViewCellCollection row = tableView.Rows[i].Cells;
                Log l = new Log
                {
                    name = row["name"].Value.ToString(),
                    life = Convert.ToInt32(row["life"].Value.ToString()),
                    remain = Convert.ToInt32(row["remain"].Value.ToString()),
                    warning = Convert.ToInt32(row["warning"].Value.ToString()),
                    mark = row["mark"].Value.ToString(),
                    dateTime = Convert.ToDateTime(row["dateTime"].Value.ToString())
                };
                logs.Add(l);
            }

            fileDialog.Filter = "CSV(*.csv)|*.csv";
            fileDialog.FileName = machineList.Text + "系統紀錄" + string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now);
            fileDialog.CheckPathExists = true;
            fileDialog.InitialDirectory = "c:\\";
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            LoadingForm loadingForm = new LoadingForm
            {
                colName = colName,
                fileName = fileDialog.FileName
            };
            loadingForm.Show();
            if (loadingForm.ExportLogCSV(logs, fileDialog.FileName))
                MessageBox.Show("下載成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("下載失敗", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
