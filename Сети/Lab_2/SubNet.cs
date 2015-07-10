using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class SubNet
    {
        private Dictionary<uint, Host> hosts = new Dictionary<uint, Host>();
        private uint address = 0, mask = 0;
        public List<uint> gateways = new List<uint>();

        public string SubnetName { get; set; }

        public SubNet()
        {
            this.hosts = new Dictionary<uint, Host>();
            this.gateways = new List<uint>();
        }

        public SubNet(uint address, uint mask, uint count, string SubNetName, int countGateway)
        {
            this.hosts = new Dictionary<uint, Host>();
            this.SubnetName = SubNetName;
            this.address = address;
            this.mask = mask;
            for (int i = 0; i < countGateway; ++i)
            {
                this.gateways.Add(++address);
            }
            for (int i = 0; i < count; i++)
            {
                address++;
                hosts.Add(address, new Host(address, "Host" + (i + 1)));
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
            if (!SubnetName.Equals("Internet"))
            for(int i = 0; i < this.gateways.Count; ++i) builder.Append("GateWay" + (i+1) + ": " + Converter.AddressToString(gateways[i]) + "\n");
            uint brodcast = (~this.mask) + this.address;
            builder.Append("Brodcast: " + Converter.AddressToString(brodcast) + "\n");
            if (this.hosts.Count != 0)
            {
                builder.Append("Number of hosts: " + (this.hosts.Count) + "\n");
                builder.Append("List of hosts:\n");
            }
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
