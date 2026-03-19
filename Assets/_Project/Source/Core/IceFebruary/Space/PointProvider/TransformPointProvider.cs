namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public class TransformPointProvider : IPointProvider
    {
        private readonly ITransform _transform;
        [Proxy(typeof(IPointProvider))]
        public TransformPointProvider(ITransform transform)
        {
            _transform = transform;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            bool hasValue = _transform != null;

            point = hasValue ? _transform.Position : default;

            return hasValue;
        }
    }
}
