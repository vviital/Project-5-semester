using ConsoleSmartHouse.Consumers;
using ConsoleSmartHouse.Resources;

namespace ConsoleSmartHouse.Counter
{
    abstract class ACounter
    {
        protected abstract void Counter_WastedResource(object sender, IResource resource);
        protected int id;

        public void ConnectToConsumer(AConsumer consumer)
        {
            consumer.wastedResource+=Counter_WastedResource;
        }

        public ACounter()
        {
            
        }

    }
}
