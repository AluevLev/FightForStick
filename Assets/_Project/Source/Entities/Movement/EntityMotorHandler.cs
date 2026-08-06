using IceFebruary;
using IceFebruary.Time;
using IceFebruary.Physics;

public sealed class EntityMotorHandler : BaseEntity, IMotorHandler, IFixedFrame
{
    private readonly IEntityMotor _entityMotor;
    private readonly IMovementCalculator _movementCalculator;
    private readonly IOverlapper _groundChecker;
    private readonly Timer _hipsTimer;
    private readonly Trigger _jumpTrigger;

    private bool _hipsOpen;
    public float MovementDirection { get; set; }
    public bool IsSneaking { get; set; }
    public EntityMotorHandler(IEntityMotor entityMotor, IOverlapper groundChecker, IMovementCalculator movementCalculator, Timer hipsTimer, Trigger jumpTrigger)
    {
        _entityMotor = entityMotor;
        _groundChecker = groundChecker;
        _movementCalculator = movementCalculator;
        _hipsTimer = hipsTimer;
        _jumpTrigger = jumpTrigger;
    }
    public void Jump() => _jumpTrigger.Charge();
    public void OnFixedFrame()
    {
        _entityMotor.ForcePush(_movementCalculator.GetMovementVector(MovementDirection));

        SetLegs();

        _groundChecker.Overlap();

        if (_groundChecker.Succes && _jumpTrigger.Active != IsSneaking)
        {
            if (IsSneaking)
                _entityMotor.ForcePush(_movementCalculator.GetSneakVector());
            else
                _entityMotor.ImpulsePush(_movementCalculator.GetJumpVector(MovementDirection));
        }
    }
    private void SetLegs()
    {
        if (MovementDirection == 0f)
        {
            _hipsOpen = false;
            _hipsTimer.ResetCooldown();
            _entityMotor.ResetLegs();

            return;
        }

        if (MovementDirection > 0f)
            _entityMotor.SetMinShins();
        if (MovementDirection < 0f)
            _entityMotor.SetMaxShins();

        if (_hipsTimer.InCoolDown)
            return;

        _hipsTimer.SetCooldown();
        _hipsOpen = !_hipsOpen;

        if (_hipsOpen)
            _entityMotor.OpenHips();
        else
            _entityMotor.CloseHips();
    }
}
