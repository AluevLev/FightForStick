namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class TransformVector2Provider : IVector2Provider
    {
        private readonly ITransform _transform;
        [FieldProxy(typeof(IVector2Provider))]
        public TransformVector2Provider(ITransform transform)
        {
            _transform = transform;
        }
        public bool TryGet(out Vector2 point)
        {
            bool success = _transform.Exists();

            point = success ? _transform.Position : default;

            return success;
        }
    }
}
