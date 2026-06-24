using IceFebruary;
using IceFebruary.Animation;
using IceFebruary.Physics;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Time;

public sealed class StickmanFactory
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;

    private AreaScanner _groundChecker;
    private EntityMotorHandler _motorHandler;
    private EntityItemHolderHandler _itemHolderHandler;
    public StickmanFactory(ITime time, IPhysics2D physics2D, IObjectManager objectManager)
    {
        _time = time;
        _physics2D = physics2D;
        _objectManager = objectManager;
    }
    public void End()
    {
        _groundChecker = null;
        _motorHandler = null;
        _itemHolderHandler = null;
    }
    public StickmanFactory Create(IGameObject stickman)
    {
        _objectManager.Create(stickman);

        return this;
    }
    public StickmanFactory ReviveLimbs(RagdollSchema settings)
    {
        PhysicsLimbSettings[] limbsSettings = settings.ToArray();

        for (int limb = 0; limb < limbsSettings.Length; limb++)
        {
            PhysicsLimbSettings physicsBalancer = limbsSettings[limb];
            PhysicsBalancerSettings physicsBalancerSettings = physicsBalancer.BalancerSettings;

            IRigidbody2D physicsBody = physicsBalancer.Rigidbody2D;
            IPhysicsBalancerCalculator physicsBalancerCalculator = new PhysicsBalancerCalculator(physicsBalancerSettings.Force);
            IFixedFrame balancer = new PhysicsBalancer(physicsBody, physicsBalancerCalculator, physicsBalancerSettings.Target);

            _time.LaunchIFixedFrame(balancer);
        }

        return this;
    }
    public StickmanFactory SetGroundDetector(IVector2Provider overlapperPosition, IRotor2Provider overlapperRotation, GroundCheckSettings groundCheckSettings)
    {
        _groundChecker = new AreaScanner(_physics2D, groundCheckSettings.GroundCheckShape, overlapperPosition, overlapperRotation, groundCheckSettings.ContactFilter2D);

        return this;
    }
    public StickmanFactory SetMovement(IRigidbody2D pushBody, MovementSettings movementSettings, AnimatorFloatField movementFloat)
    {
        IMovementCalculator entityMovementCalculator = new EntityMovementCalculator(movementSettings);
        _motorHandler = new EntityMotorHandler(pushBody, _groundChecker, entityMovementCalculator, movementFloat);

        _time.LaunchIFixedFrame(_motorHandler);

        return this;
    }
    public StickmanFactory SetHolder(Component<IRigidbody2D>[] components, IVector2Provider position, PickUpSettings pickUpSettings)
    {
        IHand[] hands = new IHand[components.Length];

        for (int index = 0; index < components.Length; index++)
            hands[index] = new EntityHand(components[index]);

        IItemHolder itemHolderController = new EntityItemHolder(hands);
        _itemHolderHandler = new EntityItemHolderHandler(_physics2D, itemHolderController, position, pickUpSettings.PickUpShape, pickUpSettings.MaxSqrPickUpDistance);

        return this;
    }
    public StickmanFactory SetMovementControl(IInputProvider inputProvider)
    {
        IFrame movementController = new PlayerMovementController(inputProvider, _motorHandler);

        _time.LaunchIFrame(movementController);

        return this;
    }
    public StickmanFactory SetItemHolderControl(IInputProvider inputProvider, IVector2Provider cursor)
    {
        IFrame itemHolderController = new PlayerItemHolderController(inputProvider, cursor, _itemHolderHandler);

        _time.LaunchIFrame(itemHolderController);

        return this;
    }
}
