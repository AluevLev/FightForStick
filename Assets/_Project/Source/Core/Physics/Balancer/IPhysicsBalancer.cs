using IceFebruary;
using IceFebruary.Space.AngleProvider;

public interface IPhysicsBalancer : IBaseEntity
{
    void SetTarget(IAngleProvider targetProvider);
    void ResetTarget();
    void Relax();
}
