namespace IceFebruary
{
    public interface IGameObject : IBaseEntity
    {
        ITransform Transform { get; }
        bool TryGetComponent<T>(out T component) where T : class;
    }
}
