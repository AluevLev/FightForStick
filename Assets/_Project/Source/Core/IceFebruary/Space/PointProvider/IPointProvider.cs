namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IPointProvider
    {
        bool TryGetPoint(out Vector2 point);
    }
}
