using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Time;

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
    public void Jump()
    {
        if (Enabled)
            _jumpTrigger.Charge();
    }
    public void OnFixedFrame()
    {
        if (!Enabled)
            return;

        _entityMotor.ForcePush(_movementCalculator.GetMovementVector(MovementDirection));

        SetLegs();

        if (!_groundChecker.Exists())
            return;

        _groundChecker.Overlap();

        if (_groundChecker.Colliders2DActualLength > 0 && _jumpTrigger.Active != IsSneaking)
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
