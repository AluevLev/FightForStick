namespace IceFebruary.Animation
{
    public readonly struct AnimatorFieldData
    {
        public IAnimator Animator { get; init; }
        public int Hash { get; init; }
        public AnimatorFieldData(IAnimator animator, int hash)
        {
            Animator = animator;
            Hash = hash;
        }
    }
}
