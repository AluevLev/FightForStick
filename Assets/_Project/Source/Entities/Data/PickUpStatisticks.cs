using IceFebruary.Proxy;
using IceFebruary.Shapes;

public readonly struct PickUpStatisticks
{
    public float MaxSqrPickUpDistance { get; private init; }
    public IShape PickUpShape { get; private init; }

    [ScriptableObjectProxy]
    public PickUpStatisticks(float maxSqrPickUpDistance, IShape pickUpShape)
    {
        MaxSqrPickUpDistance = maxSqrPickUpDistance;
        PickUpShape = pickUpShape;
    }
}
