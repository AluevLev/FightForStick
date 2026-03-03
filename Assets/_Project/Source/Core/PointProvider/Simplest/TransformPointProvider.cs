namespace February.Space.PointProvider
{
    using February.Proxy;
    using February.Space;
    using February.Components;

    public class TransformPointProvider : IPointProvider
    {
        private readonly ITransform _transform;
        [GenerateProxy(typeof(IPointProvider))]
        public TransformPointProvider(ITransform transform)
        {
            _transform = transform;
        }
        public bool TryGetPoint(out UniVector2 point)
        {
            bool hasValue = _transform != null;

            point = hasValue ? _transform.Position : default;

            return hasValue;
        }
    }
}
