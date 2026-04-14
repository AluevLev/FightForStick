namespace IceFebruary
{
    public class InnerPossessable<T> : IInnerPossessable<T> where T : class
    {
        public T RawInner { get; private set; }
        public InnerPossessable(T rawInner)
        {
            RawInner = rawInner;
        }
    }
}
