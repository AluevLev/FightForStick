namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public class UnityToggleable<T> : IEntity<T> where T : class, IUnityAnalog
    {
        private readonly T _inner;
        public UnityToggleable(T inner)
        {
            _inner = inner;
        }
        public bool TryGetInner(out T inner)
        {
            bool alive = _inner != null && _inner.Original != null;
            inner = alive ? _inner : null;
            return alive;
        }
        public bool Enabled
        {
            get => UnityToggler.Get(_inner.Original);
            set => UnityToggler.Set(_inner.Original, value);
        }
        public void Destroy() => UnityEngine.Object.Destroy(_inner.Original);
    }
}
