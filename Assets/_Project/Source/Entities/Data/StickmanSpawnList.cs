using IceFebruary;
using IceFebruary.Proxy;

public readonly struct StickmanSpawnList
{
	public IGameObject StickmanPrefab { get; private init; }
	public SpawnSettings[] SpawnsSettings { get; private init; }
	[ScriptableObjectProxy]
	public StickmanSpawnList(IGameObject stickmanPrefab, SpawnSettings[] spawnsSettings)
	{
		StickmanPrefab = stickmanPrefab;
		SpawnsSettings = spawnsSettings;
	}
}
