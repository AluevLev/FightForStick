namespace IceFebruary
{
    public readonly struct Component<T> where T : class, IBaseEntity
    {
        public Component(T component, IGameObject gameObject)
        {
            Value = component;
            GameObject = gameObject;
        }
        public T Value { get; private init; }
        public IGameObject GameObject { get; private init; }
        public bool Unpack(out T component, out IGameObject gameObject)
        {
            component = Value;
            gameObject = GameObject;
            return component.Exists() && gameObject.Exists();
        }
    }
}
