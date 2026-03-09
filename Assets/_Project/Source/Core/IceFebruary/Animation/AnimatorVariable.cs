namespace IceFebruary.Animation
{
    public readonly struct AnimatorVariable<T> where T : struct
    {
        private readonly AnimatorFieldData _animatorFieldData;
        public AnimatorVariable(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public T Value
        {
            get => _animatorFieldData.Animator.GetVariable<T>(_animatorFieldData.Hash);
            set => _animatorFieldData.Animator.SetVariable(_animatorFieldData.Hash, value);
        }
        public static implicit operator T(AnimatorVariable<T> animator) => animator.Value;
    }
}
