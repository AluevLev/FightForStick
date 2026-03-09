namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Components;

    public class UnityAnimator : IAnimator
    {
        private readonly UnityEngine.Animator _animator;
        public UnityAnimator(UnityEngine.Animator animator)
        {
            _animator = animator;
            GameObject = new UnityGameObject(animator.gameObject);
        }
        public IGameObject GameObject { get; init; }
        public bool Enabled
        {
            get => _animator.enabled;
            set => _animator.enabled = value;
        }
        public T GetVariable<T>(int hash) where T : struct => UnityStaticAnimator<T>.Get(_animator, hash);
        public void SetVariable<T>(int hash, T value) where T : struct => UnityStaticAnimator<T>.Set(_animator, hash, value);
        public void SetTrigger(int hash) => _animator.SetTrigger(hash);
    }
}
