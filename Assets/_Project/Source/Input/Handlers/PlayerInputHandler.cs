using VContainer.Unity;

public class PlayerInputHandler : ITickable
{
    private readonly IInputProvider _inputProvider;
    private readonly IMovable _movable;
    public PlayerInputHandler(IMovable movable, IInputProvider inputProvider)
    {
        _movable = movable;
        _inputProvider = inputProvider;
    }
    public void Tick()
    {
        _movable.SetMovementDirection(_inputProvider.HorizontalMovement);

        if (_inputProvider.VerticalMovement > 0f)
            _movable.Jump();
    }
}
