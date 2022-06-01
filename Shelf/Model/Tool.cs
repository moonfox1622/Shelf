
using System;

namespace Shelf
{
    public class Tool
    {
        public int id { get; set; }
        public string name { get; set; }
        public int life { get; set; }
        public int remain { get; set; }
        public bool alarm { get; set; }
        public Nullable<DateTime> startTime { get; set; }
        public Nullable<DateTime> endTime { get; set; }
        
    }
}
