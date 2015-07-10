using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSmartHouse
{
    class SmartHouse
    {
        private List<Room> rooms;

        public SmartHouse()
        {
            rooms = new List<Room>();
        }

        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }
    }
}
