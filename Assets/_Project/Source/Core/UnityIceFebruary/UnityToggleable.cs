namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public class UnityToggleable<T> : IToggleable<T> where T : class, IUnityAnalog
    {
        private readonly T _inner;
        public UnityToggleable(T inner)
        {
            _inner = inner;
        }
        public T Inner => Alive ? _inner : null;
        public bool Alive => _inner != null && _inner.Original != null;
        public bool Enabled
        {
            get => Alive && UnityToggler.Get(_inner.Original);
            set
            {
                if (Alive)
                    UnityToggler.Set(_inner.Original, value);
            }
        }
        public void Destroy() => UnityEngine.Object.Destroy(_inner.Original);
    }
}
