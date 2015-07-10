using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class SubNet
    {
        private Dictionary<uint, Host> hosts = new Dictionary<uint, Host>();
        private uint address = 0, mask = 0;
        //private Router router = new Router();
 
        public string SubnetName { get; set; }

        public SubNet()
        {
            this.hosts = new Dictionary<uint, Host>();
            //this.router = new Router();
        }

        public SubNet(uint address, uint mask, uint count, string SubNetName)
        {
            this.hosts = new Dictionary<uint, Host>();
            //this.router = new Router();
            this.SubnetName = SubNetName;
            this.address = address;
            this.mask = mask;
            for (int i = 0; i < 1; i++)
            {
                address++;
            }
            for (int i = 0; i < count;  i++)
            {
                address++;
                hosts.Add(address, new Host(address, "Host" + (i+1)));
            }
        }

        public uint Address
        {
            get { return address; }
            set { address = value; }
        }

        public uint Mask
        {
            get { return mask; }
            set { mask = value; }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.SubnetName + "\n");
            builder.Append("NetWork Address: " + Converter.AddressToString(this.address) + "\n");
            builder.Append("Mask: " + Converter.AddressToString(this.mask) + "\n");
            builder.Append("GateWay: " + Converter.AddressToString(this.address + 1) + "\n");
            uint brodcast = (~this.mask) + this.address;
            builder.Append("Brodcast: " + Converter.AddressToString(brodcast) + "\n");
            builder.Append("Number of hosts: " + (this.hosts.Count) + "\n");
            builder.Append("List of hosts:\n");
            foreach (var item in this.hosts)
            {
                builder.Append("-- ");
                builder.Append(item.Value.HostName + "\t");
                builder.Append(Converter.AddressToString(item.Value.IP) + "\n");
            }
            return builder.ToString();
        }
    }
}
