using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf.Model
{
    class TempWriteHistory
    {
        public int machineId { get; set; }
        public string name { get; set; }
        public int remain { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
