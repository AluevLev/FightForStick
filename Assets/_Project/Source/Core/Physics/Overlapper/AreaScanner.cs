using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Shapes;
using IceFebruary.Space;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;

public sealed class AreaScanner : BaseEntity, IOverlapper
{
    public Component<ICollider2D>[] Colliders2D { get; private init; }
    public int Colliders2DActualLength { get; private set; }
    public bool Succes => Colliders2DActualLength > 0;
    private readonly IPhysics2D _physics2D;
    private readonly IShape _shape;
    private readonly IVector2Provider _position;
    private readonly IRotor2Provider _rotation;
    private readonly ContactFilter2D _contactFilter2D;
    public AreaScanner(IPhysics2D physics2D, IShape shape, IVector2Provider position, IRotor2Provider rotation, int collider2DBufferSize) : this(physics2D, shape, position, rotation, collider2DBufferSize, ContactFilter2D.Default) { }
    public AreaScanner(IPhysics2D physics2D, IShape shape, IVector2Provider position, IRotor2Provider rotation, int collider2DBufferSize, ContactFilter2D contactFilter)
    {
        _physics2D = physics2D;
        _shape = shape;
        _position = position;
        _rotation = rotation;
        _contactFilter2D = contactFilter;

        Colliders2D = new Component<ICollider2D>[collider2DBufferSize.ClampForArray()];
    }
    public void Overlap()
    {
        _position.TryGetSafety(out Vector2 position);
        _rotation.TryGetSafety(out Rotor2 rotation);

        UnityIceFebruary.HelpTools.Debuggers.UnityDrawer.DrawShape(_shape, position, rotation, 0.02f);

        Colliders2DActualLength = _physics2D.Overlap(_shape, position, _contactFilter2D, rotation, Colliders2D);
    }
}
