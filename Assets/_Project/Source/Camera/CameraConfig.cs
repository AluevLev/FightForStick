using IceFebruary.Render;
using IceFebruary.Proxy;
using IceFebruary;

public sealed class CameraConfig : IRootConfig
{
	public ITransform Transform { get; private init; }
	public ICamera Camera { get; private init; }
	public float Interpolation { get; private init; }
	public float MinSize {  get; private init; }
	public float MaxSize { get; private init; }

	[Proxy]
	public CameraConfig(ITransform transform, ICamera camera, float interpolation, float minSize, float maxSize)
	{
		Transform = transform;
		Camera = camera;
		Interpolation = interpolation;
		MinSize = minSize;
		MaxSize = maxSize;
	}
}
