using IceFebruary;
using IceFebruary.Time;

public sealed class EntityMovementController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _playerMotorHandler;
    public EntityMovementController(IInputProvider inputProvider, IMotorHandler entityMotorHandler)
    {
        _inputProvider = inputProvider;
        _playerMotorHandler = entityMotorHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (!_inputProvider.Active())
            return;

        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _playerMotorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _playerMotorHandler.Jump();
    }
}
