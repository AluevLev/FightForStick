namespace IceFebruary.Animation
{
    public readonly struct AnimatorTrigger
    {
        private readonly AnimatorFieldData _animatorFieldData;
        public AnimatorTrigger(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public void Set() => _animatorFieldData.Animator.SetTrigger(_animatorFieldData.Hash);
    }
}
