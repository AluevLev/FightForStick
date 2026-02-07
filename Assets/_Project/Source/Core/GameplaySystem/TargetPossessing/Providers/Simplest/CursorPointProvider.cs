using UnityEngine;

public class CursorPointProvider : IPointProvider
{
    private readonly IInputProvider _inputProvider;
    private readonly Camera _mainCamera;
    public CursorPointProvider(IInputProvider inputProvider, Camera camera)
    {
        _inputProvider = inputProvider;
        _mainCamera = camera;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        bool hasValue = _mainCamera && _inputProvider != null;

        point = hasValue ? _mainCamera.ScreenToWorldPoint(_inputProvider.MousePosition) : default;

        return hasValue;
    }
}
