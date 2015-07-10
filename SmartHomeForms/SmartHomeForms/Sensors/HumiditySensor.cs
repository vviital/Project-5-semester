using System;

namespace SmartHomeForms
{
    public class HumiditySensor : AbstractSensor
    {
        private new const string DeviceName = "Humidity Sensor";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return new HumiditySensor();
        }
    }
}
