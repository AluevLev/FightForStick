using IceFebruary.Space;
using IceFebruary.Proxy;

public readonly struct StickmanSpawnSettings
{
    public Vector2 Position { get; private init; }
    [FieldProxy]
	public StickmanSpawnSettings(Vector2 position)
	{
		Position = position;
	}
}
