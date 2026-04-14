namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public class UnityToggleable<T> : IInnerPossessable<T>, IToggleable where T : class, IUnityAnalog //DELETE
    {
        public T RawInner { get; private init; }
        public IToggle Toggle { get; private init; }
        public UnityToggleable(T inner, bool? enabled)
        {
            RawInner = inner;
            //Toggle = new UnityToggle(inner, enabled);
        }
    }
}
