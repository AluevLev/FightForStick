using IceFebruary.Proxy;

public readonly struct SpawnList
{
    public SpawnSettings CameraSpawnSettings { get; private init; }
    public SpawnSettings PlayerSpawnsSetting { get; private init; }
    public SpawnSettings[] EnemiesSpawnSettings { get; private init; }
	public SpawnSettings[] ItemsSpawnList { get; private init; }

    [ScriptableObjectProxy]
	public SpawnList(SpawnSettings cameraSpawnSettings, SpawnSettings playerSpawnSettings, SpawnSettings[] enemiesSpawnSettings, SpawnSettings[] itemsSpawnList)
	{
		CameraSpawnSettings = cameraSpawnSettings;
		PlayerSpawnsSetting = playerSpawnSettings;
		EnemiesSpawnSettings = enemiesSpawnSettings;
		ItemsSpawnList = itemsSpawnList;
	}
}
