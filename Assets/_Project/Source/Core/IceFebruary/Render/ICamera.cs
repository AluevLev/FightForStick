namespace IceFebruary.Render
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    [InterfaceProxy]
    public interface ICamera : IBaseEntity
    {
        Vector2 ScreenToWorldPoint(Vector2 onScreenPosition);
        Vector2 WorldToScreenPoint(Vector2 inWorldPosition);
        float Size { get; set; }
    }
}
