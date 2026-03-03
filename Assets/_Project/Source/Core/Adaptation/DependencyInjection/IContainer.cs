using System;

public interface IContainer
{
    T Resolve<T>() where T : class;
    object Resolve(Type type);
    void Register<T>(T instance) where T : class;
    void Register<T>(Func<IContainer, T> factory) where T : class;
    void RegisterSingleton<T>(T instance) where T : class;
    void RegisterSingleton<T>(Func<IContainer, T> factory) where T : class;
}
