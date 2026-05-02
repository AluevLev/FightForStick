namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class TransformPointProvider : IPointProvider
    {
        private readonly ITransform2D _transform;
        [Proxy(typeof(IPointProvider))]
        public TransformPointProvider(ITransform2D transform)
        {
            _transform = transform;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            bool success = _transform.Exists();

            point = success ? _transform.Position : default;

            return success;
        }
    }
}
