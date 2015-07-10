using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерные_сети.Resources
{
    class Handler
    {
        protected Dictionary<Address, Network> networks;

        public Handler(List<int> sizes, string addressRange)
        {
            sizes.Sort();
            sizes.Reverse();

        }

        public void ShowConsole()
        {
            StringBuilder builder = new StringBuilder();
            foreach(var item in this.networks)
            {
                builder.Append(item.ToString() + "\n");
            }
            Console.WriteLine(builder.ToString());

        }
    }
}
