using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Компьютерные_сети.Resources
{
    abstract class Address
    {
        protected Parser parser;
        protected Validator validator;

        public abstract Address GetNetworkAdress();

        public abstract Object GetIPAddress();

        public abstract Object GetMask();
    }
}
