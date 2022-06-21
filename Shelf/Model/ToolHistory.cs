using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf
{
    public class ToolHistory
    {
        [CsvHelper.Configuration.Attributes.Ignore]
        public int id { get; set; }

        [CsvHelper.Configuration.Attributes.Name("toolId")]
        public int toolId { get; set; }

        [CsvHelper.Configuration.Attributes.Name("name")]
        public string name { get; set; }

        [CsvHelper.Configuration.Attributes.Name("beforeUseLife")]
        public int beforeUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("afterUseLife")]
        public int afterUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("warning")]
        public int warning { get; set; }

        [CsvHelper.Configuration.Attributes.Name("startTime")]
        public DateTime startTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("endTime")]
        public DateTime endTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("mark")]
        public char mark { get; set; }

        [CsvHelper.Configuration.Attributes.Name("dateTime")]
        public DateTime dateTime { get; set; }
    }
}
