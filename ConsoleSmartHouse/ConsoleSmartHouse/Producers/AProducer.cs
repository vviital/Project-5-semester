using System;
using System.Timers;
using ConsoleSmartHouse.Attribute;
using ConsoleSmartHouse.Resources;

namespace ConsoleSmartHouse.Producers
{
    abstract class AProducer 
    {
        public abstract event EventHandler<AAtribute> productionAttribute;
        protected Timer producerTimer;

        public AProducer(int time)
        {
            producerTimer = new Timer(time);
            producerTimer.Elapsed+=OnTick;
        }

        protected abstract void OnTick(object sender, ElapsedEventArgs elapsedEventArgs);

        public void Begin()
        {
           producerTimer.Start();
        }

        public void End()
        {
            producerTimer.Stop();
        }
    }
}
