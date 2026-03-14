namespace IceFebruary
{
    public interface IGameObject : ITogglable
    {
        ITransform Transform { get; }
        bool TryGetComponent<T>(out T component) where T : class, IComponent;
    }
}
