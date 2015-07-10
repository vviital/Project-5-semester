using System;

namespace SmartHomeForms
{
    public interface IDevice : ICloneable,IResourceConsumer,IStateChanger
    {
        void UseResource(object sender, HandlerEventArgs e); // внутри инициируется новое событие
    }
}
