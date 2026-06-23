namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Render;

    public sealed class CursorPointProvider : IProvider<Vector2>
    {
        private readonly IInputProvider _inputProvider;
        private readonly ICamera _mainCamera;
        public CursorPointProvider(IInputProvider inputProvider, ICamera camera)
        {
            _inputProvider = inputProvider;
            _mainCamera = camera;
        }
        public bool TryGet(out Vector2 point)
        {
            bool hasValue = _mainCamera.Exists() && _inputProvider.Exists();

            point = hasValue ? _mainCamera.ScreenToWorldPoint(_inputProvider.MousePosition) : default;

            return hasValue;
        }
    }
}
