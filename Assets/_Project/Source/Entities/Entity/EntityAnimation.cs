using UnityEngine;
using VContainer.Unity;

public class EntityAnimation : ITogglable, IAnimation, IFixedTickable
{
    private static readonly int _movementFloat = Animator.StringToHash("Movement");
    private readonly IMotorHandler _movable;
    private readonly Animator _animator;
    public bool Enabled { get; set; }
    public EntityAnimation(IMotorHandler movable, Animator animator)
    {
        _movable = movable;
        _animator = animator;
    }
    public void FixedTick()
    {
        Animate();
    }
    private void Animate()
    {
        if (!Enabled)
            return;

        _animator.SetFloat(_movementFloat, _movable.MovementDirection);
    }
}
