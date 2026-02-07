using VContainer.Unity;

public class PlayerController : ITogglable, IController, ITickable
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _entityMotorHandler;
    public bool Enabled { get; set; }
    public PlayerController(IMotorHandler entityMotorHandler, IInputProvider inputProvider)
    {
        _entityMotorHandler = entityMotorHandler;
        _inputProvider = inputProvider;
    }
    public void Tick()
    {
        ProcessInput();
    }
    private void ProcessInput()
    {
        if (!Enabled)
            return;

        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _entityMotorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _entityMotorHandler.Jump();
    }
}
