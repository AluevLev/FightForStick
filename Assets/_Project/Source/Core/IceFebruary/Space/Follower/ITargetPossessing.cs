namespace IceFebruary.Space.Follow
{
    using IceFebruary.Space.PointProvider;

    public interface ITargetPossessing
    {
        void SetTarget(IPointProvider targetProvider);
        void ResetTarget();
    }
}
