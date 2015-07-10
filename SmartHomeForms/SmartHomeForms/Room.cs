using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHomeForms
{
    public class Room : IDeviceContainer
    {
        public string Name { private set; get; }
        public List<AbstractSensor> Sensors { private set; get; }
        public List<AbstractMeter> Meters { private set; get; }
        public List<AbstractDevice> Devices { private set; get; }
        public int IdRoom {  private set; get; }

        #region IDeviceContainer methods

        public void AddDevice(AbstractDevice device)
        {

        }

        public void RemoveDevice(AbstractDevice device)
        {

        }

        #endregion

        public Room(string name)
        {
            Name = name;
            Sensors = new List<AbstractSensor>();
            Meters = new List<AbstractMeter>();
            Devices = new List<AbstractDevice>();
            IdRoom = Builder.IdRoom++;
        }

        public Room(List<AbstractSensor> listSensor, List<AbstractMeter> listMeter, List<AbstractDevice> devices, string name)
        {
            Name = name;
            Sensors = listSensor;
            Meters = listMeter;
            Devices = devices;
            IdRoom = Builder.IdRoom++;
        }

        public override string ToString()
        {
            var strb = new StringBuilder();
            strb.AppendFormat("{0}Room: {1} ({2}){0}", Environment.NewLine, Name, IdRoom);

            
            //var onlyDev = Devices.Where(x => !(x is IMeter) && !(x is ISensor)).ToList();

            //if (onlyDev.Any())
            //{
            //    strb.Append("All devices : " + Environment.NewLine);
            //    foreach (var item in onlyDev)
            //    {
            //        strb.Append(item);
            //    }
            //}

            //if (Sensors.Any())
            //{
            //    strb.Append("sensors : " + Environment.NewLine);
            //    foreach (var item in Sensors)
            //    {
            //        strb.Append(item);
            //    }
            //}

            //if (!Meters.Any()) return strb.ToString();

            strb.Append("meters : " + Environment.NewLine);
            foreach (var item in Meters)
            {
                strb.Append(item);
            }

            return strb.ToString();
        }



        
    }
}
