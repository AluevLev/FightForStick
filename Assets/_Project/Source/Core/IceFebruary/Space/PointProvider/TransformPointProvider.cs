namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class TransformPointProvider : IPointProvider
    {
        private readonly IEntity<ITransform> _transform;
        [Proxy(typeof(IPointProvider))]
        public TransformPointProvider(IEntity<ITransform> transform)
        {
            _transform = transform;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            bool hasValue = _transform.TryGetInner(out ITransform inner);

            point = hasValue ? inner.Position : default;

            return hasValue;
        }
    }
}
