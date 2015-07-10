using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1.Resources
{
    class IPv4 : IP
    {
        private uint IP, mask;

        public IPv4()
        {
            this.validator = new IPv4Validator();
            this.parser = new IPv4Parser();
        }

        public IPv4(string IP, string mask)
        {
            this.validator = new IPv4Validator();
            this.parser = new IPv4Parser();
            SetIPAddress(IP);
            SetMask(mask);
        }

        public IPv4(uint IP, uint mask)
        {
            string ip = AddressToString(IP);
            string Mask = AddressToString(mask);
            this.validator = new IPv4Validator();
            this.parser = new IPv4Parser();
            SetIPAddress(ip);
            SetMask(Mask);
        }

        public override object GetMask()
        {
            return this.mask;
        }

        public override object GetIPAddress()
        {
            return this.IP;
        }

        public override void SetIPAddress(object value)
        {
            bool validIP = validator.ValidateIP(value);
            if (!validIP) throw new Exception();
            this.IP = (uint)parser.ParseIP(value);
        }

        public override void SetMask(object value)
        {
            bool validMask = validator.ValidateMask(value);
            if (!validMask) throw new Exception();
            this.mask = (uint)parser.ParseMask(value);
        }

        public override long GetNumberOfHosts()
        {
            unchecked
            {
                long count = (((uint) (- 1)) & mask) + 1;
                return count;
            }
        }

        public override string IPToString()
        {
            return this.AddressToString(IP);
        }

        public override string MaskToString()
        {
            return this.AddressToString(mask);
        }

        public override object Clone()
        {
            return new IPv4(this.IP, this.mask);
        }

        private string AddressToString(uint value)
        {
            StringBuilder builder = new StringBuilder();
            uint currentValue = 0;
            for (int i = 31; i >= 0; --i)
            {
                if (i%8 != 0)
                {
                    uint bitvalue = ((((uint) 1) << i) & value) == 0 ? (uint) 0 : (uint) 1;
                    currentValue = currentValue*2 + bitvalue;
                }
                else
                {
                    builder.Append(currentValue.ToString());
                    if (i != 0) builder.Append('.');
                    currentValue = 0;
                }
            }
            return builder.ToString();
        }

        public override void Inc()
        {
            uint last = this.IP;
            this.IP++;
            if ((last & this.mask) != (this.IP & mask))
            {
                this.IP = last;
                MessageBox.Show("Невозможно увеличить адресс!!!");
            }
        }
    }
}
