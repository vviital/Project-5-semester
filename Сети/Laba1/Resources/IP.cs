using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Resources
{
    abstract class IP : ICloneable
    {
        protected Validator validator;
        protected Parser parser;

        public abstract Object GetIPAddress();

        public abstract Object GetMask();

        public abstract void SetIPAddress(Object value);

        public abstract void SetMask(Object value);

        public abstract long GetNumberOfHosts();

        public abstract object Clone();

        public abstract string IPToString();

        public abstract string MaskToString();

        public abstract void Inc();
    }
}
