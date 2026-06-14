namespace IceFebruary
{
    public readonly struct Component<T> where T : class, IBaseEntity
    {
        public Component(T component, IGameObject gameObject)
        {
            Value = component;
            GameObject = gameObject;
            Transform = gameObject.Transform;
        }
        public T Value { get; private init; }
        public IGameObject GameObject { get; private init; }
        public ITransform Transform { get; private init; }
    }
}
