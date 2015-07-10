using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1.Resources
{
    internal class Subnet
    {
        private List<Host> hosts;
        private int size = 0;
        private IP nextIP;

        public Subnet()
        {
            this.hosts = new List<Host>();
        }

        public Subnet(IP addressRange, int HostCount)
        {
            addressRange.Inc();
            nextIP = addressRange;
            for (int i = 0; i < HostCount; ++i)
            {
                this.AddHost();
            }
        }

        public int Count()
        {
            return this.hosts.Count;
        }

        public Host this[int i]
        {
            get
            {
                if (i < 0 || i >= Count()) throw new IndexOutOfRangeException();
                return this.hosts[i];
            }
            set
            {
                if (i < 0 || i >= Count()) throw new IndexOutOfRangeException();
                this.hosts[i] = value;
            }
        }

        public int GetSize()
        {
            return this.size;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public void AddHost()
        {
            if (this.hosts.Count < size)
            {
                this.hosts.Add(new Host(nextIP, "Host " + this.hosts.Count));
                this.nextIP.Inc();
            }
            else
            {
                MessageBox.Show("В подсети не хватает свободных адресов!!!");
                return;
            }
        }

        public List<Host> GetAllHosts()
        {
            List<Host> resHosts = new List<Host>();
            foreach (var item in this.hosts)
            {
                resHosts.Add(item);
            }
            return resHosts;
        } 
    }
}
