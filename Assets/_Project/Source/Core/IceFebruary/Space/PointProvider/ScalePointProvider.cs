namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class ScalePointProvider : IPointProvider
    {
        private readonly IPointProvider _pointProvider;
        private readonly float _scale;
        [Proxy(typeof(IPointProvider))]
        public ScalePointProvider(IPointProvider pointProvider, float scale)
        {
            _pointProvider = pointProvider;
            _scale = scale;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            bool success = _pointProvider.TryGetPoint(out Vector2 startPoint);

            point = success ? startPoint * _scale : default;

            return success;
        }
    }
}
