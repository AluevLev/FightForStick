namespace UnityIceFebruary.Components
{
    using IceFebruary;

    public class UnityFullDataComponent<T> : IEntireComponent<T> where T : IComponent
    {
        public UnityFullDataComponent(T unityComponent, IGameObject gameObject)
        {
            GameObject = gameObject;
            Transform = GameObject.Transform;
            Component = unityComponent;
        }
        public T Component { get; init; }
        public IGameObject GameObject { get; init; }
        public ITransform Transform { get; init; }
    }
}
