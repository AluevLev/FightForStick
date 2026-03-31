namespace IceFebruary
{
    public interface IInnerPossessable<out T>
    {
        T Inner { get; }
        bool Alive { get; }
        void Destroy();
    }
}
