using UnityEngine;
using VContainer.Unity;

public class PhysicsBalancer : ITogglable, ITargetPossessing, IFixedTickable
{
    private readonly IPhysicsBody _physicsBody;
    private readonly IPhysicsBalancerCalculator _physicsBalancerCalculator;

    private readonly IPointProvider _defaultPointProvider;
    private IPointProvider _targetPoint;

    public float AdditionalAngle { get; set; }
    public bool Enabled { get; set; }
    public PhysicsBalancer(IPhysicsBody physics, IPhysicsBalancerCalculator physicsBalancerCalculator, IPointProvider defaultPointProvider = null)
    {
        _physicsBody = physics;
        _defaultPointProvider = defaultPointProvider;
        _physicsBalancerCalculator = physicsBalancerCalculator;

        SetTarget(_defaultPointProvider);
    }
    public void SetTarget(IPointProvider targetProvider) => _targetPoint = targetProvider;
    public void ResetTarget() => _targetPoint = _defaultPointProvider;
    public void Relax() => _targetPoint = null;
    public void FixedTick()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (!Enabled)
            return;
        if (!_targetPoint.TryGetPointSafe(out Vector2 point))
            return;

        float torque = _physicsBalancerCalculator.CalculateTorque(_physicsBody.AngularVelocity, _physicsBody.Rotation, point.GetAngle() + AdditionalAngle);

        _physicsBody.AddTorque(torque, ForceMode2D.Force);
    }
}
