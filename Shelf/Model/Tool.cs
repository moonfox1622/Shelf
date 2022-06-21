
using System;

namespace Shelf
{
    public class Tool
    {
        [CsvHelper.Configuration.Attributes.Name("id")]
        public int id { get; set; }
        public int machineId { get; set; }
        public string name { get; set; }
        public int life { get; set; }
        public int remain { get; set; }
        public int warning { get; set; }
        public bool taken { get; set; }
        public DateTime lastUpdate { get; set; }

        [CsvHelper.Configuration.Attributes.Ignore]
        public DateTime startTime { get; set; }
        [CsvHelper.Configuration.Attributes.Ignore]
        public DateTime endTime { get; set; }

        
    }
}
