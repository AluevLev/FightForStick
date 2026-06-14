using IceFebruary.Proxy;
using IceFebruary.Shapes;

public readonly struct PickUpSettings
{
    public float MaxSqrPickUpDistance { get; private init; }
    public IShape PickUpShape { get; private init; }

    [ScriptableObjectProxy]
    public PickUpSettings(float maxSqrPickUpDistance, IShape pickUpShape)
    {
        MaxSqrPickUpDistance = maxSqrPickUpDistance;
        PickUpShape = pickUpShape;
    }
}
