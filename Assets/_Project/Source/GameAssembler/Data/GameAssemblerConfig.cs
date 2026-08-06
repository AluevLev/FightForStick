using IceFebruary.Proxy;

public readonly struct GameAssemblerConfig
{
    public SpawnList SpawnList { get; private init; }
    public GameAssemblerSettings Settings { get; private init; }

    [FieldProxy]
    public GameAssemblerConfig(SpawnList spawnList, GameAssemblerSettings settings)
    {
        SpawnList = spawnList;
        Settings = settings;
    }
}
