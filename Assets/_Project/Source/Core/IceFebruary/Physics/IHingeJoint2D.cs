namespace IceFebruary.Physics
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    [InterfaceProxy]
    public interface IHingeJoint2D : IBaseEntity
    {
        Vector2 Anchor { get; set; }
        IRigidbody2D ConnectedBody { get; set; }
    }
}

