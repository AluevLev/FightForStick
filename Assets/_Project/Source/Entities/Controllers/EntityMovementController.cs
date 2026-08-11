using IceFebruary;
using IceFebruary.Time;

public sealed class EntityMovementController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IMotorHandler _motorHandler;
    public EntityMovementController(IInputProvider inputProvider, IMotorHandler motorHandler)
    {
        _inputProvider = inputProvider;
        _motorHandler = motorHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (!Enabled || !_inputProvider.Exists() || !_motorHandler.Exists())
            return;

        float horizontal = _inputProvider.HorizontalMovement;
        float vertical = _inputProvider.VerticalMovement;

        _motorHandler.MovementDirection = horizontal;

        if (vertical > 0f)
            _motorHandler.Jump();

        _motorHandler.IsSneaking = vertical < 0f;
    }
}
