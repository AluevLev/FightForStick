namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;
    using IceFebruary.Space.PointProvider;

    public sealed class DirectionAngleProvider : IAngleProvider
    {
        private readonly IPointProvider _from;
        private readonly IPointProvider _to;
        [FieldProxy(typeof(IAngleProvider))]
        public DirectionAngleProvider(IPointProvider from, IPointProvider to)
        {
            _from = from;
            _to = to;
        }
        public bool TryGetAngle(out Rotor2 angle)
        {
            if (_from.TryGetPointSafe(out Vector2 from) && _to.TryGetPointSafe(out Vector2 to))
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
