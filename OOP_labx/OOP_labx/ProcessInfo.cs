using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labx
{
    class ProcessInfo
    {
        private string processName;
        private int id;
        private string filePath;
        private List<string> moduleList;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }

        public List<string> ModuleList
        {
            get { return moduleList; }
            set { moduleList = value; }
        }

        public ProcessInfo()
        {
            processName = string.Empty;
            id = 0;
            filePath = string.Empty;
            moduleList = new List<string>();
        }
    }
}
