using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHomeForms
{
    public abstract class AbstractBehavior
    {
        public Dictionary<SourceType, double> NewDictionary()
        {
            var typeOfSource = typeof(SourceType);

           return Enum.GetValues(typeOfSource).Cast<SourceType>().ToDictionary<SourceType, SourceType, double>(item => item, item => 0);
        }

        public virtual double RandomNext()
        {
            return Random.Next(-2, 3)/Convert.ToDouble(Random.Next(3, 8));
        }

        protected static Random Random = new Random();

        public virtual Dictionary<SourceType, double> UseSource(ReSource type, HandlerEventArgs e)
        {
            return null;
        }
    }
}
