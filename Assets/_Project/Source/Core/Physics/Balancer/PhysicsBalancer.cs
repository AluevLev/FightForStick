using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Follow;
using IceFebruary.Space.PointProvider;
using IceFebruary.Space.AngleProvider;

public sealed class PhysicsBalancer : ITargetPossessing<IAngleProvider>, IPhysicsBalancer
{
    private readonly IRigidbody2D _physicsBody;
    private readonly IPhysicsBalancerCalculator _physicsBalancerCalculator;

    private readonly IAngleProvider _defaultAngleProvider;
    private IAngleProvider _targetAngle;

    public Rotor2 AdditionalAngle { get; set; }
    public PhysicsBalancer(IRigidbody2D physics, IPhysicsBalancerCalculator physicsBalancerCalculator, IAngleProvider defaultAngleProvider = null)
    {
        _physicsBody = physics;
        _defaultAngleProvider = defaultAngleProvider;
        _physicsBalancerCalculator = physicsBalancerCalculator;

        SetTarget(_defaultAngleProvider);
    }

    public void SetTarget(IAngleProvider targetProvider) => _targetAngle = targetProvider;
    public void ResetTarget() => _targetAngle = _defaultAngleProvider;
    public void Relax() => _targetAngle = null;
    public void LookAtTarget()
    {
        if (!_physicsBody.Exists() || !_targetAngle.TryGetAngleSafe(out Rotor2 angle))
            return;

        Rotor2 rotation = _physicsBalancerCalculator.CalculateAngle(_physicsBody.Rotation, angle * AdditionalAngle);

        _physicsBody.MoveRotation(rotation);
    }
}