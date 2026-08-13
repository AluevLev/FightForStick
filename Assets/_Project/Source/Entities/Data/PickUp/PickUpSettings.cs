using IceFebruary.Proxy;

public readonly struct PickUpSettings
{
    public float MaxSqrPickUpDistance { get; private init; }
    public int EntityLayer { get; private init; }

    [DataObjectProxy]
    public PickUpSettings(float maxSqrPickUpDistance, int entityLayer)
    {
        MaxSqrPickUpDistance = maxSqrPickUpDistance;
        EntityLayer = entityLayer;
    }
}
