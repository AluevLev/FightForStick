using IceFebruary.Physics;
using IceFebruary.Proxy;
using IceFebruary.Shapes;

public readonly struct AreaScannerSettings
{
    public IShape Shape { get; private init; }
    public int CollidersMaxCount { get; private init; }
    public ContactFilter2D ContactFilter2D { get; private init; }

    [DataObjectProxy]
    public AreaScannerSettings(IShape shape, int collidersMaxCount, ContactFilter2D contactFilter2D)
    {
        Shape = shape;
        CollidersMaxCount = collidersMaxCount;
        ContactFilter2D = contactFilter2D;
    }
}
