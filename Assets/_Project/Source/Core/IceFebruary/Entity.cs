namespace IceFebruary
{
    public sealed class Entity<T> : IEntity<T> where T : class
    {
        public T RawInner { get; private set; }
        public Entity(T inner, bool enabled = true)
        {
            if (inner == null)
            {
                SetDisposed();
                return;
            }

            RawInner = inner;
            Enabled = enabled;
        }
        public bool Enabled { get; set; }
        public bool Disposed { get; private set; }
        public void Dispose()
        {
            SetDisposed();
            RawInner = null;
        }
        private void SetDisposed() => Disposed = true;
    }
}
