using VContainer.Unity;

public class EntityAnimation : ITogglable, IAnimation, IFixedTickable
{
    private readonly AnimatorFloat _movementFloat;
    private readonly IMotorHandler _movable;
    public bool Enabled { get; set; } = true;
    public EntityAnimation(IMotorHandler movable, AnimatorFloat movementFloat)
    {
        _movable = movable;
        _movementFloat = movementFloat;
    }
    public void FixedTick()
    {
        Animate();
    }
    private void Animate()
    {
        if (!Enabled)
            return;

        _movementFloat.Value = _movable.MovementDirection;
    }
}
