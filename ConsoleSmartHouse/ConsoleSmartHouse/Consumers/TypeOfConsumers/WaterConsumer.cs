using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSmartHouse.Resources;
using ConsoleSmartHouse.Resources.TypeOfResource;

namespace ConsoleSmartHouse.Consumers.TypeOfConsumer
{
    class WaterConsumer: AConsumer
    {
        public override event EventHandler<IResource> wastedResource;
        private WaterResource resource;
 
        public WaterConsumer(int time, WaterResource resource) : base(time)
        {
            this.resource = resource;
        }

        protected override void OnTick(object sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
        {
            if (resource != null) wastedResource(sender, resource);
        }
    }
}
