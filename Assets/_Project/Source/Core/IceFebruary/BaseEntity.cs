namespace IceFebruary
{
    public abstract class BaseEntity : IBaseEntity
    {
        public bool Destroyed { get; protected set; } = false;
        protected bool _enabled = true;
        public virtual bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }
        public virtual void Destroy()
        {
            Destroyed = true;
        }
    }
}
