using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PhysicsLimbConfig
{
    public IRigidbody2D Rigidbody2D { get; private init; }
    public PhysicsBalancerSettings Settings { get; private init; }

    [FieldProxy]
    public PhysicsLimbConfig(IRigidbody2D rigidbody2D, PhysicsBalancerSettings settings)
    {
        Rigidbody2D = rigidbody2D;
        Settings = settings;
    }
}
