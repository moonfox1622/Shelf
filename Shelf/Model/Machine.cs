using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf.Model
{
    class Machine
    {
        public int id { get; set; }

        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
