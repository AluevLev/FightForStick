using UnityEngine;

public abstract class AnimatorField
{
	private readonly Animator _animator;
	private readonly int _hash;
    protected Animator Animator => _animator;
    protected int Hash => _hash;
	public AnimatorField(Animator animator, string name)
    {
        _animator = animator;
        _hash = Animator.StringToHash(name);
    }
    public AnimatorField(Animator animator, int hash)
    {
        _animator = animator;
        _hash = hash;
    }
    public AnimatorField(Animator animator, AnimatorFieldName animatorField)
    {
        _animator = animator;
        _hash = animatorField.Hash;
    }
}
