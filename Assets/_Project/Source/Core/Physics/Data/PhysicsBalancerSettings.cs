using IceFebruary.Space.AngleProvider;
using IceFebruary.Proxy;

public readonly struct PhysicsBalancerSettings
{
    public IAngleProvider Target { get; private init; }
    public float Force { get; private init; }

    [ScriptableObjectProxy]
    public PhysicsBalancerSettings(IAngleProvider target, float force)
    {
        Target = target;
        Force = force;
    }
}
