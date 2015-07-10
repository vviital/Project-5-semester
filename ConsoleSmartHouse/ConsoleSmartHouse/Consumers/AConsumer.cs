using System;
using System.Timers;
using ConsoleSmartHouse.Resources;
using ConsoleSmartHouse.Resources.TypeOfResource;

namespace ConsoleSmartHouse.Consumers
{
    abstract class AConsumer
    {
        public abstract event EventHandler<IResource> wastedResource;
        protected Timer consumerTimer;
        protected int id;

        public AConsumer(int time)
        {
            consumerTimer = new Timer(time);
            consumerTimer.Elapsed+=OnTick;
        }

        protected abstract void OnTick(object sender, ElapsedEventArgs elapsedEventArgs);

        public void Begin()
        {
           consumerTimer.Start();
        }

        public void End()
        {
            consumerTimer.Stop();
        }
    }
}
