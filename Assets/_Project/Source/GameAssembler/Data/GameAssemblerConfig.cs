using IceFebruary.Proxy;
using IceFebruary.Render;

public readonly struct GameAssemblerConfig
{
    public ICamera Camera { get; private init; }
    public SpawnList SpawnList { get; private init; }
    public GameAssemblerSettings Settings { get; private init; }

    [FieldProxy]
    public GameAssemblerConfig(ICamera camera, SpawnList spawnList, GameAssemblerSettings settings)
    {
        Camera = camera;
        SpawnList = spawnList;
        Settings = settings;
    }
}
