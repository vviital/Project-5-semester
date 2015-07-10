using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Entry
    {
        public uint NetworkDestination { get; set; }

        public uint Netmask { get; set; }

        public uint Gateway { get; set; }

        public uint Interface { get; set; }

        public uint Metric { get; set; }

        public Entry() { }

        public Entry(uint NetworkDestination, uint Netmask, uint Gateway, uint Interface, uint Metric)
        {
            this.NetworkDestination = NetworkDestination;
            this.Netmask = Netmask;
            this.Gateway = Gateway;
            this.Interface = Interface;
            this.Metric = Metric;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Converter.AddressToString(NetworkDestination) + "\t\t");
            builder.Append(Converter.AddressToString(Netmask) + "\t   ");
            builder.Append(Converter.AddressToString(Gateway) + "\t");
            builder.Append(Converter.AddressToString(Interface) + "\t");
            builder.Append(Metric + "\t");
            return builder.ToString();
        }
    }
}
