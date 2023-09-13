using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.Model
{
    class Warehouse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public bool Full { get; set; }

        public Warehouse(string name, string address, string zip, bool full)
        {
            Name = name;
            Address = address;
            Zip = zip;
            Full = full;
        }
    }
}
