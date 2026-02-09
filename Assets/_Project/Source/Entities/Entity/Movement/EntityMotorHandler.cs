using VContainer.Unity;

public class EntityMotorHandler : ITogglable, IMotorHandler, IFixedTickable
{
    private readonly IMotor _entityMotor;
    private readonly IAreaCaster _areaCaster;
    private bool _jumpTrigger;
    public bool Enabled { get; set; }
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IMotor entityMotor, IAreaCaster groundCheck)
    {
        _entityMotor = entityMotor;
        _areaCaster = groundCheck;
    }
    public void Jump() => _jumpTrigger = true;
    public void FixedTick()
    {
        MoveMotor();
    }
    public void MoveMotor()
    {
        if (!Enabled)
            return;

        _entityMotor.Move(MovementDirection);

        if (_jumpTrigger && _areaCaster.Cast())
        {
            _entityMotor.Jump(MovementDirection);
            _jumpTrigger = false;
        }
    }
}
