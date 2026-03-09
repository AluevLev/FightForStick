namespace IceFebruary
{
    using IceFebruary.Components;

    public interface IGameObject : ITogglable
    {
        ITransform Transform { get; }
        bool TryGetComponent<T>(out T component) where T : class, IComponent;
    }
}
