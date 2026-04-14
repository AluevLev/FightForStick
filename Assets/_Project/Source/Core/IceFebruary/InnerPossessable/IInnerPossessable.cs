namespace IceFebruary
{
    public interface IInnerPossessable<out T> where T : class
    {
        T RawInner { get; }
    }
}
