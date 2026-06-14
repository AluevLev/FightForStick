namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class SpacePointProvider : IPointProvider
    {
        private readonly IPointProvider _pointProvider;
        private readonly ITransform _space;
        [FieldProxy(typeof(IPointProvider))]
        public SpacePointProvider(IPointProvider pointProvider, ITransform space)
        {
            _space = space;
            _pointProvider = pointProvider;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            if (_space.Exists() && _pointProvider.TryGetPointSafe(out Vector2 startPoint))
            {
                point = _space.TransformDirection(startPoint);
                return true;
            }

            point = default;
            return false;
        }
    }
}
