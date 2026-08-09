using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct MovementConfig
{
    public IRigidbody2D PushBody { get; private init; }
    public MovementSettings Settings { get; private init; }
    public AreaScannerConfig GroundAreaScannerConfig { get; private init; }

    [FieldProxy]
    public MovementConfig(IRigidbody2D pushBody, MovementSettings settings, AreaScannerConfig groundAreaScannerConfig)
    {
        PushBody = pushBody;
        Settings = settings;
        GroundAreaScannerConfig = groundAreaScannerConfig;
    }
}
