namespace IceFebruary.Physics
{
    public interface IOverlapper
    {
        bool Overlap(IEntireComponent<ICollider2D>[] colliders2D = null);
    }
}
