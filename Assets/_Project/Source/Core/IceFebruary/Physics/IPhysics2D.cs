namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D
    {
        int Overlap<T>(out ICollider2D[] results, T shape, Vector2 position, float angle = 0f, ContactFilter2D contactFilter2D = default) where T : struct, IShape;
    }
}
