namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    public readonly struct AnimatorTrigger
    {
        private readonly AnimatorFieldData _animatorFieldData;
        [FieldProxy]
        public AnimatorTrigger(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public void Set() => _animatorFieldData.Animator.SetTrigger(_animatorFieldData.Hash);
    }
}
