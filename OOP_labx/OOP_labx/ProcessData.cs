using System.Collections.Generic;

namespace OOP_labx
{
    public class ProcessData :ModuleData
    {
        private int id;
        private List<ModuleData> moduleList;

        public ProcessData() : base()
        {
            moduleList = new List<ModuleData>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<ModuleData> ModuleList
        {
            get { return moduleList; }
            set { moduleList = value; }
        }
    }
}
