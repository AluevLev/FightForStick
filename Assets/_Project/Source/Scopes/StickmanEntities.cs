using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct StickmanEntities
{
	public IRigidbody2D Balda { get; private init; }
	[Proxy]
	public StickmanEntities(IRigidbody2D balda)
	{
		Balda = balda;
	}
}
