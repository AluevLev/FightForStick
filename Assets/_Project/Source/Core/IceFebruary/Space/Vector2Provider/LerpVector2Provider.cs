namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class LerpVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _first;
        private readonly IVector2Provider _second;
        private readonly float _interpolation;

        [FieldProxy(typeof(IVector2Provider))]
        public LerpVector2Provider(IVector2Provider first, IVector2Provider second, float interpolation)
        {
            _first = first;
            _second = second;
            _interpolation = interpolation;
        }
        public bool TryGet(out Vector2 point)
        {
            if (_first.TryGetSafety(out Vector2 first) && _second.TryGetSafety(out Vector2 second))
            {
                point = Vector2.Lerp(first, second, _interpolation);
                return true;
            }

            point = default;
            return false;
        }
    }
}
