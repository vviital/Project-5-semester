using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерные_сети.Resources
{
    class Host
    {
        protected Address address;

        public Host() { }

        public Host(Address address)
        {
            this.address = address;
        }
    }
}
