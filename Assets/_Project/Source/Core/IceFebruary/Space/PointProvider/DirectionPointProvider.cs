namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class DirectionPointProvider : IPointProvider
    {
        private readonly IPointProvider _from;
        private readonly IPointProvider _to;
        [FieldProxy(typeof(IPointProvider))]
        public DirectionPointProvider(IPointProvider from, IPointProvider to)
        {
            _from = from;
            _to = to;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            if (_from.TryGetPointSafe(out Vector2 from) && _to.TryGetPointSafe(out Vector2 to))
            {
                point = from.DirectionTo(to);
                return true;
            }

            point = default;
            return false;
        }
    }
}
