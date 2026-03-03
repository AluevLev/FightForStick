namespace February.Space.PointProvider
{
    using February.Space;
    using February.Components;
    using February.Proxy;

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
        public bool TryGetPoint(out UniVector2 point)
        {
            if (_space != null && _pointProvider.TryGetPointSafe(out UniVector2 startPoint))
            {
                point = _space.TransformDirection(startPoint);
                return true;
            }

            point = default;
            return false;
        }
    }
}
