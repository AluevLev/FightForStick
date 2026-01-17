using UnityEngine;
using VContainer;

[RequireComponent(typeof(Animator))]
public class HumanAnimation : MonoBehaviour
{
    private static readonly int MovementFloat = Animator.StringToHash("Movement");
    private IMovable _movable;
    private Animator _animator;
    [Inject]
    public void Construct(IMovable movable)
    {
        _movable = movable;
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
