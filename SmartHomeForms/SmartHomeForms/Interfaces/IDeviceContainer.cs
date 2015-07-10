namespace SmartHomeForms
{
    interface IDeviceContainer
    {
        void AddDevice(AbstractDevice device);
        void RemoveDevice(AbstractDevice device);
    }
}
