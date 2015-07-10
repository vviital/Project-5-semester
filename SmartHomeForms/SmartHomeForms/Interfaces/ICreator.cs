using System.Collections.Generic;

namespace SmartHomeForms
{
    public interface ICreator
    {
        void Create(House house, Dictionary<string,AbstractDevice> devices, Dictionary<string,AbstractBehavior> behaviors, string [] words);
    }
}
