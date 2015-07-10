using System;

namespace SmartHomeForms
{
    public interface IResourceConsumer
    {
        void OnResourceConsumed(object sender, ResourceConsumedEventArgs e);
        event EventHandler<ResourceConsumedEventArgs> ResourceConsumed;
    }
}