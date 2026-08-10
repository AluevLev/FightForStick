using IceFebruary.Factories;

public sealed class BulletFactory : ISettableUp<BulletConfig>
{
    public BulletFactory() { }
    public void SetUp(BulletConfig config)
    {
        config.Rigidbody2DComponent.GameObject.MainComponent = config.Rigidbody2DComponent.Value;
    }
}
