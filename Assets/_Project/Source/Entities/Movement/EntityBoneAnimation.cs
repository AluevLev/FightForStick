using IceFebruary.Time;
using IceFebruary.Animation;

public sealed class EntityBoneAnimation : IFixedFrame
{
    private readonly AnimatorVariable<float> _movementFloat;
    private readonly IMotorHandler _movable;
    public EntityBoneAnimation(IMotorHandler movable, AnimatorVariable<float> movementFloat)
    {
        _movable = movable;
        _movementFloat = movementFloat;
    }
    public void OnFixedFrame()
    {
        _movementFloat.Value = _movable.MovementDirection;
    }
}
