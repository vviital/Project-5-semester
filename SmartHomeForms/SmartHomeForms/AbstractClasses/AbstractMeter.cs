using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SmartHomeForms
{
    public abstract class AbstractMeter : AbstractDevice,IMeter
    {

        public readonly List<int> ConnectIdList = new List<int>();

        private List<SourceType> _meterType;

        protected Dictionary<SourceType, List<CountElement>> MeterValue;

        //improve connect To ITSELF
        protected AbstractMeter()
        {
            MeterValue = new Dictionary<SourceType, List<CountElement>>();
            _meterType = new List<SourceType>();
            ConnectToItseft();
        }

        #region Props

        public List<SourceType> GetMeterType
        {
            get { return _meterType; }
        }

        public Dictionary<SourceType, List<CountElement>> GetMeterValue
        {
            get { return MeterValue; }
        }

        #endregion

        #region Methods

        protected void InicializeMeterValue()
        {
            foreach (var type in _meterType)
            {
                MeterValue.Add(type,new List<CountElement>());
            }
        }

        public void ConnectToDevice(AbstractDevice device)
        {
            if (ConnectIdList.Contains(device.Id))
                return;
            ConnectIdList.Add(device.Id);
            device.ResourceConsumed += Metering;
            device.DisposeObject += DeviceOnDisposeObject;
        }

        private void DeviceOnDisposeObject(object sender, EventArgs eventArgs)
        {
            var device = sender as AbstractDevice;
            DisconnectFromDevice(device);
        }

        public void ConnectToItseft()
        {
            ConnectToDevice(this);
        }

        public void ConnectToHouse(House house)
        {
            foreach (var room in house.Rooms)
            {
                ConnectToRoom(room);
            }
        }

        public void ConnectToRoom(Room room)
        {
            foreach (var device in room.Devices)
            {
                ConnectToDevice(device);
            }
        }

        public void DisconnectFromDevice(AbstractDevice device)
        {
            if (!ConnectIdList.Contains(device.Id))
                return;
            ConnectIdList.Remove(device.Id);
            device.ResourceConsumed -= Metering;
            device.DisposeObject -= DeviceOnDisposeObject;
        }

        public void DisconnectFromRoom(Room room)
        {
            foreach (var device in room.Devices)
            {
                DisconnectFromDevice(device);
            }
        }

        public void DisconnectFromHouse(House house)
        {
            foreach (var room in house.Rooms)
            {
                DisconnectFromRoom(room);
            }
        }

        public void DisconnectFromItself()
        {
            DisconnectFromDevice(this);
        }

        public void SetType(SourceType type)// not inicialize every time!!!
        {
            _meterType = ReSource.GetSourceTypes(type);
            InicializeMeterValue();
        }

        [MethodImpl(MethodImplOptions.Synchronized)] 
        public void Metering(object sender, ResourceConsumedEventArgs e)
        {
            var keys = MeterValue.Keys;
            for (int i=0; i<keys.Count; i++)
            {
                var q = MeterValue[keys.ElementAt(i)].LastOrDefault();
                if (q != null && q.DateTime == e.DateTime)
                {
                    q.AddValue(e.ConsumedResource[keys.ElementAt(i)]);
                }
                else
                {
                    MeterValue[keys.ElementAt(i)].Add(new CountElement(e.DateTime));
                    MeterValue[keys.ElementAt(i)].Last().AddValue(e.ConsumedResource[keys.ElementAt(i)]);
                }  
            }
        }

        #endregion

    }
}
