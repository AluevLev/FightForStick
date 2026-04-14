namespace IceFebruary
{
    public class Toggleable<T> : IInnerPossessable<T>, IToggleable where T : class
    {
        public T RawInner { get; private init; }
        public IToggle Toggle { get; private init; }
        public Toggleable(T inner, IToggle toggle)
        {
            RawInner = inner;
            Toggle = toggle;
        }
    }
}
