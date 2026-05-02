namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D : IBaseEntity
    {
        int Overlap(IShape shape, Vector2 position, Rotor2? rotor = null, ContactFilter2D? contactFilter2D = null, Component<ICollider2D>[] result = null);
    }
}
