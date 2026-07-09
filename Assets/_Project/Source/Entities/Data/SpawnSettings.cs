using IceFebruary.Space;
using IceFebruary.Proxy;

public readonly struct SpawnSettings
{
	public Vector2 Position { get; private init; }
	[FieldProxy]
	public SpawnSettings(Vector2 position)
	{
		Position = position;
	}
}
