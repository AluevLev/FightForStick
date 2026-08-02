using IceFebruary.Time;

public sealed class ItemHolderSetterUp : ISettableUp<ItemSettings, ItemHolder>
{
    private readonly ITime _time;
    public ItemHolderSetterUp(ITime time)
    {
        _time = time;
    }
	public ItemHolder SetUp(ItemSettings config)
	{
        PhysicsBalancerConfig physicsBalancerConfig = config.PhysicsLimbConfig;
        PhysicsBalancerSettings physicsBalancerSettings = physicsBalancerConfig.Settings;

        PhysicsBalancerCalculator physicsBalancerCalculator = new(physicsBalancerSettings.Force);

        PhysicsBalancer physicsBalancer = new(
            physicsBalancerConfig.Rigidbody2D,
            physicsBalancerCalculator,
            physicsBalancerSettings.Target);

        _time.LaunchIFixedFrame(physicsBalancer);

        return new(config.Holders, physicsBalancer);
    }
}
