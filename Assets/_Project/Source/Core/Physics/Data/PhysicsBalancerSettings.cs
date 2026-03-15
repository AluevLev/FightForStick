using IceFebruary.Space.PointProvider;
using IceFebruary.Proxy;

public readonly struct PhysicsBalancerSettings
{
    public IPointProvider Target { get; init; }
    public float Force { get; init; }

    [GenerateScriptableObjectProxy]
    public PhysicsBalancerSettings(IPointProvider target, float force)
    {
        Target = target;
        Force = force;
    }
}
