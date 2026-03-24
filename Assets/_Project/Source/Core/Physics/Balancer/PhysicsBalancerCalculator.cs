using IceFebruary;

public class PhysicsBalancerCalculator : IPhysicsBalancerCalculator
{
    private readonly float _force;
    public PhysicsBalancerCalculator(float force)
    {
        _force = Math.Clamp01(force);
    }
    public float CalculateAngle(float currentRotation, float targetAngle)
    {
        return Math.LerpAngle(currentRotation, targetAngle, _force);
    }
}
