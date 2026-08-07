using IceFebruary;
using IceFebruary.Factories;

public sealed class BulletFactory : ISettableUp<BulletConfig>
{
	private readonly IObjectManager _objectManager;
	public BulletFactory(IObjectManager objectManager)
	{
		_objectManager = objectManager;
	}
	public void SetUp(BulletConfig config)
	{
        config.GameObject.MainComponent = config.Rigidbody2D;
    }
}
