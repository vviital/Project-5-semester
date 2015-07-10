using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Компьютерные_сети.Resources;
using System.IO;

namespace Компьютерные_сети
{
    class Program
    {
        static StreamReader reader = new StreamReader("input.txt");

        static void Main(string[] args)
        {
            int count = Int32.Parse(reader.ReadLine());
            string addressRange = reader.ReadLine();
            List<int> sizes = new List<int>();
            for (int i = 0; i < count; i++)
            {
                try
                {
                    int current = Int32.Parse(reader.ReadLine());
                    sizes.Add(current);
                }
                catch
                {
                    throw new Exception("i = " + i.ToString());
                }
            }
            Handler handler = new Handler(sizes, addressRange);

            handler.ShowConsole();
            
        }
    }
}
