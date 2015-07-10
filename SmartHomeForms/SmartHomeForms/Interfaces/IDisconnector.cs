namespace SmartHomeForms
{
    public interface IDisconnector
    {
        void DisconnectFromDevice(AbstractDevice device);
        void DisconnectFromRoom(Room room);
        void DisconnectFromHouse(House house);
        void DisconnectFromItself();
    }
}
