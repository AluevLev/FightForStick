using IceFebruary.Proxy;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;

public readonly struct AreaScannerConfig
{
    public IVector2Provider Position { get; private init; }
    public IRotor2Provider Rotation { get; private init; }
    public AreaScannerSettings Settings { get; private init; }

    [FieldProxy]
    public AreaScannerConfig(IVector2Provider position, IRotor2Provider rotation, AreaScannerSettings settings)
    {
        Position = position;
        Rotation = rotation;
        Settings = settings;
    }
}
