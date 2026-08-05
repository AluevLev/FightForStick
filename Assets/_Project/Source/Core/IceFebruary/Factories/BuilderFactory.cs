namespace IceFebruary.Factories
{
    using IceFebruary;
    using IceFebruary.Space;
    using System;

    public sealed class BuilderFactory<TBuilder, TConfig> : BaseEntity where TBuilder : ISettableUp<TConfig>
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
            IRootConfig rootConfig = _objectManager.Create(prefab, position, rotation).GetRootConfig();

            if (rootConfig == null || rootConfig is not TConfig config)
                return default;

            TBuilder builder = _builderFactory.Invoke();

            builder.SetUp(config);

            return builder;
        }
    }
}
