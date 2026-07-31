using IceFebruary.Time;

public sealed class ItemBuilder : ISetUpper<ItemConfig>
{
    private readonly ITime _time;
    public ItemBuilder(ITime time)
    {
        _time = time;
    }
    public void SetUp(ItemConfig config)
    {
        PhysicsBalancerConfig physicsBalancerConfig = config.PhysicsLimbConfig;
        PhysicsBalancerSettings settings = physicsBalancerConfig.Settings;

        PhysicsBalancerCalculator physicsBalancerCalculator = new(settings.Force);

        PhysicsBalancer physicsBalancer = new(
            physicsBalancerConfig.Rigidbody2D,
            physicsBalancerCalculator,
            settings.Target);

        _time.LaunchIFixedFrame(physicsBalancer);

        Item item = new(new(config.Holders, physicsBalancer));

        config.GameObject.MainComponent.Value = item;
    }
}
