using IceFebruary;
using IceFebruary.Proxy;

public readonly struct StickmanSpawnList
{
	public IGameObject PlayerStickmanPrefab { get; private init; }
	public StickmanSpawnSettings PlayerSpawnsSetting { get; private init; }
    public IGameObject EnemyStickmanPrefab { get; private init; }
    public StickmanSpawnSettings[] EnemiesSpawnSettings { get; private init; }

	[ScriptableObjectProxy]
	public StickmanSpawnList(IGameObject playerStickmanPrefab, StickmanSpawnSettings playerSpawnSettings,
		IGameObject enemyStickmanPrefab, StickmanSpawnSettings[] enemiesSpawnSettings)
	{
		PlayerStickmanPrefab = playerStickmanPrefab;
		PlayerSpawnsSetting = playerSpawnSettings;
		EnemyStickmanPrefab = enemyStickmanPrefab;
		EnemiesSpawnSettings = enemiesSpawnSettings;
	}
}
