using System;

namespace SmartHomeForms
{
    public interface IStateChanger
    {
        void OnStateChanged(object sender, ChangeStateEventArgs eventArgs);
        event EventHandler<ChangeStateEventArgs> StateChanged;
    }
}
