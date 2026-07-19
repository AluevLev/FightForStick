using IceFebruary.Proxy;

namespace IceFebruary.Space.Vector2Provider
{
    public sealed class NormalizedVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _vector2;

        [FieldProxy(typeof(IVector2Provider))]
        public NormalizedVector2Provider(IVector2Provider vector2)
        {
            _vector2 = vector2;
        }
        public bool TryGet(out Vector2 point)
        {
            bool success = _vector2.TryGetSafety(out Vector2 notNormalized);

            point = success ? notNormalized.Normalized : default;

            return success;
        }
    }
}
