using IceFebruary.Proxy;

public readonly struct SpawnList
{
    public SpawnSettings LevelSpawnSettings { get; private init; }
    public SpawnSettings CameraSpawnSettings { get; private init; }
    public SpawnSettings PlayerSpawnsSetting { get; private init; }
    public SpawnSettings[] EnemiesSpawnList { get; private init; }
    public SpawnSettings[] ItemsSpawnList { get; private init; }

    [DataObjectProxy]
    public SpawnList(SpawnSettings levelSpawnSettings, SpawnSettings cameraSpawnSettings, SpawnSettings playerSpawnSettings, SpawnSettings[] enemiesSpawnList, SpawnSettings[] itemsSpawnList)
    {
        LevelSpawnSettings = levelSpawnSettings;
        CameraSpawnSettings = cameraSpawnSettings;
        PlayerSpawnsSetting = playerSpawnSettings;
        EnemiesSpawnList = enemiesSpawnList;
        ItemsSpawnList = itemsSpawnList;
    }
}
