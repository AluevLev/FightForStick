namespace IceFebruary
{
    using System;

    public static class DisposableExtensions
    {
        public static void TryDispose<T>(this T obj) where T : class
        {
            if (obj is IDisposable disposable)
                disposable.Dispose();
        }
        public static bool EnsureAlive<T>(this T obj) where T : class => obj != null;
        public static bool EnsureAlive<T>(this Destroyable<T> disposableObject) where T : class => disposableObject != null && !disposableObject.IsDestroyed;
    }
}
