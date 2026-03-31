namespace IceFebruary.Physics
{
    public interface IOverlapper
    {
        bool Overlap(out IEntireComponent<ICollider2D>[] colliders2D);
    }
}
