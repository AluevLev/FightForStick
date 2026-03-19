using IceFebruary.Proxy;

public readonly struct PickUpSettings
{
    public float MaxPickUpDistance { get; private init; }

    [ScriptableObjectProxy]
    public PickUpSettings(float maxPickUpDistance)
    {
        MaxPickUpDistance = maxPickUpDistance;
    }
}
