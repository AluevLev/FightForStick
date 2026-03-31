using IceFebruary;
using IceFebruary.Physics;

public class EntityMotorHandler : IMotorHandler
{
    private readonly IRigidbody2D _entityPhysics;
    private readonly IOverlapper _areaCaster;
    private readonly IMovementCalculator _movementCalculator;
    private readonly Trigger _jumpTrigger = new();
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IRigidbody2D entityPhysics, IOverlapper groundCheck, IMovementCalculator movementCalculator)
    {
        _entityPhysics = entityPhysics;
        _areaCaster = groundCheck;
        _movementCalculator = movementCalculator;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void Move() => _entityPhysics.AddForce(_movementCalculator.CalculateMovementVector(MovementDirection), ForceMode2D.Force);
    public void ProcessMotor()
    {
        _jumpTrigger.Process();

        if (_jumpTrigger.Active && _areaCaster.Overlap(out _))
            _entityPhysics.AddForce(_movementCalculator.CalculateJumpVector(MovementDirection), ForceMode2D.Force);
    }
}
