namespace IceFebruary.Physics
{
    public interface IOverlapper
    {
        bool Overlap(IComponent<ICollider2D>[] colliders2D = null);
    }
}
