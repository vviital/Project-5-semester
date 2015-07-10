using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Resources
{
    class IPv4Parser : Parser
    {
        public override Object ParseIP(object source)
        {
            if (source is string)
            {
                uint currentNumber = 0;
                uint result = 0;
                string IP = ((string)source) + '.';
                int count = 3;
                for (int i = 0; i < IP.Length; ++i)
                {
                    if (IP[i] == '.')
                    {
                        result |= currentNumber << (count * 8);
                        currentNumber = 0;
                        count--;
                    }
                    else
                    {
                        currentNumber = currentNumber * 10 + IP[i] - '0';
                    }
                }
                return result;
            }
            else
            {
                throw new Exception();
            }
        }

        public override object ParseMask(object source)
        {
            return ParseIP(source);
        }
    }
}
