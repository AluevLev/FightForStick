using UnityEngine;

public interface IPhysicsBalancerCalculator
{
    float CalculateTorque(float currentAngularVelocity, float currentRotation, float targetAngle);
}
