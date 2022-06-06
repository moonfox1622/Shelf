﻿using NPOI.HSSF.Util;
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
    public partial class HistoryForm : Form
    {
        ToolDatabase tdb = new ToolDatabase();
        private DataTable table = new DataTable();
        private BindingSource bs = new BindingSource();

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
        }


        private void BtnSearchClick(object sender, EventArgs e)
        {
            DateTime startTime = startDateTimePicker.Value.Date;
            DateTime endTime = endDateTimePicker.Value.Date;
            bool isWarning = errorSelect.Checked;
            LoadData(startTime, endTime, isWarning);
            btnDownload.Visible = true;
        }

        /// <summary>
        /// 依照條件讀取資料
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isWarning"></param>
        private void LoadData(DateTime startTime, DateTime endTime, bool isWarning)
        {
            table = HistoryDataTable();
            List<ToolHistory> histories = new List<ToolHistory>();

            if (!tdb.GetHistory(ref histories, startTime, endTime, isWarning))
            {
                MessageBox.Show("查無歷史資料", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (ToolHistory th in histories)
            {
                string mark = "";
                switch (th.mark)
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

                table.Rows.Add(th.name, (th.beforeUseLife - th.afterUseLife),th.beforeUseLife, th.afterUseLife, th.warning, th.startTime.ToString("yyyy-MM-dd HH:mm:ss"), th.endTime.ToString("yyyy-MM-dd HH:mm:ss"), mark, th.dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            bs.DataSource = table;
            TableViewStyle();
            TableMark();
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
                if (Convert.ToInt32(row.Cells["afterUseLife"].Value) <= Convert.ToInt32(row.Cells["warning"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(216, 30, 91);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.GradientActiveCaption;
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(216, 30, 91);
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
            tableView.Columns["decreaseLife"].HeaderText = "使用損耗";
            tableView.Columns["beforeUseLife"].HeaderText = "使用前損耗";
            tableView.Columns["afterUseLife"].HeaderText = "使用後損耗";
            tableView.Columns["warning"].HeaderText = "警戒值";
            tableView.Columns["startTime"].HeaderText = "開始使用時間";
            tableView.Columns["endTime"].HeaderText = "結束使用時間";
            tableView.Columns["mark"].HeaderText = "類別";
            tableView.Columns["dateTime"].HeaderText = "紀錄時間";

            int width = 110;
            tableView.Columns["name"].Width = width;
            tableView.Columns["decreaseLife"].Width = width;
            tableView.Columns["beforeUseLife"].Width = width;
            tableView.Columns["afterUseLife"].Width = width;
            tableView.Columns["warning"].Width = width;
            tableView.Columns["mark"].Width = width;
            width = (tableView.Width - (width * 6)) / 3;
            tableView.Columns["startTime"].Width = width;
            tableView.Columns["endTime"].Width = width;
            tableView.Columns["dateTime"].Width = width;

            tableView.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["decreaseLife"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["beforeUseLife"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["afterUseLife"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["warning"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["startTime"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["endTime"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["mark"].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableView.Columns["dateTime"].SortMode = DataGridViewColumnSortMode.NotSortable;

            tableView.Columns["name"].DefaultCellStyle.BackColor = Color.FromArgb(235, 237, 237);
            tableView.Columns["name"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 237, 237);
            //tableView.Columns["warning"].Visible = false;
            tableView.Columns["mark"].Visible = false; ;
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
            dc.ColumnName = "name";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "decreaseLife";
            dc.DataType = Type.GetType("System.Int32");
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
            dc.ColumnName = "dateTime";
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
                bs.Filter = string.Format("(convert(name, 'System.String') LIKE '%{0}%' OR convert(beforeUseLife, 'System.String')  LIKE '%{0}%' OR convert(afterUseLife, 'System.String') LIKE '%{0}%' OR" +
                       " convert(mark, 'System.String') LIKE '%{0}%')", searchBox.Text);
                
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
                    row["name"].Value, 
                    row["decreaseLife"].Value,
                    row["beforeUseLife"].Value, 
                    row["afterUseLife"].Value, 
                    row["warning"].Value, 
                    row["startTime"].Value, 
                    row["endTime"].Value, 
                    row["mark"].Value, 
                    row["dateTime"].Value
                    );
            }

            fileDialog.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            fileDialog.FileName = "刀具歷史紀錄" + string.Format("{0:yy-MM-dd-H-mm-ss}", DateTime.Now);
            fileDialog.CheckPathExists = true;
            fileDialog.InitialDirectory = "c:\\";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            LoadingForm loadingForm = new LoadingForm
            {
                dt = selectedData,
                colName = colName,
                fileName = fileDialog.FileName
            };
            loadingForm.Show();
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

    }
}