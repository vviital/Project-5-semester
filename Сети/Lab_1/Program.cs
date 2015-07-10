using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        private static string[] constant =
        {
            "Введите диапазон сети (ip адрес и маску):",
            "Введен не корректный IP адрес",
            "Введено не корректное значение маски",
            "Введенный IP адрес не является адресом сети с данной маской",
            "Введите количиство подсетей:",
            "Введите количество хостов в данной подсети:",
            "Суммарное количество хостов превосходит максимально возможное количество",
            "Сеть успешно построена!!!",
        };

        private static StreamReader reader;// = new StreamReader("D:/Программирование/Лаба 1/Lab_1/input.txt");

        static string ReadLine()
        {
            return Console.ReadLine();
            return reader.ReadLine();
        }

        static void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(constant[0]);
            string[] s = ReadLine().Split(' ');
            string address = s[0], mask = s[1];
            bool okIp = Validator.ValidateIp(address);
            bool okMask = Validator.ValidateMask(mask);
            if (!okIp)
            {
                WriteLine(constant[1]);
                return;
            }
            if (!okMask)
            {
                WriteLine(constant[2]);
                return;
            }
            uint _ip = Converter.StringToAdress(s[0]);
            uint _mask = Converter.StringToAdress(s[1]);
            bool allOk = Validator.ValidateIPandMask(_ip, _mask);
            if (!allOk)
            {
                WriteLine(constant[3]);
                return;
            }
            NetWork netWork = new NetWork();
            List<int> count = new List<int>();
            WriteLine(constant[4]);
            int n = Int32.Parse(ReadLine());
            for (int i = 0; i < n; i++)
            {
                WriteLine(constant[5]);
                int currentValue = Int32.Parse(ReadLine());
                count.Add(currentValue);
            }
            bool ok = netWork.Build(_ip, _mask, count);
            if (ok)
            {
                WriteLine(constant[7]);
                WriteLine(netWork.ShowInfoAboutSubNets());
                WriteLine("Таблица маршрутизации роутера:");
                WriteLine(netWork.GetRouter(0).GetTable());
            }
            else
            {
                WriteLine(constant[6]);
            }
        }
    }
}
