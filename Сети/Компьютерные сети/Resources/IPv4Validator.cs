using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерные_сети.Resources
{
    class IPv4Validator : Validator
    {
        public override void Validate(Address address)
        {
            if (address is IPv4)
            {
                uint mask = (uint)((IPv4)address).GetMask();
                uint ip = (uint)((IPv4)address).GetIPAddress();
                bool find = false;
                for (int i = 31; i >= 0; --i)
                {
                    uint currentvalue = (uint)mask & ((uint)1 << i);
                    if (currentvalue == 0) find = true;
                    else if (find) throw new Exception("Wrong mask");
                }
            }
            else
            {
                throw new Exception("Wrong type");
            }
        }
    }
}
