using IceFebruary;
using IceFebruary.Space;

public class ItemFactory
{
    private readonly IObjectManager _objectManager;
    private readonly IGameObject _weapon;
    public ItemFactory(IGameObject weapon, IObjectManager objectManager)
    {
        _weapon = weapon;
        _objectManager = objectManager;
    }
    public void Create()
    {
        IGameObject gameObject = _objectManager.Create(_weapon, Vector2.Zero, Rotor2.Default);

        if (!gameObject.TryGetInstantiateInfo(out ItemConfig itemConfig))
            return;

        PhysicsBalancerConfig physicsBalancerConfig = itemConfig.PhysicsLimbConfig;
        PhysicsBalancerSettings settings = physicsBalancerConfig.Settings;

        PhysicsBalancerCalculator physicsBalancerCalculator = new(settings.Force);

        IPhysicsBalancer physicsBalancer = new PhysicsBalancer(
            physicsBalancerConfig.Rigidbody2D,
            physicsBalancerCalculator,
            settings.Target);

        Item item = new(itemConfig.Holders, physicsBalancer);
        gameObject.MainComponent.Value = item;
    }
}
