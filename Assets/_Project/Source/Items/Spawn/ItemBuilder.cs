using IceFebruary;
using IceFebruary.Time;

public sealed class ItemBuilder : IBuilder<ItemConfig>
{
    private readonly ITime _time;
    private readonly SetOnce<ItemConfig> _itemConfig = new();
    public ItemBuilder(ITime time)
    {
        _time = time;
    }
    public void SetConfig(ItemConfig config)
    {
        _itemConfig.Value = config;
    }
    public ItemBuilder SetUp()
    {
        ItemConfig itemConfig = _itemConfig.Value;

        PhysicsBalancerConfig physicsBalancerConfig = itemConfig.PhysicsLimbConfig;
        PhysicsBalancerSettings settings = physicsBalancerConfig.Settings;

        PhysicsBalancerCalculator physicsBalancerCalculator = new(settings.Force);

        PhysicsBalancer physicsBalancer = new(
            physicsBalancerConfig.Rigidbody2D,
            physicsBalancerCalculator,
            settings.Target);

        _time.LaunchIFixedFrame(physicsBalancer);

        Item item = new(itemConfig.Holders, physicsBalancer);

        itemConfig.GameObject.MainComponent.Value = item;

        return this;
    }
}
