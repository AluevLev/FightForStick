namespace IceFebruary.Physics
{
    using IceFebruary;

    public interface IOverlapper : IBaseEntity
    {
        Component<ICollider2D>[] Colliders2D { get; }
        int Colliders2DActualLength { get; }
        bool Success { get; }
        void Overlap();
    }
}
