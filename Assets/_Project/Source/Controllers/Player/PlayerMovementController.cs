using IceFebruary;
using IceFebruary.Time;

public sealed class PlayerMovementController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _playerMotorHandler;
    public PlayerMovementController(IInputProvider inputProvider, IMotorHandler entityMotorHandler) : base()
    {
        _inputProvider = inputProvider;
        _playerMotorHandler = entityMotorHandler;
    }
    public void OnFrame(float frameLength)
    {
        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _playerMotorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _playerMotorHandler.Jump();
    }
}
