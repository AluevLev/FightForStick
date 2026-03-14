using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Follow;
using IceFebruary.Space.PointProvider;

public class PhysicsBalancer : ITogglable, ITargetPossessing, IPhysicsBalancer
{
    private readonly IRigidbody2D _physicsBody;
    private readonly IPhysicsBalancerCalculator _physicsBalancerCalculator;

    private readonly IPointProvider _defaultPointProvider;
    private IPointProvider _targetPoint;

    public float AdditionalAngle { get; set; }
    public bool Enabled { get; set; } = true;
    public PhysicsBalancer(IRigidbody2D physics, IPhysicsBalancerCalculator physicsBalancerCalculator, IPointProvider defaultPointProvider = null)
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
        if (!Enabled)
            return;
        if (!_targetPoint.TryGetPointSafe(out Vector2 point))
            return;

        float torque = _physicsBalancerCalculator.CalculateAngle(_physicsBody.Rotation, point.Angle + AdditionalAngle);

        _physicsBody.MoveRotation(torque);
    }
}