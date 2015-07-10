using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHomeForms
{
    public class House : IDeviceContainer
    {
        public string Name { private set; get; }
        public List<Room> Rooms { private set; get; }
        public List<IMeter> SuperMeters{ private set; get; }

        public House()
        {
            Name = String.Empty;
            Rooms = new List<Room>();
            SuperMeters = new List<IMeter>();
        }

        public House(string name, List<Room> rooms, List<IMeter> superMeters)
        {
            Name = name;
            Rooms = rooms;
            SuperMeters = superMeters;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        #region IDeviceContainer methods

        public void AddDevice(AbstractDevice device)
        {

        }

        public void RemoveDevice(AbstractDevice device)
        {

        }

        #endregion

        public override string ToString()
        {
            var strb = new StringBuilder();
            strb.Append("Home : " + Name + Environment.NewLine);
            if (SuperMeters.Any())
            {
                strb.Append("supermeters :"+Environment.NewLine);
                foreach (var a in SuperMeters)
                    strb.Append(a);
            }
            if (Rooms.Any()) 
            foreach (var a in Rooms)
            {
                strb.Append(a);
            }
            return strb.ToString();
        }


        

    }
}
