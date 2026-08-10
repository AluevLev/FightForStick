using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PickUpConfig
{
    public Component<IRigidbody2D>[] EntityHands { get; private init; }
    public PickUpSettings Settings { get; private init; }
    public AreaScannerSettings ItemAreaScannerSettings { get; private init; }

    [FieldProxy]
    public PickUpConfig(Component<IRigidbody2D>[] entityHands, PickUpSettings settings, AreaScannerSettings itemAreaScannerSettings)
    {
        EntityHands = entityHands;
        Settings = settings;
        ItemAreaScannerSettings = itemAreaScannerSettings;
    }
}
