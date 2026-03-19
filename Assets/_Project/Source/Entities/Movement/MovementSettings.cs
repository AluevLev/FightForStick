using IceFebruary.Proxy;

public readonly struct MovementSettings
{
    public float Speed { get; private init; }
    public float JumpForce { get; private init; }
    public float JumpBoost { get; private init; }

    [ScriptableObjectProxy]
    public MovementSettings(float speed, float jumpForce, float jumpBoost)
    {
        Speed = speed;
        JumpForce = jumpForce;
        JumpBoost = jumpBoost;
    }
}
