using System.Collections.Generic;

namespace SmartHomeForms
{
    class Builder
    {
        static public int IdRoom { set; get; }

        private readonly DataReader _dr;
        private readonly House _house;
        public House GetHouse
        {
            get
            {
                return _house;
            }
        }

        private readonly Dictionary<string, ICreator> _creationDict;
        public Dictionary<string, AbstractDevice> Devices { private set; get; }
        public Dictionary<string, AbstractBehavior> Behaviors { private set; get; }

        public Builder(string filename)
        {
            _house = new House();
            _creationDict = new Dictionary<string, ICreator>();
            Devices = new Dictionary<string, AbstractDevice>();
            Behaviors = new Dictionary<string, AbstractBehavior>();
            _dr = new DataReader(filename);
            InicializeDictionary();
            CreateHome();
        }

        private void InicializeDictionary() 
        {
            _creationDict.Add("Home", new HomeCreator());
            _creationDict.Add("Room", new RoomCreator());

            Devices.Add("electricitymeter", new ElectricityMeter());
            Devices.Add("watermeter", new WaterMeter());
            Devices.Add("thermometer", new Thermometer());
            Devices.Add("battery", new Battery());
            Devices.Add("washstand", new Washstand());
            Devices.Add("lights", new Lights());
            Devices.Add("electricrange", new ElectricRange());
            Devices.Add("motionsensor", new MotionSensor());
            Devices.Add("humiditysensor", new HumiditySensor());

            Behaviors.Add("device1",new Behavior1()); //событие при котором изменяется режим потребления (по времени)
            Behaviors.Add("meter1", new Behavior2());
            Behaviors.Add("sensor1",new Behavior3());
        }

        public void CreateHome()
        {
            _dr.Parse();
            const int firstWord = 0;
            var homeInfo = _dr.Input;
            foreach (var line in homeInfo)
            {
                _creationDict[line[firstWord]].Create(_house, Devices, Behaviors, line);
            }
            foreach (var meter in _house.SuperMeters)
            {
                meter.ConnectToHouse(_house);
            }
            foreach (var room in _house.Rooms)
            {
                foreach (var meter in room.Meters)
                {
                    meter.ConnectToRoom(room);
                }
            }
        }
    }
}
