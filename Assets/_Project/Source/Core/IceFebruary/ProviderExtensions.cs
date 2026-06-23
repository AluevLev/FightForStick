namespace IceFebruary
{
    public static class ProviderExtensions
    {
        public static bool TryGetSafety<T>(this IProvider<T> provider, out T value) where T : struct
        {
            if (provider != null)
                return provider.TryGet(out value);
            value = default;
            return false;
        }
    }
}
