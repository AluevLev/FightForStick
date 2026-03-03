namespace February.Space.PointProvider
{
    using February.Proxy;
    using February.Space;
    public class AnglePointProvider : IPointProvider
    {
        private readonly UniVector2 _vectorAngle;
        [GenerateProxy(typeof(IPointProvider))]
        public AnglePointProvider(float angle)
        {
            _vectorAngle = angle.GetVector();
        }
        public bool TryGetPoint(out UniVector2 point)
        {
            point = _vectorAngle;
            return true;
        }
    }
}
