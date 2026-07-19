namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;
    using IceFebruary.Space.Vector2Provider;

    public sealed class DirectionRotor2Provider : IRotor2Provider
    {
        private readonly IVector2Provider _from;
        private readonly IVector2Provider _to;

        [FieldProxy(typeof(IRotor2Provider))]
        public DirectionRotor2Provider(IVector2Provider from, IVector2Provider to)
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

            angle = Rotor2.Default;
            return false;
        }
    }
}
