namespace IceFebruary.Space.PointProvider
{
    public static class PointProviderExtensions
    {
        public static bool TryGetPointSafe(this IPointProvider pointProvider, out Vector2 point)
        {
            if (pointProvider != null)
                return pointProvider.TryGetPoint(out point);
            point = default;
            return false;
        }
    }
}
