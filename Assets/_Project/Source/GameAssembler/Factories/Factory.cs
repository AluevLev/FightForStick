using IceFebruary;
using IceFebruary.Space;
using System;

public sealed class Factory<TBuilder, TConfig> where TBuilder : IBuilder<TConfig> where TConfig : struct
{
    private readonly IObjectManager _objectManager;
    private readonly Func<TBuilder> _builderFactory;
    public Factory(IObjectManager objectManager, Func<TBuilder> builderFactory)
    {
        _objectManager = objectManager;
        _builderFactory = builderFactory;
    }
	public TBuilder Create(IGameObject prefab, Vector2 position)
	{
        bool success = _objectManager.Create(prefab, position, Rotor2.Default).TryGetInstantiateInfo(out TConfig config);

        if (!success)
            return default;

        TBuilder builder = _builderFactory.Invoke();

        builder.SetConfig(config);

        return builder;
    }
}
