using IceFebruary;
using IceFebruary.Physics;

public sealed class BulletConfig : IRootConfig
{
    public Component<IRigidbody2D> Rigidbody2DComponent { get; private init; }

    public BulletConfig(Component<IRigidbody2D> rigidbody2DComponent)
    {
        Rigidbody2DComponent = rigidbody2DComponent;
    }
}
