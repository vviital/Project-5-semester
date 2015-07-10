using ConsoleSmartHouse.Resources;

namespace ConsoleSmartHouse.Sensors
{
    interface ISensor
    {
        void Calibrate(Resource resource );
        Resource CurrentValue();
    }
}
