using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Resources
{
    abstract class Validator
    {
        public abstract bool ValidateIP(Object obj);

        public abstract bool ValidateMask(Object obj);
    }
}
