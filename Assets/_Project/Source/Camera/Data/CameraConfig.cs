using IceFebruary;
using IceFebruary.Proxy;
using IceFebruary.Render;

public sealed class CameraConfig : IRootConfig
{
    public ITransform Transform { get; private init; }
    public ICamera Camera { get; private init; }
    public CameraSettings Settings { get; private init; }

    [Proxy]
    public CameraConfig(ITransform transform, ICamera camera, CameraSettings settings)
    {
        Transform = transform;
        Camera = camera;
        Settings = settings;
    }
}
