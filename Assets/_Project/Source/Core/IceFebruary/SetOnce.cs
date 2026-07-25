namespace IceFebruary
{
    public sealed class SetOnce<T> where T : class, IBaseEntity
    {
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (Setted)
                    return;

                _value = value;
                Setted = true;
            }
        }
        public bool Setted { get; private set; }
        public SetOnce() { }
        public bool TryGetValue(out T value)
        {
            value = Value;
            return Setted;
        }
    }
}
