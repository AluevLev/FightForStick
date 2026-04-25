namespace IceFebruary.Physics
{
    public interface IOverlapper : IBaseEntity
    {
        bool Overlap(Component<ICollider2D>[] colliders2D = null);
    }
}
