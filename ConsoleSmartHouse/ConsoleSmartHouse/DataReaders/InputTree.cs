using System.Collections.Generic;

namespace ConsoleSmartHouse.DataReaders
{
    class InputTree
    {
        private string data;
        private List<InputTree> node;

        public InputTree()
        {
            data = string.Empty;
            node = new List<InputTree>();
        }

        public InputTree(string data)
        {
            this.data = data;
            node = new List<InputTree>();
        }
       
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        public List<InputTree> Node
        {
            get { return node; }
            set { node = value; }
        }
    }
}
