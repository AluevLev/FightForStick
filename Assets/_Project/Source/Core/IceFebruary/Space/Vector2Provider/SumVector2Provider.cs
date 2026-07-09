namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class SumVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _first;
        private readonly IVector2Provider _second;
        [FieldProxy(typeof(IVector2Provider))]
        public SumVector2Provider(IVector2Provider minuend, IVector2Provider subtrahend)
        {
            _first = minuend;
            _second = subtrahend;
        }
        public bool TryGet(out Vector2 point)
        {
            if (_first.TryGetSafety(out Vector2 first) && _second.TryGetSafety(out Vector2 second))
            {
                point = first + second;
                return true;
            }

            point = default;
            return false;
        }
    }
}
