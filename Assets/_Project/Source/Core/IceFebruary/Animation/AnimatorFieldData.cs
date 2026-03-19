namespace IceFebruary.Animation
{
    public readonly struct AnimatorFieldData
    {
        public IAnimator Animator { get; private init; }
        public int Hash { get; private init; }
        public AnimatorFieldData(IAnimator animator, int hash)
        {
            Animator = animator;
            Hash = hash;
        }
        public static implicit operator int(AnimatorFieldData animator) => animator.Hash;
    }
}
