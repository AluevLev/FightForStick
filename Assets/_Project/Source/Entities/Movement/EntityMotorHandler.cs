using VContainer.Unity;
using IceFebruary;
using IceFebruary.Physics;

public class EntityMotorHandler : ITogglable, IMotorHandler, IFixedTickable
{
    private readonly IRigidbody2D _entityPhysics;
    private readonly ILazyOverlap _areaCaster;
    private readonly IMovementCalculator _movementCalculator;
    private readonly Trigger _jumpTrigger = new();
    public bool Enabled { get; set; } = true;
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IRigidbody2D entityPhysics, ILazyOverlap groundCheck, IMovementCalculator movementCalculator)
    {
        _entityPhysics = entityPhysics;
        _areaCaster = groundCheck;
        _movementCalculator = movementCalculator;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void FixedTick()
    {
        _jumpTrigger.ProcessLife();

        MoveMotor();
    }
    public void MoveMotor()
    {
        if (!Enabled)
            return;

        _entityPhysics.AddForce(_movementCalculator.CalculateMovementVector(MovementDirection), ForceMode2D.Force);

        if (_jumpTrigger.Active && _areaCaster.Overlap(out _))
            _entityPhysics.AddForce(_movementCalculator.CalculateJumpVector(MovementDirection), ForceMode2D.Force);
    }
}
