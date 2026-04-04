namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public class UnityEntity<T> : IEntity<T> where T : class, IUnityAnalog
    {
        public T Inner { get; private set; }
        private bool _destroyed;
        public UnityEntity(T inner, bool? enabled)
        {
            Inner = inner;
            if (enabled.HasValue)
                Enabled = enabled.Value;
        }
        public bool Disposed
        {
            get
            {
                if (_destroyed)
                    return true;
                if (Inner == null || Inner.Original == null)
                    SetDestroyed();
                return _destroyed;
            }
        }
        public bool Enabled
        {
            get => UnityToggler.Get(Inner.Original);
            set => UnityToggler.Set(Inner.Original, value);
        }
        public void Dispose()
        {
            UnityEngine.Object.Destroy(Inner.Original);
            SetDestroyed();
        }
        private void SetDestroyed()
        {
            _destroyed = true;
            Inner = null;
        }
    }
}
