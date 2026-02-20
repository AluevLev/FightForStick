using UnityEngine;

public class PhysicsBalancerCalculator : IPhysicsBalancerCalculator
{
    private readonly float _force;
    public PhysicsBalancerCalculator(float force)
    {
        _force = Mathf.Clamp01(force);
    }
    public float CalculateAngle(float currentRotation, float targetAngle)
    {
        return Mathf.LerpAngle(currentRotation, targetAngle, _force);
    }
}
