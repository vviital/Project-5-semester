using System;

namespace SmartHomeForms
{
    public abstract class AbstractDevice : IDevice, IDisposable
    {
        private static int _id;
        protected string DeviceName;

        #region Props

        public string Name {
            get { return DeviceName; }
        }
        public int Id { private set; get; }
        public  bool IsEnabled { private set; get; }
        public ReSource ConsumingResources { private set; get; }
        public AbstractBehavior Behavior { private set; get; }

        #endregion

        #region Setters

        public void SetConsumingResources(ReSource resource)
        {
            ConsumingResources = resource;
        }

        public void SetBehavior(AbstractBehavior behavior)
        {
            Behavior = behavior;
        }

        #endregion

        protected AbstractDevice()///////////
        {
            Id = _id++;
            IsEnabled = true;
        }

        #region Methods

        public virtual void UseResource(object sender, HandlerEventArgs e)
        {
            var consumedValues = Behavior.UseSource(ConsumingResources, e);
            var args = new ResourceConsumedEventArgs( IsEnabled ? consumedValues : Behavior.NewDictionary(), e.DateTime);
            OnResourceConsumed(this,args);
        }

        public virtual object Clone()
        {
            return new object();
        }

        public virtual void OnResourceConsumed(object sender, ResourceConsumedEventArgs e)
        {
            var handler = ResourceConsumed;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public virtual void OnStateChanged(object sender, ChangeStateEventArgs e)
        {
            var handler = StateChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public virtual void OnDispose(object sender, EventArgs e)
        {
            var handler = DisposeObject;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        #endregion

        #region Events
 
        public event EventHandler<ResourceConsumedEventArgs> ResourceConsumed;
       
        public event EventHandler<ChangeStateEventArgs> StateChanged;

        public event EventHandler DisposeObject;
       
        #endregion

        public void Dispose()
        {
            Handler.UseSource -= UseResource;
            OnDispose(this,new EventArgs());
        }
    }
}
