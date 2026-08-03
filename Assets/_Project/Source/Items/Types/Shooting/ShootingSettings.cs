using IceFebruary.Proxy;

public readonly struct ShootingSettings
{
    public ProjectileSettings ProjectileSettings { get; private init; }
    public int BulletsCount { get; private init; }
    public float ShootingForce { get; private init; }
    public float Cooldown { get; private init; }

    [ScriptableObjectProxy]
    public ShootingSettings(ProjectileSettings projectileSettings, int bulletsCount, float shootingForce, float cooldown)
    {
        ProjectileSettings = projectileSettings;
        BulletsCount = bulletsCount;
        ShootingForce = shootingForce;
        Cooldown = cooldown;
    }
}
