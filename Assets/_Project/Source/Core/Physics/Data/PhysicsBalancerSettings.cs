using IceFebruary.Space.PointProvider;
using IceFebruary.Proxy;

public readonly struct PhysicsBalancerSettings
{
    public IPointProvider Target { get; private init; }
    public float Force { get; private init; }

    [ScriptableObjectProxy]
    public PhysicsBalancerSettings(IPointProvider target, float force)
    {
        Target = target;
        Force = force;
    }
}
