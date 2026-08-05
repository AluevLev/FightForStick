using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;
using IceFebruary.Space.Vector2Provider;

public sealed class ShootingConfig : IRootConfig
{
    public ItemSettings ItemSettings { get; private init; }
    public IRigidbody2D Rigidbody2D { get; private init; }
    public IVector2Provider ShootDirection { get; private init; }
    public IVector2Provider ShootPoint { get; private init; }
    public ShootingSettings Settings { get; private init; }

    [Proxy]
    public ShootingConfig(ItemSettings itemSettings, IRigidbody2D rigidbody2D, IVector2Provider shootDirection, IVector2Provider shootPoint, ShootingSettings settings)
    {
        ItemSettings = itemSettings;
        Rigidbody2D = rigidbody2D;
        ShootDirection = shootDirection;
        ShootPoint = shootPoint;
        Settings = settings;
    }
}
