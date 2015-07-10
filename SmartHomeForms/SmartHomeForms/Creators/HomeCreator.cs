using System;
using System.Collections.Generic;

namespace SmartHomeForms
{
    public class HomeCreator : ICreator
    {
        public void Create(House house, Dictionary<string, AbstractDevice> devices, Dictionary<string, AbstractBehavior> behaviors, string[] words)
        {
            int curWord = 1;
            house.SetName(words[curWord++]);
            for (; curWord < words.Length; curWord++)
            {
                var newDevice = (AbstractDevice)devices[words[curWord++]].Clone();
                newDevice.SetConsumingResources(new ReSource(Convert.ToInt32(words[curWord++])));
                newDevice.SetBehavior(behaviors[words[curWord]]);
                house.SuperMeters.Add((IMeter)newDevice);

                Handler.DeviceRegistration(newDevice);
            }
        }
    }
}
