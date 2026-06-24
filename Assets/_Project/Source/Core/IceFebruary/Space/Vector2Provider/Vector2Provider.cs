namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    public sealed class Vector2Provider : IVector2Provider
    {
        private readonly Vector2 _vector2;
        [FieldProxy(typeof(IVector2Provider))]
        public Vector2Provider(Vector2 vector2)
        {
            _vector2 = vector2;
        }
        public bool TryGet(out Vector2 point)
        {
            point = _vector2;
            return true;
        }
    }
}
