namespace OOP_labx
{
    public class ModuleData
    {
        protected string name;
        protected string filePath;
        protected string checkSum;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string CheckSum
        {
            get { return checkSum; }
            set { checkSum = value; }
        }

        public ModuleData()
        {
        }

    }
}
