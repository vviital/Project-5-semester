using System;

namespace SmartHomeForms
{
    public class ElectricRange : AbstractDevice
    {
        private new const string DeviceName = "Electric Range";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return new ElectricRange();
        }

        
    }
}
