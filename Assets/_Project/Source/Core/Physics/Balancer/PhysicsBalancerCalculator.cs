using IceFebruary;
using IceFebruary.Space;

public sealed class PhysicsBalancerCalculator : IPhysicsBalancerCalculator
{
    private readonly float _force;
    public PhysicsBalancerCalculator(float force)
    {
        _force = Math.Clamp01(force);
    }
    public Rotor2 CalculateAngle(Rotor2 currentRotation, Rotor2 targetAngle)
    {
        return Rotor2.Lerp(currentRotation, targetAngle, _force);
    }
}
