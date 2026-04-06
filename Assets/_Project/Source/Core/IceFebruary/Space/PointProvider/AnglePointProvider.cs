namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class AnglePointProvider : IPointProvider
    {
        private readonly Vector2 _vectorAngle;
        [Proxy(typeof(IPointProvider))]
        public AnglePointProvider(float angle)
        {
            _vectorAngle = angle.GetVector();
        }
        public bool TryGetPoint(out Vector2 point)
        {
            point = _vectorAngle;
            return true;
        }
    }
}
