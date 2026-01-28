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
    public bool HasValue => _mainCamera;
    public Vector2? GetPoint() => HasValue ? _mainCamera.ScreenToWorldPoint(_inputProvider.MousePosition) : null;
}
