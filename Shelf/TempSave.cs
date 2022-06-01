using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace Shelf
{
    class TempSave
    {

        public void SaveTempToolData(List<Tool> t)
        {
            Directory.CreateDirectory("Temp");
            using(var writer = new StreamWriter("Temp\\TempToolData.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(t);
            }
        }


        public void SaveTempHistory(Tool t, char mark)
        {
            ToolHistory history = new ToolHistory
            {
                toolId = t.id,
                name = t.name,
                life = t.life,
                remain = t.remain,
                alarm = t.alarm,
                startTime = t.startTime,
                endTime = t.endTime,
                mark = mark,
                dateTime = DateTime.Now
            };
            List<ToolHistory> histories = new List<ToolHistory>();
            histories.Add(history);
            Directory.CreateDirectory("Temp");
            string path = "Temp\\TempHistoryData.csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            if (!File.Exists(path))
                config.HasHeaderRecord = true;

            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(histories);
            }
        }

        public void SaveToolTempInDatabase()
        {
            string path = "Temp\\TempHistoryData.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ToolHistory>().ToList();
                ToolDatabase tdb = new ToolDatabase();
                foreach(ToolHistory h in records)
                {
                    Tool t = new Tool
                    {
                        id = h.toolId,
                        name = h.name,
                        life = h.life,
                        remain = h.remain,
                        startTime = h.startTime,
                        endTime = h.endTime
                    };

                    switch (h.mark)
                    {
                        case '1':
                            tdb.HistoryUseTool(t);
                            break;
                        case '2':
                            tdb.HistoryReturnTool(t);
                            break;
                    }
                }
            }
            File.Delete(path);
        }


    }
}
