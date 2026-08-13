using IceFebruary.Proxy;
using IceFebruary.Space;

public readonly struct MovementSettings
{
    public float Speed { get; private init; }
    public float JumpSpeed { get; private init; }
    public float SneakBoost { get; private init; }
    public float JumpBoost { get; private init; }
    public float LegsChangeRotationPeriod { get; private init; }
    public Rotor2 LegRest { get; private init; }
    public Rotor2 LegAmplitude { get; private init; }

    [DataObjectProxy]
    public MovementSettings(float speed, float jumpSpeed, float jumpBoost, float sneakBoost,
        float legsChangeRotationPeriod, Rotor2 legRest, Rotor2 legAmplitude)
    {
        Speed = speed;
        JumpSpeed = jumpSpeed;
        JumpBoost = jumpBoost;
        SneakBoost = sneakBoost;
        LegsChangeRotationPeriod = legsChangeRotationPeriod;
        LegRest = legRest;
        LegAmplitude = legAmplitude;
    }
}
