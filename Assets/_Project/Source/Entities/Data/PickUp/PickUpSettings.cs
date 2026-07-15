using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Proxy;

public readonly struct PickUpSettings
{
    public Component<IRigidbody2D>[] Components { get; private init; }
    public IVector2Provider StickmanPosition { get; private init; }
    public PickUpStatisticks PickUpStatisticks { get; private init; }
    [FieldProxy]
    public PickUpSettings(IRigidbody2D[] rigidbodies, IGameObject[] gameObjects, IVector2Provider playerPosition, PickUpStatisticks pickUpStatisticks)
    {
        Component<IRigidbody2D>[] components = new Component<IRigidbody2D>[rigidbodies.Length];

        for (int index = 0; index < rigidbodies.Length; index++)
            components[index] = new Component<IRigidbody2D>(rigidbodies[index], gameObjects[index]);

        Components = components;
        StickmanPosition = playerPosition;
        PickUpStatisticks = pickUpStatisticks;
    }
}
