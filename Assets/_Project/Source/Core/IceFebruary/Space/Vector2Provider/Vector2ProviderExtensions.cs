namespace IceFebruary.Space.Vector2Provider
{
    public static class Vector2ProviderExtensions
    {
        public static bool TryGetSafety(this IVector2Provider rotor2Provider, out Vector2 value)
        {
            if (rotor2Provider != null)
                return rotor2Provider.TryGet(out value);
            value = default;
            return false;
        }
    }
}
