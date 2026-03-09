namespace IceFebruary.Animation
{
    using IceFebruary.Components;

    public readonly struct AnimatorFieldData
    {
        private readonly IAnimator _animator;
        private readonly int _hash;
        public IAnimator Animator => _animator;
        public int Hash => _hash;
        public AnimatorFieldData(IAnimator animator, int hash)
        {
            _animator = animator;
            _hash = hash;
        }
    }
}
