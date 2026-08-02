using IceFebruary;
using IceFebruary.Space;

public sealed class Factory<TSettableUp, TConfig> : BaseEntity, IObjectManager where TSettableUp : ISettableUp<TConfig> where TConfig : struct
{
    private readonly IObjectManager _objectManager;
    private readonly TSettableUp _builderFactory;
    public Factory(IObjectManager objectManager, TSettableUp builderFactory)
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
