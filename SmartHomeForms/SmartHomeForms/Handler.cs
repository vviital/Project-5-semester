using System;
using System.Collections.Generic;
using System.Timers;

namespace SmartHomeForms
{
    static public class Handler //observer             
    {
        private static readonly List<int> DeviceIdList = new List<int>(); 

        public static void DeviceRegistration(AbstractDevice device)
        {
            if (DeviceIdList.Contains(device.Id))
                return;
            DeviceIdList.Add(device.Id);
            UseSource += device.UseResource;
            device.StateChanged += Device_StateChanged;
            Device_StateChanged(device,new ChangeStateEventArgs(device.IsEnabled));
        }

        private static void Device_StateChanged(object sender, ChangeStateEventArgs e)
        {
            if (e.Enabled)
            {
                var device = sender as AbstractDevice;
                if (device != null)
                    UseSource += device.UseResource;
            }
            else
            {
                if (UseSource != null)
                {
                    var device = sender as AbstractDevice;
                    if (device != null)
                        UseSource -= device.UseResource;
                }
            }
        }

        public static void OnTimerTick(object sender, EventArgs e)
        {
            var args = new HandlerEventArgs();
            OnUseSource(null,args);
        }
        
        static private void OnUseSource(object sender, HandlerEventArgs e)
        {
            var handler = UseSource;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static event EventHandler<HandlerEventArgs> UseSource;
        
    }
}
