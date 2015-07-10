using System.IO;
using System.Linq;
using ConsoleSmartHouse.DataReaders;

namespace ConsoleSmartHouse.DataReaders
{
    class DataReader
    {
        private StreamReader streamReader;
        public DataReader(string fileName)
        {
            streamReader = new StreamReader(fileName);
        }

        public InputTree ReadFromFile()
        {
            InputTree inputTree = new InputTree();
            Read(inputTree);
            return inputTree;
        }

        private void Read(InputTree inputTree)
        {
            while (true)
            {
            string str = streamReader.ReadLine();
            if (str == "/")
            {
                if (inputTree.Node.Count==1)
                {
                    if (inputTree.Node[0].Data == "")
                    {
                        inputTree.Node.Clear();
                    }
                }
                return;
            }
            inputTree.Data = str;
            InputTree newTree = new InputTree();
            inputTree.Node.Add(newTree);
            Read(newTree);
            }
            
        }

    }
}
