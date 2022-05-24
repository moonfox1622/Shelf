using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf
{
    class ToolHistory
    {
        public int id { get; set; }
        public int toolId { get; set; }
        public string name { get; set; }
        public int life { get; set; }
        public int remain { get; set; }
        public bool alarm { get; set; }
        public Nullable<DateTime> startTime { get; set; }
        public Nullable<DateTime> endTime { get; set; }
        public string mark { get; set; }
        public DateTime dateTime { get; set; }
    }
}
