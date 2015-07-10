using System.Collections.Generic;

namespace SmartHomeForms
{
    public class Behavior3 : AbstractBehavior
    {
        public override Dictionary<SourceType, double> UseSource(ReSource type, HandlerEventArgs e)
        {
            var result = new Dictionary<SourceType, double>();
            result[SourceType.ColdWater] = 1;
            result[SourceType.Electricity] = 2;
            result[SourceType.TechnicalWater] = 2;
            result[SourceType.WarmWater] = 3;
            return result;
        }

    }
}
