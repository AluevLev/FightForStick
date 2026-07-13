using IceFebruary.Proxy;

namespace IceFebruary.Space.Vector2Provider
{
    public sealed class NormalizedVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _notNormalized;
        [FieldProxy(typeof(IVector2Provider))]
        public NormalizedVector2Provider(IVector2Provider notNormalized)
        {
            _notNormalized = notNormalized;
        }
        public bool TryGet(out Vector2 point)
        {
            bool success = _notNormalized.TryGetSafety(out Vector2 notNormalized);

            point = success ? notNormalized.Normalized : default;

            return success;
        }
    }
}
