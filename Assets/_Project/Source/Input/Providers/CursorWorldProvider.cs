using UnityEngine;
using VContainer.Unity;
public class CursorWorldProvider : IScreenInWorld, ITickable
{
    private readonly IInputProvider _inputProvider;
    private readonly Camera _mainCamera;
    public CursorWorldProvider(IInputProvider inputProvider, Camera camera)
    {
        _inputProvider = inputProvider;
        _mainCamera = camera;
    }
    public void Tick()
    {
        MousePosition = _mainCamera.ScreenToWorldPoint(_inputProvider.MousePosition);
    }
    public Vector2 MousePosition { get; private set; }
}
