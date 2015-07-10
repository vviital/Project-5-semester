using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Resources
{
    class IPv4Validator : Validator
    {
        public override bool ValidateIP(object obj)
        {
            if (obj is String)
            {
                string IP = ((string)obj) + '.';
                int currentNumber = 0;
                int lastDot = -1;
                for (int i = 0; i < IP.Length; ++i)
                {
                    if (IP[i] == '.')
                    {
                        int length = i - lastDot;
                        if (length == 1 || length > 4 || currentNumber > 255) return false;
                        currentNumber = 0; lastDot = i;
                        continue;
                    }
                    if (IP[i] >= '0' && IP[i] <= '9')
                    {
                        currentNumber = currentNumber * 10 + IP[i] - '0';
                        continue;
                    }
                    return false;
                }
                return true;
            }
            else
            {
                throw new Exception();
            }
        }
        public override bool ValidateMask(object obj)
        {
            if (obj is string)
            {
                bool ok = ValidateIP(obj);
                if (ok == false) return false;
                uint currentNumber = 0;
                string mask = ((string)obj) + '.';
                uint result = 0;
                int count = 3;
                for (int i = 0; i < mask.Length; ++i)
                {
                    if (mask[i] == '.')
                    {
                        result |= currentNumber << (count * 8);
                        currentNumber = 0;
                        count--;
                    }
                    else
                    {
                        currentNumber = currentNumber * 10 + mask[i] - '0';
                    }
                }
                for (int i = 31; i >= 0; i--)
                {
                    if ((result & (((uint)1) << i)) != 0)
                    {
                        result ^= ((uint)1) << i;
                    }
                    else
                    {
                        return result.Equals(0);
                    }
                }
                return false;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
