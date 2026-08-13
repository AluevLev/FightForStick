using IceFebruary;
using IceFebruary.Proxy;

public readonly struct ProjectileSettings
{
    public IGameObject Prefab { get; private init; }
    public float ObjectLifetime { get; private init; }

    [DataObjectProxy]
    public ProjectileSettings(IGameObject prefab, float objectLifeTime)
    {
        Prefab = prefab;
        ObjectLifetime = objectLifeTime;
    }
}
