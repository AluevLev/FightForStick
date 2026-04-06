using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Time;

public sealed class EntityMotorHandler : IMotorHandler, IFixedFrame
{
    private readonly IEntity<IRigidbody2D> _entityPhysics;
    private readonly IOverlapper _areaCaster;
    private readonly IMovementCalculator _movementCalculator;
    private readonly Trigger _jumpTrigger = new();
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IEntity<IRigidbody2D> entityPhysics, IOverlapper groundCheck, IMovementCalculator movementCalculator)
    {
        _entityPhysics = entityPhysics;
        _areaCaster = groundCheck;
        _movementCalculator = movementCalculator;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void OnFixedFrame()
    {
        _jumpTrigger.OnFixedFrame();

        if (_entityPhysics.TryGetInner(out IRigidbody2D inner))
        {
            inner.AddForce(_movementCalculator.CalculateMovementVector(MovementDirection), ForceMode2D.Force);

            if (_jumpTrigger.Active && _areaCaster.Overlap())
                inner.AddForce(_movementCalculator.CalculateJumpVector(MovementDirection), ForceMode2D.Force);
        }
    }
}
