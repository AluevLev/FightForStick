using IceFebruary.Space.AngleProvider;

public interface IPhysicsBalancer
{
    void SetTarget(IAngleProvider targetProvider);
    void ResetTarget();
    void Relax();
    void LookAtTarget();
}
