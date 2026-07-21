namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D : IBaseEntity
    {
        int Overlap(IShape shape, Vector2 position, Rotor2 rotor, Component<ICollider2D>[] result = null);
        int Overlap(IShape shape, Vector2 position, float angle = 0f, Component<ICollider2D>[] result = null);
        int Overlap(IShape shape, Vector2 position, ContactFilter2D contactFilter2D, Rotor2 rotor, Component<ICollider2D>[] result = null);
        int Overlap(IShape shape, Vector2 position, ContactFilter2D contactFilter2D, float angle = 0f, Component<ICollider2D>[] result = null);
    }
}
