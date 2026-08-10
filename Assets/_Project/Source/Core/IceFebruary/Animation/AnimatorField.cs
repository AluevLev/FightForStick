namespace IceFebruary.Animation
{
    public readonly struct AnimatorField<T> where T : struct
    {
        public readonly AnimatorFieldData _animatorFieldData;
        public AnimatorField(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public T Value
        {
            get => _animatorFieldData.Animator.Get<T>(_animatorFieldData.Hash);
            set => _animatorFieldData.Animator.Set(_animatorFieldData.Hash, value);
        }
    }
}
