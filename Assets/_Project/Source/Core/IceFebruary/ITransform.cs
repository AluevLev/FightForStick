namespace IceFebruary
{
    using IceFebruary.Space;
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface ITransform : IBaseEntity
    {
        Vector3 Position { get; set; }
        Rotor3 Rotation { get; set; }
        Vector3 LocalPosition { get; set; }
        Rotor3 LocalRotation { get; set; }
        Vector3 TransformDirection(Vector3 direction);
        Vector3 TransformPoint(Vector3 point);
    }
}
