using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PhysicsLimbSettings
{
    public IRigidbody2D Rigidbody2D { get; private init; }
    public PhysicsBalancerSettings BalancerSettings { get; private init; }

    [FieldProxy]
    public PhysicsLimbSettings(IRigidbody2D rigidbody2D, PhysicsBalancerSettings balancerSettings)
    {
        Rigidbody2D = rigidbody2D;
        BalancerSettings = balancerSettings;
    }
}
