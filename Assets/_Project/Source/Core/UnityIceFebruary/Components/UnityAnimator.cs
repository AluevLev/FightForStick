namespace UnityIceFebruary.Components
{
    using IceFebruary.Animation;

    public class UnityAnimator : IAnimator
    {
        public UnityEngine.Animator Animator { get; init; }
        public UnityAnimator(UnityEngine.Animator animator)
        {
            Animator = animator;
        }
        public bool Enabled
        {
            get => Animator.enabled;
            set => Animator.enabled = value;
        }
        public T GetVariable<T>(int hash) where T : struct => UnityStaticAnimator<T>.Get(Animator, hash);
        public void SetVariable<T>(int hash, T value) where T : struct => UnityStaticAnimator<T>.Set(Animator, hash, value);
        public void SetTrigger(int hash) => Animator.SetTrigger(hash);
    }
}
