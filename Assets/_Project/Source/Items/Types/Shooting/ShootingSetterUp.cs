using IceFebruary;
using IceFebruary.Time;
using IceFebruary.Factories;

public sealed class ShootingSetterUp : ISettableUp<ShootingConfig>
{
    private readonly ITime _time;
    private readonly IObjectManager _objectManager;
    private readonly ISettableUp<ItemSettings, ItemHolder> _holderSettableUp;
    public ShootingSetterUp(ITime time, IObjectManager objectManager, ISettableUp<ItemSettings, ItemHolder> holderSettableUp)
    {
        _time = time;
        _objectManager = objectManager;
        _holderSettableUp = holderSettableUp;
    }
    public void SetUp(ShootingConfig config)
    {
        ItemSettings itemSettings = config.ItemSettings;
        ItemHolder itemHolder = _holderSettableUp.SetUp(itemSettings);

        ShootingSettings settings = config.Settings;
        ProjectileSettings projectileSettings = settings.ProjectileSettings;

        ShootingCalculator shootingDirectionCalculator = new(settings.ShootingForce, settings.RecoilForce);
        Factory<BulletFactory, BulletConfig> bulletFactory = new(_objectManager, new(_objectManager));

        Timer cooldown = new(
            _time,
            settings.Cooldown);

        Timer reloadCooldown = new(
            _time,
            settings.ReloadCooldown);

        ObjectPool objectPool = new(
            _time,
            bulletFactory,
            settings.BulletsCount,
            projectileSettings.Prefab,
            projectileSettings.ObjectLifetime);

        Shooting shooting = new(
            itemHolder,
            config.Rigidbody2D,
            shootingDirectionCalculator,
            config.ShootDirection,
            config.ShootPoint,
            objectPool,
            cooldown,
            reloadCooldown,
            settings.BulletsCount);

        itemSettings.GameObject.MainComponent.Value = shooting;
    }
}
