using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class SystemLogForm : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable table = new DataTable();
        private BindingSource bs = new BindingSource();
        private bool searchBoxHasText = false;
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
            LoadData(startTime, endTime, (machineList.SelectedItem as Machine).Id);
            btnDownload.Visible = true;
        }

        /// <summary>
        /// 標註異常狀態
        /// </summary>
        private void TableMark()
        {
            foreach (DataGridViewRow row in tableView.Rows)
            {
                string mark = row.Cells["mark"].Value.ToString();
                switch (mark)
                {
                    case "新增":
                        row.Cells["mark"].Style.BackColor = Color.FromArgb(89, 201, 165);
                        break;
                    case "換刀":
                        row.Cells["mark"].Style.BackColor = Color.FromArgb(242, 236, 0);
                        break;
                    case "刪除":
                        row.Cells["mark"].Style.BackColor = Color.FromArgb(216, 30, 91);
                        break;
                }
            }
        }

        private void QuickSearch(object sender, EventArgs e)
        {
            try
            {
                string filterText = searchBox.Text;
                if (searchBox.Text == "名稱/類別/紀錄時間")
                    filterText = "";
                bs.Filter = string.Format("(convert(name, 'System.String') LIKE '%{0}%' OR convert(mark, 'System.String') LIKE '%{0}%')", filterText);

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
            tableView.Columns["life"].HeaderText = "最大磨耗值";
            tableView.Columns["remain"].HeaderText = "剩餘磨耗";
            tableView.Columns["warning"].HeaderText = "警戒值";
            tableView.Columns["mark"].HeaderText = "類別";
            tableView.Columns["createTime"].HeaderText = "紀錄時間";

            int width = 95;
            tableView.Columns["name"].Width = width;
            tableView.Columns["life"].Width = width;
            tableView.Columns["remain"].Width = width;
            tableView.Columns["warning"].Width = width;
            tableView.Columns["mark"].Width = width;
            width = (tableView.Width - (width * 6)) / 3;
            tableView.Columns["createTime"].Width = width;

            tableView.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["life"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["remain"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["warning"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["mark"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["createTime"].SortMode = DataGridViewColumnSortMode.Automatic;

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
                table.Rows.Add(l.Name, l.Life, l.Remain, l.Warning, l.Mark, l.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
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
            dc.ColumnName = "createTime";
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
                    Name = row["name"].Value.ToString(),
                    Life = Convert.ToInt32(row["life"].Value.ToString()),
                    Remain = Convert.ToInt32(row["remain"].Value.ToString()),
                    Warning = Convert.ToInt32(row["warning"].Value.ToString()),
                    Mark = row["mark"].Value.ToString(),
                    CreateTime = Convert.ToDateTime(row["createTime"].Value.ToString())
                };
                logs.Add(l);
            }

            fileDialog.Filter = "CSV(*.csv)|*.csv";
            fileDialog.FileName = machineList.Text + "系統紀錄" + string.Format("{0:yyyy-MM-dd HH-mm-ss}", DateTime.Now);
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

        private void Textbox_Enter(object sender, EventArgs e)
        {
            if (searchBoxHasText == false)
                searchBox.Text = "";

            searchBox.ForeColor = Color.Black;
        }

        //textbox失去焦點
        private void Textbox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "名稱/類別/紀錄時間";
                searchBox.ForeColor = Color.Gray;
                searchBoxHasText = false;
            }
            else
                searchBoxHasText = true;
        }

        private void SystemLogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


        private void TableViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                var myComparer = new NaturalSortComparer();
                tableView.Sort(myComparer);
            }
        }

        public class NaturalSortComparer : System.Collections.IComparer
        {

            private System.Collections.Generic.Dictionary<string, string[]> table;

            public NaturalSortComparer()
            {
                table = new System.Collections.Generic.Dictionary<string, string[]>();
            }

            public void Dispose()
            {
                table.Clear();
                table = null;
            }

            public int Compare(object x, object y)
            {
                System.Windows.Forms.DataGridViewRow DataGridViewRow1 = (System.Windows.Forms.DataGridViewRow)x;
                System.Windows.Forms.DataGridViewRow DataGridViewRow2 = (System.Windows.Forms.DataGridViewRow)y;

                string xStr = DataGridViewRow1.Cells["Column1"].Value.ToString();
                string yStr = DataGridViewRow2.Cells["Column1"].Value.ToString();


                if (xStr == yStr)
                {
                    return 0;
                }
                string[] x1, y1;
                if (!table.TryGetValue(xStr, out x1))
                {
                    x1 = System.Text.RegularExpressions.Regex.Split(xStr.Replace(" ", ""), "([0-9]+)");
                    table.Add(xStr, x1);
                }
                if (!table.TryGetValue(yStr, out y1))
                {
                    y1 = System.Text.RegularExpressions.Regex.Split(yStr.Replace(" ", ""), "([0-9]+)");
                    table.Add(yStr, y1);
                }

                for (int i = 0; i < x1.Length && i < y1.Length; i++)
                {
                    if (x1[i] != y1[i])
                    {
                        return PartCompare(x1[i], y1[i]);
                    }
                }
                if (y1.Length > x1.Length)
                {
                    return 1;
                }
                else if (x1.Length > y1.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            private static int PartCompare(string left, string right)
            {
                int x, y;
                if (!int.TryParse(left, out x))
                {
                    return left.CompareTo(right);
                }

                if (!int.TryParse(right, out y))
                {
                    return left.CompareTo(right);
                }

                return x.CompareTo(y);
            }
        }
    }
}
