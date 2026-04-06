namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D
    {
        int Overlap(IShape shape, Vector2 position, float angle = 0f, ContactFilter2D contactFilter2D = default, IEntireComponent<ICollider2D>[] result = null);
    }
}
