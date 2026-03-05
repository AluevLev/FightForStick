namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Components;
    using IceFebruary.Proxy;

    public class SpacePointProvider : IPointProvider
    {
        private readonly IPointProvider _pointProvider;
        private readonly ITransform _space;
        [GenerateProxy(typeof(IPointProvider))]
        public SpacePointProvider(IPointProvider pointProvider, ITransform space)
        {
            _space = space;
            _pointProvider = pointProvider;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            if (_space != null && _pointProvider.TryGetPointSafe(out Vector2 startPoint))
            {
                point = _space.TransformDirection(startPoint);
                return true;
            }

            point = default;
            return false;
        }
    }
}
