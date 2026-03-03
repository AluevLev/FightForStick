using System;
using VContainer;

public class StandartContainer : IContainer
{
    private readonly IObjectResolver _resolver;
    private readonly IContainerBuilder _builder = null;

    public StandartContainer(IObjectResolver resolver)
    {
        _resolver = resolver;
    }

    public StandartContainer(IContainerBuilder builder)
    {
        _builder = builder;
    }

    public T Resolve<T>() where T : class => Resolver.Resolve<T>();
    public object Resolve(Type type) => Resolver.Resolve(type);
    public void Register<T>(T instance) where T : class => Builder.RegisterInstance(instance);
    public void RegisterSingleton<T>(T instance) where T : class => Builder.RegisterInstance(instance).AsSelf();
    public void Register<T>(Func<IContainer, T> factory) where T : class => Builder.Register(resolver => factory(new StandartContainer(resolver)), Lifetime.Transient);
    public void RegisterSingleton<T>(Func<IContainer, T> factory) where T : class => Builder.Register(resolver => factory(new StandartContainer(resolver)), Lifetime.Singleton);
    private IObjectResolver Resolver => _resolver ?? throw new InvalidOperationException("Container is in Build mode. Use it only after Scope is started.");
    private IContainerBuilder Builder => _builder ?? throw new InvalidOperationException("Container is in Resolve mode. Registration is no longer possible.");
}
