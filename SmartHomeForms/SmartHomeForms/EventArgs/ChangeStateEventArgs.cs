using System;
namespace SmartHomeForms
{
    public class ChangeStateEventArgs : EventArgs
    {
        public bool Enabled { private set; get; }

        public ChangeStateEventArgs(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
