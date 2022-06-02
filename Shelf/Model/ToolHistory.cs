using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf
{
    class ToolHistory
    {
        public int toolId { get; set; }
        public string name { get; set; }
        public int beforeUseLife { get; set; }
        public int afterUseLife { get; set; }
        public int warning { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public char mark { get; set; }
        public DateTime dateTime { get; set; }
    }
}
