namespace IceFebruary
{
    public interface IGameObject : IBaseEntity
    {
        ITransform2D Transform { get; }
        bool TryGetComponent<T>(out T component) where T : class, IBaseEntity;
    }
}
