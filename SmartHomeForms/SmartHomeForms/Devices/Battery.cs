using System;

namespace SmartHomeForms
{
    class Battery : AbstractDevice
    {
        private new const string DeviceName = "Battery";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return new Battery();
        }
    }
}
