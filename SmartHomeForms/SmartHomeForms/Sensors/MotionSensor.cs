using System;
namespace SmartHomeForms
{
    public class MotionSensor : AbstractSensor
    {
        private new const string DeviceName = "Motion Sensor";

        public override string ToString()
        {
            return DeviceName + " id=" + Id + Environment.NewLine;
        }

        public override object Clone()
        {
            return new MotionSensor();
        }

    }
}
