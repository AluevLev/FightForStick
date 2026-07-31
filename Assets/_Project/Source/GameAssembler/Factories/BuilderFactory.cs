using IceFebruary;
using IceFebruary.Space;
using System;

public sealed class BuilderFactory<TBuilder, TConfig> : BaseEntity where TBuilder : ISetUpper<TConfig> where TConfig : struct
{
    private readonly IObjectManager _objectManager;
    private readonly Func<TBuilder> _builderFactory;
    public BuilderFactory(IObjectManager objectManager, Func<TBuilder> builderFactory)
    {
        _objectManager = objectManager;
        _builderFactory = builderFactory;
    }
	public TBuilder Create(IGameObject prefab, Vector2 position, Rotor2 rotation)
	{
        if (!_objectManager.Create(prefab, position, rotation).TryGetInstantiateInfo(out TConfig config))
            return default;

        TBuilder builder = _builderFactory.Invoke();

        builder.SetUp(config);

        return builder;
    }
}
