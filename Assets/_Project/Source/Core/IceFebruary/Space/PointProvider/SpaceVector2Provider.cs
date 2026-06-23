namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class SpaceVector2Provider : IProvider<Vector2>
    {
        private readonly IProvider<Vector2> _pointProvider;
        private readonly ITransform _space;
        [FieldProxy(typeof(IProvider<Vector2>))]
        public SpaceVector2Provider(IProvider<Vector2> pointProvider, ITransform space)
        {
            _space = space;
            _pointProvider = pointProvider;
        }
        public bool TryGet(out Vector2 point)
        {
            if (_space.Exists() && _pointProvider.TryGetSafety(out Vector2 startPoint))
            {
                point = _space.TransformDirection(startPoint.To3D()).To2D();
                return true;
            }

            point = default;
            return false;
        }
    }
}
