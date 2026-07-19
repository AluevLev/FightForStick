namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using IceFebruary.Render;
    using IceFebruary.Space;

    public sealed class ScreenToWorldVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _vector2;
        private readonly ICamera _mainCamera;

        [FieldProxy(typeof(IVector2Provider))]
        public ScreenToWorldVector2Provider(IVector2Provider inputProvider, ICamera camera)
        {
            _vector2 = inputProvider;
            _mainCamera = camera;
        }
        public bool TryGet(out Vector2 point)
        {
            if (_mainCamera.Active() && _vector2.TryGetSafety(out Vector2 vector2))
            {
                point = _mainCamera.ScreenToWorldPoint(vector2);
                return true;
            }

            point = default;
            return false;
        }
    }
}
