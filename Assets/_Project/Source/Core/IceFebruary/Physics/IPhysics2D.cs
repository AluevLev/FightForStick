namespace IceFebruary.Physics
{
    using IceFebruary.Components;
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public interface IPhysics2D
    {
        int Overlap<T>(T shape, Vector2 position, float angle, UnityEngine.ContactFilter2D contactFilter2D, out ICollider2D results) where T : struct, IShape;
    }
}
