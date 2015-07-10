using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSmartHouse.Devices
{
    interface IDevice
    {
        void On();
        void Off();
    }
}
