namespace IceFebruary
{
    public interface IToggleable<out T> : IInnerPossessable<T>
    {
        bool Enabled { get; set; }
    }
}
