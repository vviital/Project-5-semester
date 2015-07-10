using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHomeForms
{
    public class RoomCreator : ICreator
    {

        public void Create(House house, Dictionary<string, AbstractDevice> devices, Dictionary<string,AbstractBehavior> behaviors, string[] words)
        {
            int curWord = 1;
            var roomName = words[curWord++];
            var roomDev = new List<AbstractDevice>();

            for (; curWord < words.Length; curWord++)
            {
                var newDevice = (AbstractDevice)devices[words[curWord++]].Clone(); // new device for room

                int sourceType = Convert.ToInt32(words[curWord++]); // type of source as a number
                newDevice.SetConsumingResources(new ReSource(sourceType)); // initialize device's Resource

                newDevice.SetBehavior(behaviors[words[curWord]]); // initialize device's Behavior

                roomDev.Add(newDevice); // add new device to room

                Handler.DeviceRegistration(newDevice);
            }

            var roomMet = roomDev.Where(x => x is AbstractMeter).Cast<AbstractMeter>().ToList(); // choose meters

            var roomSens = roomDev.Where(x => x is AbstractSensor).Cast<AbstractSensor>().ToList(); // choose sensors

            house.Rooms.Add(new Room(roomSens,roomMet,roomDev,roomName)); // add a new Room to house
            
        }
    }
}
