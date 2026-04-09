namespace IceFebruary
{
    public interface IGameObject
    {
        ITransform Transform { get; }
        bool TryGetComponent<T>(out T component) where T : class;
    }
}
