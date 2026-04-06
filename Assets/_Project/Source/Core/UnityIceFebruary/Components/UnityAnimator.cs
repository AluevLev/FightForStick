namespace UnityIceFebruary.Components
{
    using IceFebruary.Animation;
    using UnityIceFebruary.AutoGeneration;

    using Animator = UnityEngine.Animator;

    [UnityAnalog(typeof(Animator))]
    public sealed class UnityAnimator : IAnimator, IUnityAnalog
    {
        public Animator Animator { get; private init; }
        public UnityEngine.Object Original { get; private init; }
        public UnityAnimator(Animator animator)
        {
            Animator = animator;
            Original = animator;
        }
        public T GetVariable<T>(int hash) where T : struct => UnityStaticAnimator<T>.Get(Animator, hash);
        public void SetVariable<T>(int hash, T value) where T : struct => UnityStaticAnimator<T>.Set(Animator, hash, value);
        public void SetTrigger(int hash) => Animator.SetTrigger(hash);
    }
}
