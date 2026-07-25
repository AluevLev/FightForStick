using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PickUpConfig
{
    public Component<IRigidbody2D>[] EntityHands { get; private init; }
    public PickUpSettings Settings { get; private init; }
    public AreaScannerSettings ItemAreaScannerSettings { get; private init; }

    [FieldProxy]
    public PickUpConfig(Rigidbody2DComponent[] entityHands, PickUpSettings settings, AreaScannerSettings itemAreaScannerSettings)
    {
        EntityHands = new Component<IRigidbody2D>[entityHands.Length];

        for (int index = 0; index < entityHands.Length; index++)
        {
            Rigidbody2DComponent rigidbody2DComponent = entityHands[index];
            EntityHands[index] = new Component<IRigidbody2D>(rigidbody2DComponent.Rigidbody2D, rigidbody2DComponent.GameObject);
        }

        Settings = settings;
        ItemAreaScannerSettings = itemAreaScannerSettings;
    }
}
