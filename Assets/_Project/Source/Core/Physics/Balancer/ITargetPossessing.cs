namespace February.Space.Follow
{
    using February.Space.PointProvider;
    public interface ITargetPossessing
    {
        void SetTarget(IPointProvider targetProvider);
        void ResetTarget();
    }
}
