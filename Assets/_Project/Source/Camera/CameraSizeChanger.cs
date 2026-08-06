using IceFebruary;
using IceFebruary.Render;
using IceFebruary.Time;

public sealed class CameraSizeChanger : BaseEntity, IFrame
{
	private readonly IInputProvider _inputProvider;
	private readonly ICamera _camera;
	private readonly float _minSize;
	private readonly float _maxSize;
	private readonly float _sensitivity;
	public CameraSizeChanger(IInputProvider inputProvider, ICamera camera, float minSize, float maxSize, float sensitivity = -0.5f)
	{
		_inputProvider = inputProvider;
		_camera = camera;
		_minSize = minSize;
		_maxSize = maxSize;
		_sensitivity = sensitivity;
	}
    public void OnFrame(float frameLength) => _camera.Size = Math.Clamp(_camera.Size + _inputProvider.MouseScrolldown * _sensitivity, _minSize, _maxSize);
}
