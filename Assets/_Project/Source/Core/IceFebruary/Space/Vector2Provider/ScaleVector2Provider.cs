namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class ScaleVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _vector2;
        private readonly float _scale;

        [FieldProxy(typeof(IVector2Provider))]
        public ScaleVector2Provider(IVector2Provider pointProvider, float scale)
        {
            _vector2 = pointProvider;
            _scale = scale;
        }
        public bool TryGet(out Vector2 point)
        {
            bool success = _vector2.TryGetSafety(out Vector2 vector2);

            point = success ? vector2 * _scale : default;

            return success;
        }
    }
}
