namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Render;

    public sealed class CursorPointProvider : IVector2Provider
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
            bool hasValue = _mainCamera.Active() && _inputProvider.Active();

            point = hasValue ? _mainCamera.ScreenToWorldPoint(_inputProvider.MousePosition) : default;

            return hasValue;
        }
    }
}
