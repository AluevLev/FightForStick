using IceFebruary.Proxy;

public readonly struct CameraSettings
{
    public float Interpolation { get; private init; }
    public float MinSize { get; private init; }
    public float MaxSize { get; private init; }
    public float Sensitivity { get; private init; }

    [DataObjectProxy]
    public CameraSettings(float interpolation, float minSize, float maxSize, float sensitivity)
    {
        Interpolation = interpolation;
        MinSize = minSize;
        MaxSize = maxSize;
        Sensitivity = sensitivity;
    }
}
