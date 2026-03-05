namespace IceFebruary.Physics
{
    using IceFebruary.Components;
    using IceFebruary.Shapes;

    public interface IPhysics
    {
        ICollider2D Overlap<T>(T shape) where T : struct, IShape;
    }
}
