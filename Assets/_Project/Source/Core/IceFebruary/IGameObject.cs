namespace IceFebruary
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IGameObject : IBaseEntity
    {
        ITransform Transform { get; }
        int Layer { get; set; }
        SetOnce<IBaseEntity> MainComponent { get; }
        IRootConfig GetRootConfig();
    }
}
