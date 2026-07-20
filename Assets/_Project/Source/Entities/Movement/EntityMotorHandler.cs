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
    public EntityMotorHandler(ITime time, IEntityMotor entityMotor, IOverlapper groundChecker, IMovementCalculator movementCalculator, float legsChangeRotationPeriod)
    {
        _time = time;
        _entityMotor = entityMotor;
        _groundChecker = groundChecker;
        _movementCalculator = movementCalculator;
        _legsChangeRotationPeriod = legsChangeRotationPeriod;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void OnFixedFrame()
    {
        _entityMotor.ForcePush(_movementCalculator.CalculateMovementVector(MovementDirection));

        SetLegs();

        _groundChecker.Overlap();

        if (_jumpTrigger.Active && _groundChecker.Succes)
            _entityMotor.ImpulsePush(_movementCalculator.CalculateJumpVector(MovementDirection));
    }
    private void SetLegs()
    {
        float currentTime = _time.CurrentTime;

        if (MovementDirection == 0f)
        {
            _hipsOpen = false;
            _startTime = currentTime + _legsChangeRotationPeriod;
            _entityMotor.ResetLegs();

            return;
        }

        if (MovementDirection > 0f)
            _entityMotor.SetMinShins();
        if (MovementDirection < 0f)
            _entityMotor.SetMaxShins();

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
