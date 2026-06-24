namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class ScaleVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _pointProvider;
        private readonly float _scale;
        [FieldProxy(typeof(IVector2Provider))]
        public ScaleVector2Provider(IVector2Provider pointProvider, float scale)
        {
            _pointProvider = pointProvider;
            _scale = scale;
        }
        public bool TryGet(out Vector2 point)
        {
            bool success = _pointProvider.TryGetSafety(out Vector2 startPoint);

            point = success ? startPoint * _scale : default;

            return success;
        }
    }
}
