using IceFebruary.Proxy;

public readonly struct PickUpSettings
{
    public float MaxPickUpDistance { get; init; }

    [GenerateScriptableObjectProxy]
    public PickUpSettings(float maxPickUpDistance)
    {
        MaxPickUpDistance = maxPickUpDistance;
    }
}
