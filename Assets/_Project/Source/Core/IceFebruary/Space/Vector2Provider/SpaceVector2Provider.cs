namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class SpaceVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _pointProvider;
        private readonly ITransform _space;
        [FieldProxy(typeof(IVector2Provider))]
        public SpaceVector2Provider(IVector2Provider pointProvider, ITransform space)
        {
            _space = space;
            _pointProvider = pointProvider;
        }
        public bool TryGet(out Vector2 point)
        {
            if (_space.Exists() && _pointProvider.TryGetSafety(out Vector2 startPoint))
            {
                point = _space.TransformDirection(startPoint);
                return true;
            }

            point = default;
            return false;
        }
    }
}
