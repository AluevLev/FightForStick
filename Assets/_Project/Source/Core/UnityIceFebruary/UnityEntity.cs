namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public sealed class UnityEntity<T> //: IDestroyable<T>, IToggleable<T> where T : class, IUnityAnalog
    {
        public T RawInner { get; private set; }
        public IToggle Toggle { get; private init; }
        public UnityEntity(T inner, bool? enabled)
        {
            if (inner == null)
            {
                SetDisposed();
                return;
            }

            RawInner = inner;
            //Toggle = new UnityToggle(inner, enabled);
        }
        public bool Disposed { get; private set; }
        public void Dispose()
        {
            //UnityEngine.Object.Destroy(RawInner.Original);
            SetDisposed();
            //RawInner = null;
        }
        private void SetDisposed() => Disposed = true;
    }
}
