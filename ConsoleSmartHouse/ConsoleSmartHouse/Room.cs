

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSmartHouse.Devices;

namespace ConsoleSmartHouse
{
    class Room
    {
        private List<Device> devices;

        public List<Device> Devices
        {
            get { return devices; }
            set { devices = value; }
        }

        public Room()
        {
            devices = new List<Device>();
        }
    }
}
