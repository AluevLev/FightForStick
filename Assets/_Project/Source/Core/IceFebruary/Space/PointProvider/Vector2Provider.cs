namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Proxy;

    public sealed class Vector2Provider : IProvider<Vector2>
    {
        private readonly Vector2 _vector2;
        [FieldProxy(typeof(IProvider<Vector2>))]
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
