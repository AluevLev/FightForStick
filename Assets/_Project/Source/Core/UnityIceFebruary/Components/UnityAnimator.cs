namespace UnityIceFebruary.Components
{
    using IceFebruary.Animation;
    using UnityIceFebruary.AutoGeneration;

    using Animator = UnityEngine.Animator;

    [UnityAnalog(typeof(Animator))]
    public class UnityAnimator : IAnimator, IUnityAnalog
    {
        public Animator Animator { get; private init; }
        public UnityEngine.Component Original { get; private init; }
        public UnityAnimator(Animator animator)
        {
            Animator = animator;
            Original = animator;
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
