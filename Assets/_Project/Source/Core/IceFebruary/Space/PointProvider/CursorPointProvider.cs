namespace IceFebruary.Space.PointProvider
{
    using IceFebruary.Components;

    public class CursorPointProvider : IPointProvider
    {
        private readonly IInputProvider _inputProvider;
        private readonly ICamera _mainCamera;
        public CursorPointProvider(IInputProvider inputProvider, ICamera camera)
        {
            _inputProvider = inputProvider;
            _mainCamera = camera;
        }
        public bool TryGetPoint(out Vector2 point)
        {
            bool hasValue = _mainCamera != null && _inputProvider != null;

            point = hasValue ? _mainCamera.ScreenToWorldPoint(_inputProvider.MousePosition) : default;

            return hasValue;
        }
    }
}
