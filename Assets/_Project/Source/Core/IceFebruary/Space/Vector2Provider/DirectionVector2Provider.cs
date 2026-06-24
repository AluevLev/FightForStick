namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class DirectionVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _from;
        private readonly IVector2Provider _to;
        [FieldProxy(typeof(IVector2Provider))]
        public DirectionVector2Provider(IVector2Provider from, IVector2Provider to)
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
