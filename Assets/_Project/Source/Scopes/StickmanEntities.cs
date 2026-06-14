using IceFebruary.Proxy;

public readonly struct StickmanEntities
{
	public RagdollSchema Balda { get; private init; }
	[Proxy]
	public StickmanEntities(RagdollSchema balda)
	{
		Balda = balda;
	}
}
