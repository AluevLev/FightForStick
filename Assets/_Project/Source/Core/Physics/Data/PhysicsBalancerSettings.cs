using IceFebruary.Proxy;
using IceFebruary.Space.Rotor2Provider;

public readonly struct PhysicsBalancerSettings
{
    public IRotor2Provider Target { get; private init; }
    public float Force { get; private init; }

    [ScriptableObjectProxy]
    public PhysicsBalancerSettings(IRotor2Provider target, float force)
    {
        Target = target;
        Force = force;
    }
}
