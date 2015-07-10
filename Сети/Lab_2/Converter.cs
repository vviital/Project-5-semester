using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    static class Converter
    {
        public static string AddressToString(uint address)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 4; i >= 1; i--)
            {
                uint value = 0;
                for (int bit = 1; bit <= 8; bit++)
                {
                    int index = i * 8 - bit;
                    if ((address & ((uint)1 << index)) == 0) continue;
                    value |= (uint)1 << (8 - bit);
                }
                builder.Append(value);
                if (i != 1) builder.Append(".");
            }
            return builder.ToString();
        }

        public static uint StringToAdress(string source)
        {
            string[] s = source.Split('.');
            uint address = 0, cnt = 3;
            for (int i = 0; i < s.Length; ++i)
            {
                uint cur = UInt32.Parse(s[i]);
                cur <<= (int)cnt * 8;
                cnt--;
                address |= cur;
            }
            return address;
        }
    }
}
