using UnityEngine;

public class AnimatorBool : AnimatorField
{
    public AnimatorBool(Animator animator, string name) : base(animator, name) { }
    public AnimatorBool(Animator animator, int hash) : base(animator, hash) { }
    public AnimatorBool(Animator animator, AnimatorFieldName animatorField) : base(animator, animatorField) { }

    public bool Value
    {
        get => Animator.GetBool(Hash);
        set => Animator.SetBool(Hash, value);
    }
}
