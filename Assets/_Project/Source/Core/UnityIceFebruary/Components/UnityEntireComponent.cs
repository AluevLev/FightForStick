namespace UnityIceFebruary.Components
{
    using IceFebruary;

    public sealed class UnityEntireComponent<T> : IComponent<T> where T : class
    {
        public UnityEntireComponent(T unityComponent, IGameObject gameObject)
        {
            GameObject = gameObject;
            Transform = GameObject.Transform;
            Component = unityComponent;
        }
        public T Component { get; private init; }
        public IGameObject GameObject { get; private init; }
        public ITransform Transform { get; private init; }
    }
}
