using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleSmartHouse.Consumers.TypeOfConsumer;
using ConsoleSmartHouse.Counter.TypeOfCounters;
using ConsoleSmartHouse.DataReaders;
using ConsoleSmartHouse.Devices;
using ConsoleSmartHouse.Resources;
using ConsoleSmartHouse.Resources.TypeOfResource;
using System.Threading;
using ConsoleSmartHouse.DataReaders;

namespace ConsoleSmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartHouse smartHouse = new SmartHouse();
            smartHouse.Rooms.Add(new Room());
            smartHouse.Rooms[0].Devices.Add(new Device());
            ElectricalСonsumer electricalСonsumer = new ElectricalСonsumer(1000, new ElectricResource(1));
            ElectricalCounter electricalCounter = new ElectricalCounter();
            electricalCounter.ConnectToConsumer(electricalСonsumer);
            smartHouse.Rooms[0].Devices[0].Consumers.Add(electricalСonsumer);
            smartHouse.Rooms[0].Devices[0].On();
            DataReader dataReader = new DataReader("input.txt");
            InputTree inputTree = dataReader.ReadFromFile();
            while (true)
            {
               Thread.Sleep(100);
            }
        }
    }
}
