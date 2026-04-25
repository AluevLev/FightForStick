using IceFebruary;
using IceFebruary.Time;
using IceFebruary.Animation;

public sealed class EntityBoneAnimation : BaseEntity, IFixedFrame
{
    private readonly AnimatorVariable<float> _movementFloat;
    private readonly IMotorHandler _movable;
    public EntityBoneAnimation(IMotorHandler movable, AnimatorVariable<float> movementFloat) : base()
    {
        _movable = movable;
        _movementFloat = movementFloat;
    }
    public void OnFixedFrame()
    {
        _movementFloat.Value = _movable.MovementDirection;
    }
}
