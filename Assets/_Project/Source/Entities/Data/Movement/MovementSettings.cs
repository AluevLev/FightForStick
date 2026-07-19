using IceFebruary.Proxy;
using IceFebruary.Space;

public readonly struct MovementSettings
{
    public float Speed { get; private init; }
    public float JumpForce { get; private init; }
    public float JumpBoost { get; private init; }
    public float LegsChangeRotationPeriod { get; private init; }
    public Rotor2 LegRest { get; private init; }
    public Rotor2 LegAmplitude { get; private init; }

    [ScriptableObjectProxy]
    public MovementSettings(float speed, float jumpForce, float jumpBoost, float legsChangeRotationPeriod, Rotor2 legRest, Rotor2 legAmplitude)
    {
        Speed = speed;
        JumpForce = jumpForce;
        JumpBoost = jumpBoost;
        LegsChangeRotationPeriod = legsChangeRotationPeriod;
        LegRest = legRest;
        LegAmplitude = legAmplitude;
    }
}
