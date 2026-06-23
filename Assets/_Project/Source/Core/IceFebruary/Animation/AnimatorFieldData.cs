namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    public readonly struct AnimatorFieldData
    {
        public IAnimator Animator { get; private init; }
        public int Hash { get; private init; }
        [FieldProxy]
        public AnimatorFieldData(IAnimator animator, int hash)
        {
            Animator = animator;
            Hash = hash;
        }
    }
}
