using UnityEngine;

public class AnimatorTrigger : AnimatorField
{
    public AnimatorTrigger(Animator animator, string name) : base(animator, name) { }
    public AnimatorTrigger(Animator animator, int hash) : base(animator, hash) { }
    public AnimatorTrigger(Animator animator, AnimatorFieldName animatorField) : base(animator, animatorField) { }
    public void Active() => Animator.SetTrigger(Hash);
    public void Reset() => Animator.ResetTrigger(Hash);
}
