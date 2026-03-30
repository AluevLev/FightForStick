namespace IceFebruary
{
    public class Destroyable<T> : IDestroyable<T> where T : class
    {
        public T RawObject { get; private init; }
        public Destroyable(T obj)
        {
            RawObject = obj;
        }
        public bool IsDestroyed { get; private set; }
        public void Destroy() => IsDestroyed = true;
    }
}
