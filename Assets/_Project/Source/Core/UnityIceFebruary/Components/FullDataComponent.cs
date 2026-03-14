namespace UnityIceFebruary.Components
{
    using IceFebruary;

    public class FullDataComponent<T> : IFullDataComponent<T> where T : IComponent
    {
        public FullDataComponent(T unityComponent, IGameObject gameObject)
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
