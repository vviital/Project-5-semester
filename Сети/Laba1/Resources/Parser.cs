using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Resources
{
    abstract class Parser
    {
        public abstract Object ParseIP(Object source);

        public abstract Object ParseMask(Object source);
    }
}
