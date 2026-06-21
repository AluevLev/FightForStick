namespace IceFebruary.Animation
{
    public readonly struct AnimatorFloatField
    {
        public readonly AnimatorFieldData _animatorFieldData;
        public AnimatorFloatField(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public float Value
        {
            get => _animatorFieldData.Animator.GetFloat(_animatorFieldData.Hash);
            set => _animatorFieldData.Animator.SetFloat(_animatorFieldData.Hash, value);
        }
    }
}
