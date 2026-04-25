namespace UnityIceFebruary
{
    /*
    using UnityIceFebruary.Components;

    public sealed class UnityToggleable<T> : IInnerPossessable<T>, IToggleable where T : class, IUnityAnalog
    {
        public T RawInner { get; private init; }
        
        public UnityToggleable(T inner, bool? enabled = null)
        {
            RawInner = inner;

            if (enabled.HasValue)
                Enabled = enabled.Value;
            else
                _enabled = UnityToggler.Get(RawInner.Original);
        }
    }
    */
}
