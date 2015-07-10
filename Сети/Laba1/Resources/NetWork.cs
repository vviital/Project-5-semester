using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1.Resources
{
    class NetWork
    {
        private Dictionary<IP, Subnet> subnets;

        public NetWork()
        {
            this.subnets = new Dictionary<IP, Subnet>();
        }

        public void Add(IP ip, int numberOfHosts)
        {
            this.subnets.Add(ip, new Subnet(ip, numberOfHosts));
        }

        public Subnet this[IP ip]
        {
            get
            {
                try
                {
                    return this.subnets[ip];
                }
                catch (Exception e)
                {
                    MessageBox.Show("Подсети с таким IP не существует");
                    throw new Exception();
                }
            }
            set
            {
                this.subnets.Add(ip, value);
            }
        }
    }
}
