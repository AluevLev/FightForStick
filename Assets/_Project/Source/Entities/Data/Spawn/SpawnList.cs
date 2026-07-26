using IceFebruary.Proxy;

public readonly struct SpawnList
{
	public SpawnSettings PlayerSpawnsSetting { get; private init; }
    public SpawnSettings[] EnemiesSpawnSettings { get; private init; }
	public SpawnSettings[] ItemsSpawnList { get; private init; }

	[ScriptableObjectProxy]
	public SpawnList(SpawnSettings playerSpawnSettings, SpawnSettings[] enemiesSpawnSettings, SpawnSettings[] itemsSpawnList)
	{
		PlayerSpawnsSetting = playerSpawnSettings;
		EnemiesSpawnSettings = enemiesSpawnSettings;
		ItemsSpawnList = itemsSpawnList;
	}
}
