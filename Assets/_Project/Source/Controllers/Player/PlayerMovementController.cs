using IceFebruary.Time;

public class PlayerMovementController : IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _playerMotorHandler;
    public PlayerMovementController(IInputProvider inputProvider, IMotorHandler entityMotorHandler)
    {
        _inputProvider = inputProvider;
        _playerMotorHandler = entityMotorHandler;
    }
    public void OnFrame()
    {
        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _playerMotorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _playerMotorHandler.Jump();
    }
}
