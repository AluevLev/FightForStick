namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D : IBaseEntity
    {
        int Overlap(IShape shape, Vector2 position, float angle = 0f, ContactFilter2D contactFilter2D = default, Component<ICollider2D>[] result = null);
    }
}
