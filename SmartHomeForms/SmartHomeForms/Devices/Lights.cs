using System;

namespace SmartHomeForms
{
    public class Lights : AbstractDevice
    {
        private new const string DeviceName = "Ligths";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return  new Lights();
        }
    }
}
