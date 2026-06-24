using IceFebruary;
using IceFebruary.Space.Rotor2Provider;

public interface IPhysicsBalancer : IBaseEntity
{
    void SetTarget(IRotor2Provider targetProvider);
    void ResetTarget();
    void Relax();
}
