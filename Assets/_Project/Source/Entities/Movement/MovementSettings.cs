using IceFebruary.Proxy;

public readonly struct MovementSettings
{
    public float Speed { get; init; }
    public float JumpForce { get; init; }
    public float JumpBoost { get; init; }

    [GenerateScriptableObjectProxy]
    public MovementSettings(float speed, float jumpForce, float jumpBoost)
    {
        Speed = speed;
        JumpForce = jumpForce;
        JumpBoost = jumpBoost;
    }
}
