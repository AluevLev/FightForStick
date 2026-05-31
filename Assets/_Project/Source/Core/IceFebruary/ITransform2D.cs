namespace IceFebruary
{
    using IceFebruary.Space;
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface ITransform2D : IBaseEntity
    {
        Vector2 Position { get; set; }
        Rotor2 Rotation { get; set; }
        Vector2 LocalPosition { get; set; }
        Rotor2 LocalRotation { get; set; }
        Vector2 TransformDirection(Vector2 direction);
        Vector2 TransformPoint(Vector2 point);
    }
}
