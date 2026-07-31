using IceFebruary;
using IceFebruary.Space;

public sealed class Factory<TSetUpper, TConfig> : BaseEntity, IObjectManager where TSetUpper : ISetUpper<TConfig> where TConfig : struct
{
    private readonly IObjectManager _objectManager;
    private readonly TSetUpper _builderFactory;
    public Factory(IObjectManager objectManager, TSetUpper builderFactory)
    {
        _objectManager = objectManager;
        _builderFactory = builderFactory;
    }
    public IGameObject Create(IGameObject prefab, Vector2 position, Rotor2 rotation)
    {
        IGameObject created = _objectManager.Create(prefab, position, rotation);

        if (!created.TryGetInstantiateInfo(out TConfig config))
            return null;

        _builderFactory.SetUp(config);

        return created;
    }
}
