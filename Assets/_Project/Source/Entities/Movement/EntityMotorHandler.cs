using IceFebruary;
using IceFebruary.Physics;

public class EntityMotorHandler : ITogglable, IMotorHandler
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
    public void Jump()
    {
        if (!Enabled)
            return;

        _jumpTrigger.Charge();
    }
    public void Move()
    {
        if (!Enabled)
            return;

        _entityPhysics.AddForce(_movementCalculator.CalculateMovementVector(MovementDirection), ForceMode2D.Force);
    }
    public void ProcessMotor()
    {
        if (!Enabled)
            return;

        _jumpTrigger.Process();

        if (_jumpTrigger.Active && _areaCaster.Overlap(out _))
            _entityPhysics.AddForce(_movementCalculator.CalculateJumpVector(MovementDirection), ForceMode2D.Force);
    }
}
