using System.Collections.Generic;

namespace SmartHomeForms
{
    public class Behavior1 : AbstractBehavior
    {
        public override Dictionary<SourceType, double> UseSource(ReSource type, HandlerEventArgs e)
        {
            var result = NewDictionary();

            switch (e.DayPart)
            {
                case DayParts.Night:
                    {
                        result[SourceType.ColdWater] += 0.2;
                        result[SourceType.Electricity] += 0.3;
                        result[SourceType.TechnicalWater] += 0.4;
                        // result[SourceType.WarmWater]     =   0 
                        break;
                    }
                case DayParts.Day:
                    {
                        result[SourceType.ColdWater] += 0.7;
                        result[SourceType.Electricity] += 1.6;
                        result[SourceType.TechnicalWater] += 0.3;
                        result[SourceType.WarmWater] += 0.3;
                        break;
                    }
                default:
                    {
                        result[SourceType.ColdWater] += 1.1;
                        result[SourceType.Electricity] += 0.9;
                        result[SourceType.TechnicalWater] += 0.35;
                        result[SourceType.WarmWater] += 0.5;
                        break;
                    }
            }

            switch (e.Season)
            {
                case Seasons.Winter:
                    {
                        result[SourceType.ColdWater] += 0.05;
                        result[SourceType.Electricity] += 0.5;
                        result[SourceType.TechnicalWater] += 0.5;
                        result[SourceType.WarmWater] += 0.5;
                        break;
                    }
                case Seasons.Summer:
                    {
                        result[SourceType.ColdWater] += 0.25;
                        result[SourceType.Electricity] += 0.4;
                        // result[SourceType.TechnicalWater] = 0  летом без отопления
                        result[SourceType.WarmWater] += 0.1;
                        break;
                    }
                default:
                    {
                        result[SourceType.ColdWater] += 0.15;
                        result[SourceType.Electricity] += 0.45;
                        result[SourceType.TechnicalWater] += 0.2;
                        result[SourceType.WarmWater] += 0.25;
                        break;
                    }
            }


            //result[SourceType.ColdWater] = 0.342*dayPartVariable+0.111*seasonVariable + ;

            //correcting
            result[SourceType.ColdWater] += RandomNext();
            result[SourceType.Electricity] += RandomNext();
            result[SourceType.TechnicalWater] += RandomNext();
            result[SourceType.WarmWater] += RandomNext();
            return result;
        }
    }
}
