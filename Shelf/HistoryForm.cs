
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Shelf.Model;

namespace Shelf
{
    public partial class HistoryForm : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable table = new DataTable();
        private BindingSource bs = new BindingSource();
        private bool searchBoxHasText = false;
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryShown(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            var thisWeekStart = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            startDateTimePicker.Value = thisWeekStart;
            endDateTimePicker.Value = thisWeekEnd;

            LoadMachine();
        }

        /// <summary>
        /// 讀取機台
        /// </summary>
        private void LoadMachine()
        {
            List<Machine> machines = new List<Machine>();
            if(!tdb.GetAllMachine(ref machines))
            {
                SetUIEnabled(false);
                MessageBox.Show("未讀取到機台", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetUIEnabled(true);
            machineList.DataSource = machines;
        }

        /// <summary>
        /// 依照條件讀取資料
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isWarning"></param>
        private void LoadData(DateTime startTime, DateTime endTime, int machineId, bool isWarning)
        {
            table = HistoryDataTable();
            List<ToolHistory> histories = new List<ToolHistory>();

            if (!tdb.GetHistory(ref histories, startTime, endTime, machineId, isWarning))
            {
                //table.Rows.Clear();
                MessageBox.Show("查無歷史資料", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            foreach (ToolHistory th in histories)
            {
                string mark = "";
                switch (th.Mark)
                {
                    case '1':
                        mark = "取出刀具";
                        break;
                    case '2':
                        mark = "放回刀具";
                        break;
                    case '3':
                        mark = "執行換刀";
                        break;
                    case '4':
                        mark = "新增刀具";
                        break;
                    case '5':
                        mark = "刀具修改";
                        break;
                    case '6':
                        mark = "刀具刪除";
                        break;
                    case '7':
                        mark = "機台錯誤";
                        break;
                }
                string decreaseLife = (th.BeforeUseLife - th.AfterUseLife).ToString();
                
                table.Rows.Add(th.MachineId, th.Name, decreaseLife, th.BeforeUseLife, th.AfterUseLife, th.Warning, th.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), th.endTime.ToString("yyyy-MM-dd HH:mm:ss"), mark, th.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            bs.DataSource = table;
            TableViewStyle();
            TableMark();
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
            bool isWarning = errorSelect.Checked;
            LoadData(startTime, endTime, (machineList.SelectedItem as Machine).Id, isWarning);
            btnDownload.Visible = true;

        }

        /// <summary>
        /// 標註異常狀態
        /// </summary>
        private void TableMark()
        {
            foreach(DataGridViewRow row in tableView.Rows)
            {
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                if(Convert.ToInt32(row.Cells["afterUseLife"].Value) >= Convert.ToInt32(row.Cells["beforeUseLife"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(243, 202, 41);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 202, 41);
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                    row.Cells[0].Style.BackColor = Color.FromArgb(235, 237, 237);
                    row.Cells[0].Style.SelectionBackColor = Color.FromArgb(235, 237, 237);
                    row.Cells[0].Style.ForeColor = Color.Black;
                }
                if (Convert.ToInt32(row.Cells["afterUseLife"].Value) <= Convert.ToInt32(row.Cells["warning"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                    row.Cells[0].Style.BackColor = Color.FromArgb(235, 237, 237);
                    row.Cells[0].Style.SelectionBackColor = Color.FromArgb(235, 237, 237);
                    row.Cells[0].Style.ForeColor = Color.Black;
                }

                
            }
        }

        /// <summary>
        /// DataGridView Style Setting
        /// </summary>
        private void TableViewStyle()
        {
            tableView.DataSource = bs;

            tableView.Columns["name"].HeaderText = "刀具名稱";
            tableView.Columns["decreaseLife"].HeaderText = "使用磨耗";
            tableView.Columns["beforeUseLife"].HeaderText = "使用前磨耗";
            tableView.Columns["afterUseLife"].HeaderText = "使用後磨耗";
            tableView.Columns["warning"].HeaderText = "警戒值";
            tableView.Columns["startTime"].HeaderText = "開始使用時間";
            tableView.Columns["endTime"].HeaderText = "結束使用時間";
            tableView.Columns["mark"].HeaderText = "類別";
            tableView.Columns["createTime"].HeaderText = "紀錄時間";

            int width = 97;
            tableView.Columns["name"].Width = width;
            tableView.Columns["decreaseLife"].Width = width;
            tableView.Columns["beforeUseLife"].Width = width;
            tableView.Columns["afterUseLife"].Width = width;
            tableView.Columns["warning"].Width = width;
            tableView.Columns["mark"].Width = width;
            width = (tableView.Width - (width * 6)) / 3;
            tableView.Columns["startTime"].Width = width;
            tableView.Columns["endTime"].Width = width;
            tableView.Columns["createTime"].Width = width;

            tableView.Columns["name"].SortMode = DataGridViewColumnSortMode.Programmatic;
            tableView.Columns["decreaseLife"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["beforeUseLife"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["afterUseLife"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["warning"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["startTime"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["endTime"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["mark"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["createTime"].SortMode = DataGridViewColumnSortMode.Programmatic;

            tableView.Columns["name"].DefaultCellStyle.BackColor = Color.FromArgb(235, 237, 237);
            tableView.Columns["name"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 237, 237);
            //tableView.Columns["warning"].Visible = false;
            tableView.Columns["mark"].Visible = false; 
            tableView.Columns["machineId"].Visible = false;

            tableView.Columns["name"].HeaderCell.Tag = "natureAsc";
        }


        /// <summary>
        /// 建立DataTable Column
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable HistoryDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            dc = new DataColumn();
            dc.ColumnName = "machineId";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "name";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "decreaseLife";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "beforeUseLife";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "afterUseLife";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "warning";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "startTime";            
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "endTime";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "mark";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "createTime";
            dt.Columns.Add(dc);

            return dt;
        }

        /// <summary>
        /// 快速搜尋
        /// </summary>
        private void QuickSearch(object sender, EventArgs e)
        {
            try
            {
                string filterText = searchBox.Text;
                if (searchBox.Text == "名稱/使用磨耗/紀錄時間")
                    filterText = "";
                bs.Filter = string.Format("(convert(name, 'System.String') LIKE '%{0}%' OR convert(decreaseLife, 'System.String')  LIKE '%{0}%' OR convert(createTime, 'System.String') LIKE '%{0}%')", filterText);
                
                TableMark();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 下載按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDownloadClick(object sender, EventArgs e)
        {
            List<CSVHistoryFormat> histories = new List<CSVHistoryFormat>();
            string[] colName = new string[tableView.Columns.Count];

            for (int i = 0; i < colName.Length; i++)
            {
                colName[i] = tableView.Columns[i].HeaderText;
            }

            for(int i = 0; i < tableView.Rows.Count; i++)
            {
                DataGridViewCellCollection row = tableView.Rows[i].Cells;
                CSVHistoryFormat h = new CSVHistoryFormat
                {
                    machineId = Convert.ToInt32(row["machineId"].Value.ToString()),
                    Name = row["name"].Value.ToString(),
                    DecreaseLife = Convert.ToInt32(row["decreaseLife"].Value.ToString()),
                    BeforeUseLife = Convert.ToInt32(row["beforeUseLife"].Value.ToString()),
                    AfterUseLife = Convert.ToInt32(row["afterUseLife"].Value.ToString()),
                    Warning = Convert.ToInt32(row["warning"].Value.ToString()),
                    StartTime = row["startTime"].Value.ToString(),
                    EndTime = row["endTime"].Value.ToString(),
                    CreateTime = row["createTime"].Value.ToString()
                };
                histories.Add(h);
            }

            fileDialog.Filter = "CSV(*.csv)|*.csv";
            fileDialog.FileName = machineList.Text + "刀具歷史紀錄" + string.Format("{0:yyyy-MM-dd HH-mm-ss}", DateTime.Now);
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
            if (loadingForm.ExportHistoryCSV(histories, fileDialog.FileName))
                MessageBox.Show("下載成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("下載失敗", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 確認指定Cell與上方數值否相同
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        bool IsTheSameCellValue(DataGridView table, int column, int row)
        {
            DataGridViewCell cell1 = table[column, row];
            DataGridViewCell cell2 = table[column, row-1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        /// <summary>
        /// 合併相同刀具名稱的歷史紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.ColumnIndex == 0  && e.RowIndex != -1)
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex <= 0 || e.ColumnIndex != 0 )
                return;
            if (IsTheSameCellValue(tableView, e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = tableView.AdvancedCellBorderStyle.Top;
            }
        }

        private void tableView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex <= 0 || e.ColumnIndex != 0)
                return;
            if (IsTheSameCellValue(tableView, e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void SetUIEnabled(bool status)
        {
            btnSearch.Enabled = status;
            btnDownload.Enabled = status;
            startDateTimePicker.Enabled = status;
            endDateTimePicker.Enabled = status;
            errorSelect.Enabled = status;
            machineList.Enabled = status;
        }

        private void Textbox_Enter(object sender, EventArgs e)
        {
            if (searchBoxHasText == false)
                searchBox.Text = "";

            searchBox.ForeColor = Color.Black;
        }

        
        private void Textbox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "名稱/使用磨耗/紀錄時間";
                searchBox.ForeColor = Color.Gray;
                searchBoxHasText = false;
            }
            else
                searchBoxHasText = true;
        }

        /// <summary>
        /// 以ESC關閉視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sort"></param>
        private void Sort(string sort)
        {
            DataTable dt = new DataTable();
            if(sort == "natureAsc")
                dt = table.AsEnumerable().OrderBy(x => x.Field<string>("name"), new NaturalStringComparer()).CopyToDataTable();
            else if (sort == "natureDesc")
                dt = table.AsEnumerable().OrderBy(x => x.Field<string>("name"), new NaturalStringComparerDesc()).CopyToDataTable();
            
            bs.DataSource = dt;
        }

        private void tableView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = tableView.Columns[e.ColumnIndex];

            if (column.SortMode != DataGridViewColumnSortMode.Programmatic)
                return;
            if (table.Rows.Count == 0)
                return;
            var sortGlyphDirection = column.HeaderCell.SortGlyphDirection;
            string columnName = tableView.Columns[e.ColumnIndex].Name;
            DataTable dt = new DataTable();
            switch (sortGlyphDirection)
            {
                case SortOrder.None:
                case SortOrder.Ascending:
                    sortGlyphDirection = SortOrder.Descending;
                    dt = table.AsEnumerable().OrderBy(x => x.Field<string>(columnName), new NaturalStringComparerDesc()).CopyToDataTable();
                    break;
                case SortOrder.Descending:
                    sortGlyphDirection = SortOrder.Ascending;
                    dt = table.AsEnumerable().OrderBy(x => x.Field<string>(columnName), new NaturalStringComparer()).CopyToDataTable();
                    break;
            }
            bs.DataSource = dt;
            tableView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortGlyphDirection;


        }

        private void tableView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
