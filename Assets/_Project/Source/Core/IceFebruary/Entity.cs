namespace IceFebruary
{
    public class Entity<T> : IEntity<T> where T : class
    {
        public T Inner { get; private set; }
        private bool _destroyed;
        public Entity(T inner, bool enabled = true)
        {
            Inner = inner;
            Enabled = enabled;
        }
        public bool Disposed
        {
            get
            {
                if (_destroyed)
                    return true;
                if (Inner == null)
                    _destroyed = true;
                return _destroyed;
            }
        }
        public bool Enabled { get; set; }
        public void Dispose()
        {
            _destroyed = true;
            Inner = null;
        }
    }
}
