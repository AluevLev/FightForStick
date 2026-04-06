namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class SpacePointProvider : IPointProvider
    {
        private readonly IPointProvider _pointProvider;
        private readonly IEntity<ITransform> _space;
        [Proxy(typeof(IPointProvider))]
        public SpacePointProvider(IPointProvider pointProvider, IEntity<ITransform> space)
        {
            _space = space;
            _pointProvider = pointProvider;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            if (_space.TryGetInner(out ITransform inner) && _pointProvider.TryGetPointSafe(out Vector2 startPoint))
            {
                point = inner.TransformDirection(startPoint);
                return true;
            }

            point = default;
            return false;
        }
    }
}
