public class PlayerMovementController : IController
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _playerMotorHandler;
    public PlayerMovementController(IMotorHandler entityMotorHandler, IInputProvider inputProvider)
    {
        _playerMotorHandler = entityMotorHandler;
        _inputProvider = inputProvider;
    }
    public void ProcessInput()
    {
        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _playerMotorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _playerMotorHandler.Jump();
    }
}
