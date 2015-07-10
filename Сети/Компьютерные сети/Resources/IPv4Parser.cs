using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерные_сети.Resources
{
    class IPv4Parser : Parser
    {
        public override Object Parse(Object ip, Object mask)
        {
            if ((ip is string) && (mask is string))
            {
                try
                {
                    return new IPv4(UInt32.Parse((string)ip), UInt32.Parse((string)mask));
                }
                catch
                {
                    throw new Exception("Wrong type");
                }
            }
            else
            {
                throw new Exception("Wrong type");
            }
        }
    }
}
