using IceFebruary.Proxy;
using IceFebruary.Render;

public readonly struct GameAssemblerConfig
{
    public ICamera Camera { get; private init; }
    public StickmanSpawnList StickmanSpawnList { get; private init; }
    public GameAssemblerSettings Settings { get; private init; }

    [FieldProxy]
    public GameAssemblerConfig(ICamera camera, StickmanSpawnList stickmanSpawnList, GameAssemblerSettings settings)
    {
        Camera = camera;
        StickmanSpawnList = stickmanSpawnList;
        Settings = settings;
    }
}
