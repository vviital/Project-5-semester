using System;

namespace SmartHomeForms
{
    public class Thermometer : AbstractSensor 
    {
        private new const string DeviceName = "Thermometer";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return new Thermometer();
        }

    }
}
