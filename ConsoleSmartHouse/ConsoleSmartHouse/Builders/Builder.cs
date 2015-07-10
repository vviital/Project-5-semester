using System.Collections.Generic;
using ConsoleSmartHouse.DataReaders;

namespace ConsoleSmartHouse.Builders
{
    class Builder
    {
        private InputTree inputTree;
        public Builder(InputTree inputTree)
        {
            this.inputTree = inputTree;
        }

        public void BuildHouse()
        {
            List<SmartHouse> houses= new List<SmartHouse>();
            for (int i=0;i<inputTree.Node.Count;i++)
            {
                houses[i].Rooms = BuildRoom();
            }
        }

        private Room BuildRoom()
        {
            return new Room();
        }
    }
}
