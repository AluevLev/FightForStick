using UnityEngine;

public class PhysicsBalancerCalculator : IPhysicsBalancerCalculator
{
    private readonly float _stiffness;
    private readonly float _damping;
    public PhysicsBalancerCalculator(float stiffness, float dampingPercent, float maxSåiffness = 5000f, float maxDamping = 200f)
    {
        _stiffness = Mathf.Clamp01(stiffness) * maxSåiffness;
        _damping = Mathf.Clamp01(dampingPercent) * maxDamping;
    }
    public float CalculateTorque(float currentAngularVelocity, float currentRotation, float targetAngle)
    {
        float deltaAngle = Mathf.DeltaAngle(currentRotation, targetAngle);
        float torque = deltaAngle * _stiffness - currentAngularVelocity * _damping;
        return torque;
    }
}
