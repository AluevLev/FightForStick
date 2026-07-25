namespace IceFebruary.Space.Vector2Provider
{
    public static class Vector2ProviderExtensions
    {
        public static bool TryGetSafety(this IVector2Provider vector2Provider, out Vector2 value)
        {
            if (vector2Provider != null)
                return vector2Provider.TryGet(out value);
            value = default;
            return false;
        }
        public static Vector2 GetSafety(this IVector2Provider vector2Provider)
        {
            vector2Provider.TryGetSafety(out Vector2 position);
            return position;
        }
    }
}
