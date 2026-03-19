using IceFebruary.Space;
using IceFebruary.Proxy;
using IceFebruary.Physics;

public readonly struct GroundCheckSettings
{
    public Vector2 GroundCheckSize { get; private init; }
    public ContactFilter2D ContactFilter2D { get; private init; }

    [ScriptableObjectProxy]
    public GroundCheckSettings(Vector2 groundCheckSize, ContactFilter2D contactFilter2D)
    {
        GroundCheckSize = groundCheckSize;
        ContactFilter2D = contactFilter2D;
    }
}
