public static class PositionProviderExtensions
{
    public static bool Exists(this IPointProvider pointProvider) => pointProvider != null && pointProvider.HasValue;
    public static DirectionPointProvider DirectionTo(this IPointProvider origin, IPointProvider target) => new(origin, target);
}
