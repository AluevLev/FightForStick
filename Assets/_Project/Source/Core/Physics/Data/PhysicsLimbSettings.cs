using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PhysicsLimbSettings
{
    public IEntity<IRigidbody2D> Rigidbody2D { get; private init; }
    public PhysicsBalancerSettings BalancerSettings { get; private init; }

    [Proxy]
    public PhysicsLimbSettings(IEntity<IRigidbody2D> rigidbody2D, PhysicsBalancerSettings balancerSettings)
    {
        Rigidbody2D = rigidbody2D;
        BalancerSettings = balancerSettings;
    }
}
