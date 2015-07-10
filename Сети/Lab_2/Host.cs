using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Host
    {
        private uint _ip;

        public string HostName { get; set; }

        public uint IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public Host()
        {

        }

        public Host(uint ip, string hostName)
        {
            this.IP = ip;
            this.HostName = hostName;
        }
    }
}
