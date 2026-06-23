using IceFebruary;
using IceFebruary.Space;

public interface IPhysicsBalancer : IBaseEntity
{
    void SetTarget(IProvider<Rotor2> targetProvider);
    void ResetTarget();
    void Relax();
}
