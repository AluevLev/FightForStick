using VContainer.Unity;

public class PlayerMovementController : ITogglable, IController, ITickable
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _playerMotorHandler;
    public bool Enabled { get; set; }
    public PlayerMovementController(IMotorHandler entityMotorHandler, IInputProvider inputProvider)
    {
        _playerMotorHandler = entityMotorHandler;
        _inputProvider = inputProvider;
    }
    public void Tick()
    {
        ProcessInput();
    }
    public void ProcessInput()
    {
        if (!Enabled)
            return;

        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _playerMotorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _playerMotorHandler.Jump();
    }
}
