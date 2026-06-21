namespace IceFebruary.Animation
{
    public readonly struct AnimatorBoolField
    {
        public readonly AnimatorFieldData _animatorFieldData;
        public AnimatorBoolField(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public bool Value
        {
            get => _animatorFieldData.Animator.GetBool(_animatorFieldData.Hash);
            set => _animatorFieldData.Animator.SetBool(_animatorFieldData.Hash, value);
        }
    }
}
