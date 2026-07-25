using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Shapes;
using IceFebruary.Space;

public interface IOverlapper : IBaseEntity
{
    Component<ICollider2D>[] Colliders2D { get; }
    int Colliders2DActualLength { get; }
    bool Succes { get; }
    void Overlap(IShape shape = null, Vector2? position = null, Rotor2? rotation = null, ContactFilter2D? contactFilter2D = null);
}
