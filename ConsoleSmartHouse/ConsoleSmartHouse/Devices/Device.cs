using System.Collections.Generic;
using System.Diagnostics;
using ConsoleSmartHouse.Consumers;
using ConsoleSmartHouse.Producers;

namespace ConsoleSmartHouse.Devices
{
    class Device : IDevice
    {
        private List<AConsumer> consumers;

        private List<AProducer> producers;

        public Device()
        {
            consumers = new List<AConsumer>();

            producers = new List<AProducer>();
        }

        public List<AConsumer> Consumers
        {
            get { return consumers;}
            set { consumers = value;}
        }

        public List<AProducer> Producers
        {
            get { return producers; }
            set { producers = value; }
        }

        public void On()
        {
            foreach (AConsumer consumer in consumers)
            {
                consumer.Begin();
            }
            foreach (AProducer producer in producers)
            {
                producer.Begin();
            }
        }

        public void Off()
        {
            foreach (AConsumer consumer in consumers)
            {
                consumer.End();
            }
            foreach (AProducer producer in producers)
            {
                producer.End();
            }
        }
    }
}
