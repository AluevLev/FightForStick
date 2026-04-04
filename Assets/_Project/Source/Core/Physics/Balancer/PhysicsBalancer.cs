using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Follow;
using IceFebruary.Space.PointProvider;

public class PhysicsBalancer : ITargetPossessing, IPhysicsBalancer
{
    private readonly IEntity<IRigidbody2D> _physicsBody;
    private readonly IPhysicsBalancerCalculator _physicsBalancerCalculator;

    private readonly IPointProvider _defaultPointProvider;
    private IPointProvider _targetPoint;

    public float AdditionalAngle { get; set; }
    public PhysicsBalancer(IEntity<IRigidbody2D> physics, IPhysicsBalancerCalculator physicsBalancerCalculator, IPointProvider defaultPointProvider = null)
    {
        _physicsBody = physics;
        _defaultPointProvider = defaultPointProvider;
        _physicsBalancerCalculator = physicsBalancerCalculator;

        SetTarget(_defaultPointProvider);
    }
    public void SetTarget(IPointProvider targetProvider) => _targetPoint = targetProvider;
    public void ResetTarget() => _targetPoint = _defaultPointProvider;
    public void Relax() => _targetPoint = null;
    public void LookAtTarget()
    {
        if (!_physicsBody.TryGetInnerSafe(out IRigidbody2D innerPhysics) || !_targetPoint.TryGetPointSafe(out Vector2 point))
            return;

        float torque = _physicsBalancerCalculator.CalculateAngle(innerPhysics.Rotation, point.Angle + AdditionalAngle);

        innerPhysics.MoveRotation(torque);
    }
}