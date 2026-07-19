using IceFebruary.Proxy;

public readonly struct PickUpSettings
{
    public float MaxSqrPickUpDistance { get; private init; }

    [ScriptableObjectProxy]
    public PickUpSettings(float maxSqrPickUpDistance)
    {
        MaxSqrPickUpDistance = maxSqrPickUpDistance;
    }
}
