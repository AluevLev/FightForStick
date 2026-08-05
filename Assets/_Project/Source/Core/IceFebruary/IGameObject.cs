namespace IceFebruary
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IGameObject : IBaseEntity
    {
        ITransform Transform { get; }
        int Layer { get; set; }
        SetOnce<IBaseEntity> MainComponent { get; }
        public bool TryGetInstantiateInfo<T>(out T content) where T : struct;
    }
}
