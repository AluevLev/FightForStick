namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public sealed class UnityEntity<T> : IEntity<T> where T : class, IUnityAnalog
    {
        public T RawInner { get; private set; }
        public UnityEntity(T inner, bool? enabled)
        {
            if (inner == null || inner.Original == null)
            {
                SetDisposed();
                return;
            }

            RawInner = inner;
            Enabled = enabled ?? UnityToggler.Get(RawInner.Original);
        }
        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                UnityToggler.Set(RawInner.Original, _enabled);
            }
        }
        public bool Disposed { get; private set; }
        public void Dispose()
        {
            UnityEngine.Object.Destroy(RawInner.Original);
            SetDisposed();
            RawInner = null;
        }
        private void SetDisposed() => Disposed = true;
    }
}
