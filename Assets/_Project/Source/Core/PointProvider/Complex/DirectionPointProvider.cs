namespace February.Space.PointProvider
{
    using February.Proxy;
    public class DirectionPointProvider : IPointProvider
    {
        private readonly IPointProvider _from;
        private readonly IPointProvider _to;
        [GenerateProxy(typeof(IPointProvider))]
        public DirectionPointProvider(IPointProvider from, IPointProvider to)
        {
            _from = from;
            _to = to;
        }
        public bool TryGetPoint(out UniVector2 point)
        {
            if (_from.TryGetPointSafe(out UniVector2 from) && _to.TryGetPointSafe(out UniVector2 to))
            {
                point = from.DirectionTo(to);
                return true;
            }

            point = default;
            return false;
        }
    }
}
