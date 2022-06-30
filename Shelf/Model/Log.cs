using System;

namespace Shelf.Model
{
    public class Log
    {
        public int MachineId { get; set; }

        public string Name { get; set; }

        public int Life { get; set; }

        public int Remain { get; set; }

        public int Warning { get; set; }

        public string Mark { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
