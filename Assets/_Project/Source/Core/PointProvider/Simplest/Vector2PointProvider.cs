namespace February.Space.PointProvider
{
    using February.Proxy;
    using February.Space;

    public sealed class Vector2PointProvider : IPointProvider
    {
        private readonly UniVector2 _vector2;
        [GenerateProxy(typeof(IPointProvider))]
        public Vector2PointProvider(UniVector2 vector2)
        {
            _vector2 = vector2;
        }
        public Vector2PointProvider(float x, float y)
        {
            _vector2 = new(x, y);
        }
        public bool TryGetPoint(out UniVector2 point)
        {
            point = _vector2;
            return true;
        }
    }
}
