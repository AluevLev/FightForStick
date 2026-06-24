namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IVector2Provider
    {
        bool TryGet(out Vector2 value);
    }
}
