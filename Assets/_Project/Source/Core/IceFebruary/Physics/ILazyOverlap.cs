namespace IceFebruary.Physics
{
    public interface ILazyOverlap
    {
        bool Overlap(out IEntireComponent<ICollider2D>[] colliders2D);
    }
}
