using System;
using System.Linq;
using System.Text;

namespace SmartHomeForms
{
    public class ElectricityMeter : AbstractMeter
    {
        private new const string DeviceName = "Electricitymeter";

        public ElectricityMeter()
        {
            SetType(SourceType.Electricity);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DeviceName + " id=" + Id + Environment.NewLine);
            foreach (var type in MeterValue.Keys)
            {
                var all = MeterValue[type].Sum(x=>x.Value);
                var average = all/MeterValue[type].Count;
                sb.AppendLine(string.Format("{0}{1}{2} ({3})", type, ' ', all.ToString("F"), average.ToString("F")));
                
            }
            return sb.ToString();
        }

        public override object Clone()
        {
            return new ElectricityMeter();
        }

    }
}
