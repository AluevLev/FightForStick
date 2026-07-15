using IceFebruary;
using IceFebruary.Proxy;

public readonly struct StickmanSpawnList
{
	public IGameObject StickmanPrefab { get; private init; }
	public StickmanSpawnSettings PlayerSpawnsSetting { get; private init; }
    public StickmanSpawnSettings[] EnemiesSpawnSettings { get; private init; }
	[ScriptableObjectProxy]
	public StickmanSpawnList(IGameObject stickmanPrefab, StickmanSpawnSettings playerSpawnSettings, StickmanSpawnSettings[] enemiesSpawnSettings)
	{
		StickmanPrefab = stickmanPrefab;
		PlayerSpawnsSetting = playerSpawnSettings;
		EnemiesSpawnSettings = enemiesSpawnSettings;
	}
}
