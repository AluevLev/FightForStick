using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct BulletConfig
{
	public IGameObject GameObject { get; private init; }
	public IRigidbody2D Rigidbody2D { get; private init; }

	[Proxy]
	public BulletConfig(IGameObject gameObject, IRigidbody2D rigidbody2D)
	{
		GameObject = gameObject;
		Rigidbody2D = rigidbody2D;
	}
}
