using System;

namespace SmartHomeForms
{
    public class Washstand : AbstractDevice
    {
        private new const string DeviceName = "Washstand";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return new Washstand();
        }

        
    }
}
