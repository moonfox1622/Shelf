using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelf.Model
{
    public class Machine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Describe { get; set; }

        public string Picture { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
