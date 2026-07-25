namespace IceFebruary
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IGameObject : IBaseEntity
    {
        ITransform Transform { get; }
        SetOnce<IBaseEntity> MainComponent { get; }
        bool TryGetComponent<T>(out T component) where T : class, IBaseEntity;
        public bool TryGetInstantiateInfo<T>(out T content) where T : struct;
    }
}
