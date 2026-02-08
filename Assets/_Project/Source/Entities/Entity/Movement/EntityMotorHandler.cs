using VContainer.Unity;

public class EntityMotorHandler : ITogglable, IMotorHandler, IFixedTickable
{
    private readonly IMotor _entityMotor;
    private bool _jumpTrigger;
    public bool Enabled { get; set; }
    public float MovementDirection { get; set; }
    public EntityMotorHandler(IMotor entityMotor)
    {
        _entityMotor = entityMotor;
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

        if (_jumpTrigger)
        {
            _entityMotor.Jump(MovementDirection);
            _jumpTrigger = false;
        }
    }
}
