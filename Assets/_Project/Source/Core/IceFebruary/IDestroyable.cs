namespace IceFebruary
{
    public interface IDestroyable<T>
    {
        T RawObject { get; }
        bool IsDestroyed { get; }
        void Destroy();
    }
}
