using UnityEngine;

public class AnimatorFloat : AnimatorField
{
    public AnimatorFloat(Animator animator, string name) : base(animator, name) { }
    public AnimatorFloat(Animator animator, int hash) : base(animator, hash) { }
    public AnimatorFloat(Animator animator, AnimatorFieldName animatorField) : base(animator, animatorField) { }
    public float Value
    {
        get => Animator.GetFloat(Hash);
        set => Animator.SetFloat(Hash, value);
    }
}
