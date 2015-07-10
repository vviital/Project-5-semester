using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерные_сети.Resources
{
    class IPv4 : Address
    {
        protected uint IP;
        protected uint mask;
        
        public IPv4()
        {
            this.parser = new IPv4Parser();
            this.validator = new IPv4Validator();
        }

        public IPv4(uint ip, uint mask)
        {
            this.IP = ip;
            this.mask = mask;
            this.parser = new IPv4Parser();
            this.validator = new IPv4Validator();
            this.validator.Validate(this);
        }

        public IPv4(string ip, string mask)
        {
            this.parser = new IPv4Parser();
            IPv4 current = (IPv4)parser.Parse(ip, mask);
            this.IP = current.IP;
            this.mask = current.mask;
            this.validator = new IPv4Validator();
            this.validator.Validate(this);
        }


        public override Address GetNetworkAdress()
        {
            return new IPv4(this.IP & this.mask, this.mask);
        }

        public override object GetIPAddress()
        {
            return this.IP;
        }

        public override object GetMask()
        {
            return this.mask;
        }
    }
}
