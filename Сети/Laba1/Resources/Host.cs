using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Resources
{
    class Host
    {
        private IP addressIp;

        private string HostName;

        public Host()
        {
            this.addressIp = null;
        }

        public Host(IP hostIp, string name)
        {
            this.addressIp = hostIp;
            this.HostName = name;
        }

        public IP GetIp()
        {
            return (IP)this.addressIp.Clone();
        }

        public string GetHostName()
        {
            return this.HostName;
        }
    }
}
