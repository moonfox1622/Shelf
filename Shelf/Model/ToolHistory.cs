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
        public int Id { get; set; }

        [CsvHelper.Configuration.Attributes.Name("ToolId")]
        public int ToolId { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Name")]
        public string Name { get; set; }

        [CsvHelper.Configuration.Attributes.Name("BeforeUseLife")]
        public int BeforeUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("AfterUseLife")]
        public int AfterUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Warning")]
        public int Warning { get; set; }

        [CsvHelper.Configuration.Attributes.Name("StartTime")]
        public DateTime StartTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("EndTime")]
        public DateTime endTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Mark")]
        public char Mark { get; set; }

        [CsvHelper.Configuration.Attributes.Name("CreateTime")]
        public DateTime CreateTime { get; set; }
    }
}
