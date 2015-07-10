using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab_1
{
    static class Validator
    {
        public static bool ValidateIp(string ip)
        {
            string[] s = ip.Split('.');
            if (s.Length != 4) return false;
            foreach (string item in s)
            {
                if (item.Length == 0) return false;
                try
                {
                    uint value = UInt32.Parse(item);
                    if (value > 255) return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateMask(string mask)
        {
            bool ok = ValidateIp(mask);
            if (!ok) return false;
            string[] s = mask.Split('.');
            bool waszero = false;
            foreach (var item in s)
            {
                uint cur = UInt32.Parse(item);
                bool good = true;
                for (int i = 7; i >= 0; i--)
                {
                    if ((cur & ((uint) 1 << i)) == 0) waszero = true;
                    else if (waszero)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool ValidateIPandMask(uint ip, uint mask)
        {
            uint val = ip & mask;
            return ip == val;
        }
    }
}
