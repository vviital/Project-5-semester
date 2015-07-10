using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Router
    {
        RoutingTable table = new RoutingTable();

        public void AddEntry(Entry tableEntry)
        {
            this.table.Add(tableEntry);
        }

        public Router() { }

        public string GetTable()
        {
            return this.table.ToString();
        }

        public uint GetInterface(uint address)
        {
            return this.table.GetInterface(address);
        }
    }
}
