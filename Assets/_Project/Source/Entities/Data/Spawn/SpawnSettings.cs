using IceFebruary.Space;
using IceFebruary.Proxy;
using IceFebruary;

public readonly struct SpawnSettings
{
	public IGameObject GameObject { get; private init; }
    public Vector2 Position { get; private init; }

    [FieldProxy]
	public SpawnSettings(IGameObject gameObject, Vector2 position)
	{
		GameObject = gameObject;
		Position = position;
	}
}
