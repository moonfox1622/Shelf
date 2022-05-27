using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(!ExportExcel(dt, colName, fileName))
            {
                MessageBox.Show("下載失敗", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                return;
            } 
            MessageBox.Show("下載完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Close();
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

                    row.CreateCell(0, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][0].ToString())); //id
                    row.CreateCell(1, CellType.String).SetCellValue(dt.Rows[i][1].ToString()); //name
                    row.CreateCell(2, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][2].ToString())); //life
                    row.CreateCell(3, CellType.Numeric).SetCellValue(Convert.ToInt32(dt.Rows[i][3].ToString())); //remain
                    row.CreateCell(5, CellType.String).SetCellValue(dt.Rows[i][5].ToString()); //startTime
                    row.CreateCell(6, CellType.String).SetCellValue(dt.Rows[i][6].ToString()); //endTime
                    row.CreateCell(7, CellType.String).SetCellValue(dt.Rows[i][7].ToString()); //mark
                    row.CreateCell(8, CellType.String).SetCellValue(dt.Rows[i][8].ToString()); //dateTime

                    ICellStyle cellStyle = workbook.CreateCellStyle();
                    IFont font = workbook.CreateFont();
                    font.FontName = "新細明體";
                    if (dt.Rows[i][4].ToString() == "True")
                    {
                        row.CreateCell(4, CellType.String).SetCellValue("警告");//alarm
                        font.Color = HSSFColor.Plum.Index;
                        cellStyle.SetFont(font);
                        cellStyle.FillForegroundColor = HSSFColor.Rose.Index;
                        cellStyle.FillPattern = FillPattern.SolidForeground;
                        for (int j = 0; j < dt.Columns.Count; j++)
                            row.GetCell(j).CellStyle = cellStyle;
                    }
                    else
                    {
                        ICell cell = row.CreateCell(4, CellType.String);
                        font.Color = HSSFColor.Green.Index;
                        cellStyle.SetFont(font);
                        cellStyle.FillForegroundColor = HSSFColor.LightGreen.Index;
                        cellStyle.FillPattern = FillPattern.SolidForeground;
                        row.CreateCell(4, CellType.String).SetCellValue("正常");//alarm
                        row.GetCell(4).CellStyle = cellStyle;
                    }
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

        
    }
}
