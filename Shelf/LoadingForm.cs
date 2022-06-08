using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Shelf.Model;
using System.Globalization;

namespace Shelf
{
    public partial class LoadingForm : Form
    {
        public DataTable dt { get; set; }
        public string[] colName { get; set; }
        public string fileName { get; set; }
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void DownloadFormShown(object sender, EventArgs e)
        {
            if(!ExportCSV(dt, colName, fileName))
            {
                this.Close();
                MessageBox.Show("下載失敗", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
            MessageBox.Show("下載完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 輸出Excel檔
        /// </summary>
        /// <param name="dt">刀具歷史資料</param>
        /// <param name="colName">Excel Header</param>
        /// <param name="FileName">包含路徑的檔名</param>
        private bool ExportExcel(DataTable dt, string[] colName, string fileName)
        {
            try
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet();
                IRow rowhead = sheet.CreateRow(0);
                downloadProgressBar.Maximum = dt.Rows.Count;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    rowhead.CreateCell(i, CellType.String).SetCellValue(colName[i]);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);

                    //row.CreateCell(0, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][0].ToString())); //id
                    row.CreateCell(0, CellType.String).SetCellValue(dt.Rows[i][0].ToString()); //name
                    row.CreateCell(1, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][1].ToString())); //beforeUseLife
                    row.CreateCell(2, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][2].ToString())); //afterUseLife
                    row.CreateCell(3, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][3].ToString())); //warning
                    row.CreateCell(4, CellType.String).SetCellValue(dt.Rows[i][4].ToString()); //startTime
                    row.CreateCell(5, CellType.String).SetCellValue(dt.Rows[i][5].ToString()); //endTime
                    row.CreateCell(6, CellType.String).SetCellValue(dt.Rows[i][6].ToString()); //mark
                    row.CreateCell(7, CellType.String).SetCellValue(dt.Rows[i][7].ToString()); //dateTime

                    ICellStyle cellStyle = workbook.CreateCellStyle();
                    IFont font = workbook.CreateFont();
                    font.FontName = "微軟正黑體";
                    
                    double precentage = ((double)(i+1) / (double)dt.Rows.Count) * 100;
                    downloadProgressBar.Value = i+1;
                    txtPercentage.Text = string.Format("{0}% 已完成", ((int)precentage).ToString());
                }

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                using (FileStream stream = File.OpenWrite(fileName))
                {
                    workbook.Write(stream);
                    stream.Close();
                }
                GC.Collect();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("下載失敗", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool ExportCSV(DataTable dt, string[] colName, string fileName)
        {
            try
            {
                using (var writer = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<CSVHistoryFormat>();
                    csv.NextRecord();
                    downloadProgressBar.Maximum = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CSVHistoryFormat h = new CSVHistoryFormat
                        {
                            name = dt.Rows[i][0].ToString(),
                            decreaseLife = dt.Rows[i][1].ToString(),
                            beforeUseLife = Convert.ToInt32(dt.Rows[i][2].ToString()),
                            afterUseLife = Convert.ToInt32(dt.Rows[i][3].ToString()),
                            warning = Convert.ToInt32(dt.Rows[i][4].ToString()),
                            startTime = dt.Rows[i][5].ToString(),
                            endTime = dt.Rows[i][6].ToString(),
                            dateTime = dt.Rows[i][8].ToString()
                        };
                        csv.WriteRecord(h);
                        csv.NextRecord();

                        double precentage = ((double)(i + 1) / (double)dt.Rows.Count) * 100;
                        downloadProgressBar.Value = i + 1;
                        txtPercentage.Text = string.Format("{0}% 已完成", ((int)precentage).ToString());
                    }
                    return true;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
