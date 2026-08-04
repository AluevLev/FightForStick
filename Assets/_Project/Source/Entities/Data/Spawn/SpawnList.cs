using IceFebruary.Proxy;

public readonly struct SpawnList
{
	public SpawnSettings PlayerSpawnsSetting { get; private init; }
    public SpawnSettings[] EnemiesSpawnSettings { get; private init; }
	public SpawnSettings[] ItemsSpawnList { get; private init; }
	public SpawnSettings[] ShootingsSpawnList { get; private init; }
    public SpawnSettings[] SawsSpawnList { get; private init; }

    [ScriptableObjectProxy]
	public SpawnList(SpawnSettings playerSpawnSettings, SpawnSettings[] enemiesSpawnSettings, SpawnSettings[] itemsSpawnList, SpawnSettings[] shootingsSpawnList, SpawnSettings[] sawsSpawnList)
	{
		PlayerSpawnsSetting = playerSpawnSettings;
		EnemiesSpawnSettings = enemiesSpawnSettings;
		ItemsSpawnList = itemsSpawnList;
		ShootingsSpawnList = shootingsSpawnList;
		SawsSpawnList = sawsSpawnList;
	}
}
