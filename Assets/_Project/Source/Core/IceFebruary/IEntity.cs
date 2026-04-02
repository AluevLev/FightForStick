namespace IceFebruary
{
    public interface IEntity<T> where T : class
    {
        bool TryGetInner(out T inner);
        bool Enabled { get; set; }
        void Destroy();
    }
}
