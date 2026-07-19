using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct PickUpConfig
{
    public Component<IRigidbody2D>[] EntityHands { get; private init; }
    public PickUpSettings Settings { get; private init; }
    public AreaScannerSettings ItemAreaScannerSettings { get; private init; }

    [FieldProxy]
    public PickUpConfig(IRigidbody2D[] entityHandsRigidbodies2D, IGameObject[] entityHandsGameObjects,
        PickUpSettings settings, AreaScannerSettings itemAreaScannerSettings)
    {
        Component<IRigidbody2D>[] components = new Component<IRigidbody2D>[entityHandsRigidbodies2D.Length];

        for (int index = 0; index < entityHandsRigidbodies2D.Length; index++)
            components[index] = new Component<IRigidbody2D>(entityHandsRigidbodies2D[index], entityHandsGameObjects[index]);

        EntityHands = components;
        Settings = settings;
        ItemAreaScannerSettings = itemAreaScannerSettings;
    }
}
