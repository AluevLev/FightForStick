using IceFebruary.Time;
using IceFebruary.Animation;

public class EntityAnimation : IAnimation, IFixedFrame
{
    private readonly AnimatorVariable<float> _movementFloat;
    private readonly IMotorHandler _movable;
    public EntityAnimation(IMotorHandler movable, AnimatorVariable<float> movementFloat)
    {
        _movable = movable;
        _movementFloat = movementFloat;
    }
    public void OnFixedFrame()
    {
        Animate();
    }
    private void Animate()
    {
        _movementFloat.Value = _movable.MovementDirection;
    }
}
