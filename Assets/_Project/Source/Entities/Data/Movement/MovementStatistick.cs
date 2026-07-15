using IceFebruary.Proxy;

public readonly struct MovementStatistick
{
    public float Speed { get; private init; }
    public float JumpForce { get; private init; }
    public float JumpBoost { get; private init; }

    [ScriptableObjectProxy]
    public MovementStatistick(float speed, float jumpForce, float jumpBoost)
    {
        Speed = speed;
        JumpForce = jumpForce;
        JumpBoost = jumpBoost;
    }
}
