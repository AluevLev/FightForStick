namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public sealed class DirectionRotor2Provider : IProvider<Rotor2>
    {
        private readonly IProvider<Vector2> _from;
        private readonly IProvider<Vector2> _to;

        [FieldProxy(typeof(IProvider<Rotor2>))]
        public DirectionRotor2Provider(IProvider<Vector2> from, IProvider<Vector2> to)
        {
            _from = from;
            _to = to;
        }
        public bool TryGet(out Rotor2 angle)
        {
            if (_from.TryGetSafety(out Vector2 from) && _to.TryGetSafety(out Vector2 to))
            {
                Vector2 direction = from.DirectionTo(to).Normalized;

                float scalar = Math.Sqrt((1f + direction.X) * 0.5f);
                float xy = Math.Sign(direction.Y) * Math.Sqrt((1f - direction.X) * 0.5f);

                angle = new Rotor2(scalar, xy);
                return true;
            }

            angle = default;
            return false;
        }
    }
}
