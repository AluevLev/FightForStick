namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D : IBaseEntity
    {
        int Overlap(IShape shape, Vector2 position, Rotor2 rotor, ContactFilter2D contactFilter2D, Component<ICollider2D>[] result = null);
        int Overlap(IShape shape, Vector2 position, float angle, ContactFilter2D contactFilter2D, Component<ICollider2D>[] result = null);
    }
}
