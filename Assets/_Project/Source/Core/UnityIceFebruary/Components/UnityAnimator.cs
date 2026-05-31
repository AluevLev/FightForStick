namespace UnityIceFebruary.Components
{
    using UnityIceFebruary;
    using IceFebruary.Animation;
    using IceFebruary.Proxy;

    using Animator = UnityEngine.Animator;

    public sealed class UnityAnimator : UnityBaseEntity<Animator>, IAnimator
    {
        [FieldProxy(typeof(IAnimator))]
        public UnityAnimator(Animator animator) : base(animator) { }
        public T GetVariable<T>(int hash) where T : struct => UnityStaticAnimator<T>.Get(Original, hash);
        public void SetVariable<T>(int hash, T value) where T : struct => UnityStaticAnimator<T>.Set(Original, hash, value);
        public void SetTrigger(int hash) => Original.SetTrigger(hash);
    }
}
