using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SmartHomeForms
{
    public class DataReader
    {
        private string _input;
        private readonly StreamReader _reader;
        private readonly List<string> _append;

        public List<string[]> Input
        {
            private set;
            get;
        }

        public DataReader(string filename)
        {
            _reader = new StreamReader(filename);
            Input = new List<string[]>();
            _append = new List<string>();
            InicializeList();
        }

        private void InicializeList()
        {
            _append.Add("Home");
            _append.Add("Room");
        }

        public void Parse()
        {
            _input = _reader.ReadToEnd();
            var regex = new Regex(@"\b" + @"\w" + "+" + @"\b", RegexOptions.IgnoreCase);
            var listContainer = new List<string>();

            var appearance = new List<int>();

            foreach (Match a in regex.Matches(_input))
            {
                listContainer.Add(a.Value);
                if (_append.Contains(a.Value)) 
                {
                    appearance.Add(listContainer.Count - 1);
                }
            }

            int listCount = listContainer.Count;

            for (int i = 0; i < appearance.Count; i++)
            {
                Input.Add(GetLine(listContainer, appearance[i], LastIndex(appearance, listCount, i)));
            }

            _reader.Close();
        }

        private static int LastIndex(List<int> appearance, int listCount, int i)
        {
            if (i < appearance.Count - 1)
            {
                return appearance[i+1];
            }
            return listCount ;
        }

        private static string[] GetLine(List<string> listContainer,  int i, int last)
        {
            var resultMas = new List<string> {listContainer[i++]};
            while (i < last)
            {
                resultMas.Add(listContainer[i++]);
            }
            return resultMas.ToArray();
        }
    }
}
