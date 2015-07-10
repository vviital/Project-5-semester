using System;
using System.Timers;
using ConsoleSmartHouse.Attribute;
using ConsoleSmartHouse.Resources;

namespace ConsoleSmartHouse.Producers.TypeOfProducer
{
    class TemperatureProducer:AProducer
    {
        public override event EventHandler<AAtribute> productionAttribute;

        public TemperatureProducer(int time) : base(time)
        {

        }

        

        protected override void OnTick(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            //if (resource != null) wastedResource(sender, resource);
        }
    }
}
