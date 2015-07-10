namespace SmartHomeForms
{
    public interface IConnector : IDisconnector
    {
        void ConnectToHouse(House house);
        void ConnectToRoom(Room room);
        void ConnectToDevice(AbstractDevice device);
        void ConnectToItseft();
    }
}
