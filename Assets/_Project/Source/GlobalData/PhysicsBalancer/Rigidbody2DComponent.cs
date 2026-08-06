using IceFebruary;
using IceFebruary.Proxy;
using IceFebruary.Physics;

public readonly struct Rigidbody2DComponent
{
	public IGameObject GameObject { get; private init; }
	public IRigidbody2D Rigidbody2D { get; private init; }

	[FieldProxy]
	public Rigidbody2DComponent(IGameObject gameObject, IRigidbody2D rigidbody2D)
	{
		GameObject = gameObject;
		Rigidbody2D = rigidbody2D;
	}
}
