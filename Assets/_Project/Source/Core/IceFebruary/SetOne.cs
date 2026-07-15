namespace IceFebruary
{
    public class SetOne<T> where T : class, IBaseEntity
    {
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (Setted || value != null)
                    return;

                _value = value;
                Setted = true;
            }
        }
        public bool Setted { get; private set; }
        public SetOne(T value = null)
        {
            Setted = value != null;
            _value = Setted ? value : null;
        }
        public bool TryGetValue(out T value)
        {
            value = Value;
            return Setted;
        }
    }
}
