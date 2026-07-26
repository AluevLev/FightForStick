using IceFebruary.Proxy;
using IceFebruary.Render;

public readonly struct GameAssemblerConfig
{
    public ICamera Camera { get; private init; }
    public SpawnList StickmanSpawnList { get; private init; }
    public GameAssemblerSettings Settings { get; private init; }

    [FieldProxy]
    public GameAssemblerConfig(ICamera camera, SpawnList stickmanSpawnList, GameAssemblerSettings settings)
    {
        Camera = camera;
        StickmanSpawnList = stickmanSpawnList;
        Settings = settings;
    }
}
