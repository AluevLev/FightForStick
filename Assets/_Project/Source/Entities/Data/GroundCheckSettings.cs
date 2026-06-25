using IceFebruary.Proxy;
using IceFebruary.Physics;
using IceFebruary.Shapes;

public readonly struct GroundCheckSettings
{
    public IShape GroundCheckShape { get; private init; }
    public ContactFilter2D ContactFilter2D { get; private init; }

    [ScriptableObjectProxy]
    public GroundCheckSettings(IShape groundCheckSize, ContactFilter2D contactFilter2D)
    {
        GroundCheckShape = groundCheckSize;
        ContactFilter2D = contactFilter2D;
    }
}
