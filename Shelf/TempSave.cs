using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using CsvHelper;
using Shelf.Model;

namespace Shelf
{
    class TempSave
    {
        /// <summary>
        /// 歷史紀錄暫存
        /// </summary>
        /// <param name="name"></param>
        /// <param name="machineId"></param>
        /// <param name="remain"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public void SaveTempWriteHistoryData(string name, int machineId, int remain, DateTime startTime, DateTime endTime)
        {
            Directory.CreateDirectory("Temp");
            string path = "Temp\\TempWriteHistoryData.csv";
            bool writeHeader = false;
            if (!File.Exists(path))
                writeHeader = true;

            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (writeHeader)
                {
                    csv.WriteHeader<TempWriteHistory>();
                    csv.NextRecord();
                }
                csv.WriteField(machineId);
                csv.WriteField(name);
                csv.WriteField(remain);
                csv.WriteField(startTime.ToString("yyyy/MM/dd HH:mm:ss.fff"));
                csv.WriteField(endTime.ToString("yyyy/MM/dd HH:mm:ss.fff"));
                csv.NextRecord();
            }
        }

        /// <summary>
        /// 刀具更新暫存
        /// </summary>
        /// <param name="t"></param>
        public void SaveTempToolUpdate(Tool t)
        {
            Directory.CreateDirectory("Temp");
            string path = "Temp\\TempToolUseData.csv";
            bool writeHeader = false;
            if (!File.Exists(path))
                writeHeader = true;

            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (writeHeader)
                {
                    csv.WriteHeader<Tool>();
                    csv.NextRecord();
                }
                csv.WriteField(t.Id);
                csv.WriteField(t.MachineId);
                csv.WriteField(t.Name);
                csv.WriteField(t.Life);
                csv.WriteField(t.Remain);
                csv.WriteField(t.Warning);
                csv.WriteField(t.Taken);
                csv.WriteField(t.LastUpdate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                csv.WriteField(t.StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                csv.WriteField(t.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                csv.NextRecord();
            }
        }

        ///// <summary>
        ///// 系統紀錄暫存
        ///// </summary>
        ///// <param name="l"></param>
        //public void SaveTempSystemLog(Log l)
        //{
        //    Directory.CreateDirectory("Temp");
        //    string path = "Temp\\TempLogData.csv";
        //    bool writeHeader = false;
        //    if (!File.Exists(path))
        //        writeHeader = true;
        //    try
        //    {
        //        using (var stream = File.Open(path, FileMode.Append))
        //        using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
        //        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //        {
        //            if (writeHeader)
        //            {
        //                csv.WriteField("machineId");
        //                csv.WriteField("name");
        //                csv.WriteField("life");
        //                csv.WriteField("remain");
        //                csv.WriteField("warning");
        //                csv.WriteField("mark");
        //                csv.WriteField("dateTime");
        //                csv.NextRecord();
        //            }
        //            csv.WriteRecord(l);
        //            csv.NextRecord();
        //        }
        //    }
        //    catch
        //    {
        //        return;
        //    }
            
        //}

        /// <summary>
        /// 將暫存存入資料庫
        /// </summary>
        public void RestoreToolTemp()
        {
            string path = "Temp\\TempToolUseData.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Tool>().ToList();
                ToolDatabase tdb = new ToolDatabase();
                List<Tool> tools = new List<Tool>();
                foreach(Tool t in records)
                {
                    tdb.UpdateTool(t);
                }
            }
            File.Delete(path);
        }
        
        public void RestoreSystemLogTemp()
        {
            string path = "Temp\\TempLogData.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Log>().ToList();
                ToolDatabase tdb = new ToolDatabase();

                foreach (Log l in records)
                {
                    if (!tdb.InsertSystemLog(l))
                        return;
                }
            }
            File.Delete(path);
        }

        public void RestoreWriteHistoryData()
        {
            string path = "Temp\\TempWriteHistoryData.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<TempWriteHistory>().ToList();
                ToolDatabase tdb = new ToolDatabase();

                foreach (TempWriteHistory temp in records)
                {
                    Tool t = new Tool();
                    if (!tdb.GetToolByName(temp.name, temp.machineId, ref t))
                        return;

                    int beforeUseLife = t.Remain;
                    t.Remain = temp.remain;

                    ToolHistory h = new ToolHistory
                    {
                        MachineId = t.MachineId,
                        Name = t.Name,
                        BeforeUseLife = beforeUseLife,
                        AfterUseLife = t.Remain,
                        Warning = t.Warning,
                        StartTime = temp.startTime,
                        endTime = temp.endTime,
                        Mark = '1',
                        CreateTime = DateTime.Now
                    };
                    t.Taken = false;
                    t.LastUpdate = DateTime.Now;

                    if (!tdb.UpdateTool(t))
                        return;

                    if (!tdb.HistoryTool(h))
                        return;
                    Thread.Sleep(100);
                }
            }
            File.Delete(path);
        }
    }
}
