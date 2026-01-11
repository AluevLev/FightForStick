using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HumanAnimation : MonoBehaviour
{
    private static readonly int MovementFloat = Animator.StringToHash("Movement");
    private IMovable _movable;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movable = GetComponent<IMovable>();
    }
    private void Update()
    {
        Animate();
    }
    private void Animate()
    {
        _animator.SetFloat(MovementFloat, _movable.CurrentDirection);
    }
}
