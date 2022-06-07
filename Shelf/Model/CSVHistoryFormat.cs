using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf.Model
{
    class CSVHistoryFormat
    {
        [CsvHelper.Configuration.Attributes.Name("刀具名稱")]
        public string name { get; set; }

        [CsvHelper.Configuration.Attributes.Name("使用耗損")]
        public int decreaseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("使用前耗損")]
        public int beforeUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("使用後耗損")]
        public int afterUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("警戒值")]
        public int warning { get; set; }

        [CsvHelper.Configuration.Attributes.Name("開始使用時間")]
        public string startTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("結束使用時間")]
        public string endTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("紀錄時間")]
        public string dateTime { get; set; }
    }
}
