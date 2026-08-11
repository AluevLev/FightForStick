using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PickUpConfig
{
    public IRigidbody2D[] EntityHands { get; private init; }
    public PickUpSettings Settings { get; private init; }
    public AreaScannerSettings ItemAreaScannerSettings { get; private init; }

    [FieldProxy]
    public PickUpConfig(IRigidbody2D[] entityHands, PickUpSettings settings, AreaScannerSettings itemAreaScannerSettings)
    {
        EntityHands = entityHands;
        Settings = settings;
        ItemAreaScannerSettings = itemAreaScannerSettings;
    }
}
