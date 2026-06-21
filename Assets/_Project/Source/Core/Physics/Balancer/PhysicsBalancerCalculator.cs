using IceFebruary;
using IceFebruary.Space;

public sealed class PhysicsBalancerCalculator : IPhysicsBalancerCalculator
{
    private readonly float _force;
    public PhysicsBalancerCalculator(float force)
    {
        _force = force.Clamp01();
    }
    public Rotor2 CalculateAngle(Rotor2 currentRotation, Rotor2 targetAngle)
    {
        return Rotor2.Lerp(currentRotation, targetAngle, _force);
    }
}
