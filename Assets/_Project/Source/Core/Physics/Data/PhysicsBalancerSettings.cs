using IceFebruary.Proxy;
using IceFebruary;
using IceFebruary.Space;

public readonly struct PhysicsBalancerSettings
{
    public IProvider<Rotor2> Target { get; private init; }
    public float Force { get; private init; }

    [ScriptableObjectProxy]
    public PhysicsBalancerSettings(IProvider<Rotor2> target, float force)
    {
        Target = target;
        Force = force;
    }
}
