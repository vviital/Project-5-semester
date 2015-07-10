using ConsoleSmartHouse.Resources;
using ConsoleSmartHouse.Resources.TypeOfResource;

namespace ConsoleSmartHouse.Counter.TypeOfCounters
{
    class ElectricalCounter :ACounter
    {
        private ElectricResource sumResource;

        public ElectricalCounter():base()
        {
            sumResource = new ElectricResource(0);
        }

        public ElectricResource SumResource
        {
            get { return sumResource; }
            set { sumResource = value; }
        }

        protected override void Counter_WastedResource(object sender, IResource resource)
        {
            sumResource.Value += resource.Value;
        }
    }
}
