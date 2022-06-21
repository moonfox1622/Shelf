using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Shelf.Model;

namespace Shelf
{
    class TempSave
    {
        public void SaveTempToolData(Tool t)
        {
            Directory.CreateDirectory("Temp");
            string path = "Temp\\TempToolData.csv";
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
                csv.WriteRecord(t);
                csv.NextRecord();
            }
        }


        public void SaveTempHistory(ToolHistory h)
        {
            Directory.CreateDirectory("Temp");
            string path = "Temp\\TempHistoryData.csv";
            bool writeHeader = false;
            if (!File.Exists(path))
                writeHeader = true;
            try
            {
                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (writeHeader)
                    {
                        csv.WriteHeader<ToolHistory>();
                        csv.NextRecord();
                    }
                    csv.WriteRecord(h);
                    csv.NextRecord();
                }
            }
            catch
            {
                return;
            }
            
        }


        public void SaveTempSystemLog(Log l)
        {
            Directory.CreateDirectory("Temp");
            string path = "Temp\\TempLogData.csv";
            bool writeHeader = false;
            if (!File.Exists(path))
                writeHeader = true;
            try
            {
                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (writeHeader)
                    {
                        csv.WriteField("machineId");
                        csv.WriteField("name");
                        csv.WriteField("life");
                        csv.WriteField("remain");
                        csv.WriteField("warning");
                        csv.WriteField("mark");
                        csv.WriteField("dateTime");
                        csv.NextRecord();
                    }
                    csv.WriteRecord(l);
                    csv.NextRecord();
                }
            }
            catch
            {
                return;
            }
            
        }


        public void RestoreToolTemp()
        {
            string path = "Temp\\TempToolData.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Tool>().ToList();
                ToolDatabase tdb = new ToolDatabase();
                
                foreach(Tool t in records)
                {
                    tdb.UpdateTool(t);
                }
            }
            File.Delete(path);
        }

        public void RestoreHistoryTemp()
        {
            string path = "Temp\\TempHistoryData.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ToolHistory>().ToList();
                ToolDatabase tdb = new ToolDatabase();

                foreach (ToolHistory h in records)
                {
                    if (!tdb.HistoryTool(h))
                        return;
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
    }
}
