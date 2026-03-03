namespace February.Physics
{
    using February.Space.PointProvider;
    public interface IPhysicsBalancer
    {
        void SetTarget(IPointProvider targetProvider);
        void ResetTarget();
        void Relax();
        void LookAtTarget();
    }
}
