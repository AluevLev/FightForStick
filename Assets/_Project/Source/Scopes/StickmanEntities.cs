using IceFebruary.Physics;

public readonly struct StickmanEntities
{
	public IRigidbody2D Balda { get; private init; }
	public StickmanEntities(IRigidbody2D balda)
	{
		Balda = balda;
	}
}
