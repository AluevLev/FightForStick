using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Time;

public sealed class EntityMotorHandler : BaseEntity, IMotorHandler, IFixedFrame
{
    private readonly ITime _time;
    private readonly IEntityMotor _entityMotor;
    private readonly IMovementCalculator _movementCalculator;
    private readonly IOverlapper _groundChecker;
    private readonly Trigger _jumpTrigger = new();
    private readonly float _legsChangeRotationPeriod;

    private float _startTime;
    private bool _hipsOpen;
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IEntityMotor entityMotor, IOverlapper groundChecker, IMovementCalculator movementCalculator, float legsChangeRotationPeriod)
    {
        _entityMotor = entityMotor;
        _groundChecker = groundChecker;
        _movementCalculator = movementCalculator;
        _legsChangeRotationPeriod = legsChangeRotationPeriod;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void OnFixedFrame()
    {
        _entityMotor.ForcePush(_movementCalculator.CalculateMovementVector(MovementDirection));

        if (MovementDirection == 0)
            ResetLegs();
        else
            SetLegs();

        _groundChecker.Overlap();

        if (_jumpTrigger.Active && _groundChecker.Succes)
            _entityMotor.ImpulsePush(_movementCalculator.CalculateJumpVector(MovementDirection));
    }
    private void ResetLegs()
    {
        _hipsOpen = false;
        _entityMotor.ResetLegs();
    }
    private void SetLegs()
    {
        float currentTime = _time.CurrentTime;

        if (currentTime - _startTime < _legsChangeRotationPeriod)
            return;

        _startTime = currentTime;
        _hipsOpen = !_hipsOpen;

        if (_hipsOpen)
            _entityMotor.OpenHips();
        else
            _entityMotor.CloseHips();
    }
}
