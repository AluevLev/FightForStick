namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class DirectionVector2Provider : IProvider<Vector2>
    {
        private readonly IProvider<Vector2> _from;
        private readonly IProvider<Vector2> _to;
        [FieldProxy(typeof(IProvider<Vector2>))]
        public DirectionVector2Provider(IProvider<Vector2> from, IProvider<Vector2> to)
        {
            _from = from;
            _to = to;
        }
        public bool TryGet(out Vector2 point)
        {
            if (_from.TryGetSafety(out Vector2 from) && _to.TryGetSafety(out Vector2 to))
            {
                point = from.DirectionTo(to);
                return true;
            }

            point = default;
            return false;
        }
    }
}
