using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Router
    {
        RoutingTable table = new RoutingTable();

        public void AddEntry(Entry tableEntry)
        {
            this.table.Add(tableEntry);
        }

        public Router(List<SubNet> subNets)
        {
            for (int i = 0; i < subNets.Count; ++i)
            {
                uint destination = subNets[i].Address;
                uint mask = subNets[i].Mask;
                uint gateway = 0;
                uint interfaces = subNets[i].Address + 1;
                uint metric = 0;
                table.Add(new Entry(destination, mask, gateway, interfaces, metric));
            }
        }

        public string GetTable()
        {
            return this.table.ToString();
        }
    }
}
