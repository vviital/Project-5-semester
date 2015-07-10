using System;
using System.Collections.Generic;

namespace SmartHomeForms
{
    public class ResourceConsumedEventArgs : EventArgs
    {
        public Dictionary<SourceType, double> ConsumedResource { private set; get; }

        public DateTime DateTime { private set; get; }

        public ResourceConsumedEventArgs(Dictionary<SourceType, double> consumedResource, DateTime dateTime)
        {
            ConsumedResource = consumedResource;
            DateTime = dateTime;
        }
    }
}
