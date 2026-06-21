namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    public readonly struct AnimatorIntField
    {
        public readonly AnimatorFieldData _animatorFieldData;
        [FieldProxy]
        public AnimatorIntField(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public int Value
        {
            get => _animatorFieldData.Animator.GetInt(_animatorFieldData.Hash);
            set => _animatorFieldData.Animator.SetInt(_animatorFieldData.Hash, value);
        }
    }
}
