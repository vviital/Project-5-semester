using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class RoutingTable
    {
        private List<Entry> entries = new List<Entry>();

        public RoutingTable()
        {
            this.entries = new List<Entry>();
        }

        public void Add(Entry entry)
        {
            this.entries.Add(entry);
        }

        public Entry this[int i]
        {
            get { return this.entries[i]; }
            set { this.entries[i] = value; }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Network Destination\t");
            builder.Append("Netmask\t\t   ");
            builder.Append("Gateway\t");
            builder.Append("Interface\t");
            builder.Append("Metric\n");
            foreach (var item in this.entries)
            {
                builder.Append(item.ToString() + "\n");
            }
            return builder.ToString();
        }

        public uint GetInterface(uint address)
        {
            uint currentinterface = 0;
            foreach (var item in this.entries)
            {
                if (item.NetworkDestination == address) currentinterface = item.Interface;
            }
            return currentinterface;
        }
    }
}
