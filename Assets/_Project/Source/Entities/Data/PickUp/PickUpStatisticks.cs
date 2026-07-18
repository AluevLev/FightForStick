using IceFebruary.Proxy;
using IceFebruary.Shapes;

public readonly struct PickUpStatisticks
{
    public float MaxSqrPickUpDistance { get; private init; }
    public int MaxBufferForCheck { get; private init; }
    public IShape PickUpShape { get; private init; }

    [ScriptableObjectProxy]
    public PickUpStatisticks(float maxSqrPickUpDistance, int maxBufferForCheck, IShape pickUpShape)
    {
        MaxSqrPickUpDistance = maxSqrPickUpDistance;
        MaxBufferForCheck = maxBufferForCheck;
        PickUpShape = pickUpShape;
    }
}
