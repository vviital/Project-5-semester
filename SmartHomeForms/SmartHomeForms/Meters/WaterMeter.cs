using System;
using System.Linq;
using System.Text;

namespace SmartHomeForms
{
    public class WaterMeter : AbstractMeter
    {
        private new const string DeviceName = "Watermeter";

        public WaterMeter()
        {
            SetType(SourceType.ColdWater | SourceType.WarmWater | SourceType.TechnicalWater);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(DeviceName + " id=" + Id + Environment.NewLine);
            foreach (var type in MeterValue.Keys)
            {
                var average = MeterValue[type].Sum(x=>x.Value);
                sb.AppendLine(string.Format("{0}{1}{2} ({3})", type, ' ', average.ToString("F"), (average/MeterValue[type].Count).ToString("F")));
            }
            return sb.ToString();
        }

        public override object Clone()
        {
            return new WaterMeter();
        }

    }
}
