
using System;

namespace Shelf
{
    public class Tool
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Name { get; set; }
        public int Life { get; set; }
        public int Remain { get; set; }
        public int Warning { get; set; }
        public bool Taken { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
