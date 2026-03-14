namespace IceFebruary.Physics
{
    public interface ILazyOverlap
    {
        bool Overlap(out ICollider2D[] colliders2D);
    }
}
