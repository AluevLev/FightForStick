namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class TransformVector2Provider : IProvider<Vector2>
    {
        private readonly ITransform _transform;
        [FieldProxy(typeof(IProvider<Vector2>))]
        public TransformVector2Provider(ITransform transform)
        {
            _transform = transform;
        }
        public bool TryGet(out Vector2 point)
        {
            bool success = _transform.Exists();

            point = success ? _transform.Position.To2D() : default;

            return success;
        }
    }
}
