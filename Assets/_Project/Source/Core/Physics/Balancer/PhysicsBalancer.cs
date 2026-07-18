using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Follow;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Time;

public sealed class PhysicsBalancer : BaseEntity, ITargetPossessing<IRotor2Provider>, IPhysicsBalancer, IFixedFrame
{
    private readonly IRigidbody2D _physicsBody;
    private readonly IPhysicsBalancerCalculator _physicsBalancerCalculator;

    private readonly IRotor2Provider _defaultAngleProvider;
    private IRotor2Provider _targetAngle;

    public PhysicsBalancer(IRigidbody2D physics, IPhysicsBalancerCalculator physicsBalancerCalculator, IRotor2Provider defaultAngleProvider = null)
    {
        _physicsBody = physics;
        _defaultAngleProvider = defaultAngleProvider;
        _physicsBalancerCalculator = physicsBalancerCalculator;

        SetTarget(_defaultAngleProvider);
    }
    public void SetTarget(IRotor2Provider targetProvider) => _targetAngle = targetProvider;
    public void ResetTarget() => _targetAngle = _defaultAngleProvider;
    public void OnFixedFrame()
    {
        if (!_physicsBody.Exists() || !_targetAngle.TryGetSafety(out Rotor2 angle))
            return;

        Rotor2 rotation = _physicsBalancerCalculator.CalculateAngle(_physicsBody.Rotation, angle);

        _physicsBody.MoveRotation(rotation);
    }
}