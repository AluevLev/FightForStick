using UnityEngine;

public class AnimatorInt : AnimatorField
{
    public AnimatorInt(Animator animator, string name) : base(animator, name) { }
    public AnimatorInt(Animator animator, int hash) : base(animator, hash) { }
    public AnimatorInt(Animator animator, AnimatorFieldName animatorField) : base(animator, animatorField) { }
    public int Value
    {
        get => Animator.GetInteger(Hash);
        set => Animator.SetInteger(Hash, value);
    }
}
