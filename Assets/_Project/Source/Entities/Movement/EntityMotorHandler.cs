using IceFebruary;
using IceFebruary.Animation;
using IceFebruary.Physics;
using IceFebruary.Time;

public sealed class EntityMotorHandler : BaseEntity, IMotorHandler, IFixedFrame
{
    private readonly IRigidbody2D _pushBody;
    private readonly IMovementCalculator _movementCalculator;
    private readonly IOverlapper _areaCaster;
    private readonly AnimatorVariable<float> _movementFloat;
    private readonly Trigger _jumpTrigger = new();
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IRigidbody2D pushBody, IOverlapper groundCheck, IMovementCalculator movementCalculator, AnimatorVariable<float> movementFloat)
    {
        _pushBody = pushBody;
        _areaCaster = groundCheck;
        _movementCalculator = movementCalculator;
        _movementFloat = movementFloat;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void OnFixedFrame()
    {
        //_jumpTrigger.OnFixedFrame();

        _movementFloat.Value = MovementDirection;

        if (_pushBody.Exists())
        {
            _pushBody.AddForce(_movementCalculator.CalculateMovementVector(MovementDirection), ForceMode2D.Force);

            if (_jumpTrigger.Active && _areaCaster.Overlap())
                _pushBody.AddForce(_movementCalculator.CalculateJumpVector(MovementDirection), ForceMode2D.Force);
        }
    }
}
