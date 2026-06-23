namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class ScaleVector2Provider : IProvider<Vector2>
    {
        private readonly IProvider<Vector2> _pointProvider;
        private readonly float _scale;
        [FieldProxy(typeof(IProvider<Vector2>))]
        public ScaleVector2Provider(IProvider<Vector2> pointProvider, float scale)
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
