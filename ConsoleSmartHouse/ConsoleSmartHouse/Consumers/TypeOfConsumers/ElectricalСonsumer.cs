using System;
using ConsoleSmartHouse.Resources;
using ConsoleSmartHouse.Resources.TypeOfResource;
using ConsoleSmartHouse.Consumers;

namespace ConsoleSmartHouse.Consumers.TypeOfConsumer
{
    class ElectricalСonsumer : AConsumer
    {
        public override event EventHandler<IResource> wastedResource;
        private ElectricResource resource;
 
        public ElectricalСonsumer(int time, ElectricResource resource) : base(time)
        {
            this.resource = resource;
        }
        protected override void OnTick(object sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            if (resource != null) wastedResource(sender, resource);
        }
    }
}
