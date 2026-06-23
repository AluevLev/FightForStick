namespace IceFebruary
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IProvider<T> where T : struct
    {
        bool TryGet(out T value);
    }
}
