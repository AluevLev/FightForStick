using IceFebruary.Space.Vector2Provider;
using IceFebruary.Proxy;

public readonly struct ShootingConfig
{
    public ItemSettings ItemSettings { get; private init; }
    public IVector2Provider ShootDirection { get; private init; }
    public IVector2Provider ShootPoint { get; private init; }
    public ShootingSettings Settings { get; private init; }

    [Proxy]
    public ShootingConfig(ItemSettings itemSettings, IVector2Provider shootDirection, IVector2Provider shootPoint, ShootingSettings settings)
    {
        ItemSettings = itemSettings;
        ShootDirection = shootDirection;
        ShootPoint = shootPoint;
        Settings = settings;
    }
}
