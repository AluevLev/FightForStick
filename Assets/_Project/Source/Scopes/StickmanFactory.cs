using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space.Vector2Provider;
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
    public StickmanFactory ReviveLimbs(RagdollSchema ragdollScema)
    {
        PhysicsLimbSettings[] limbsSettings = ragdollScema.PhysicsLimbSettings;

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
    public StickmanFactory SetGroundDetector(GroundDetectionSettings groundDetectionSettings)
    {
        _groundChecker = new AreaScanner(_physics2D,
            groundDetectionSettings.GroundCheckSettings.GroundCheckShape,
            groundDetectionSettings.GroundDetectorPosition,
            groundDetectionSettings.GroundDetectorRotation,
            groundDetectionSettings.GroundCheckSettings.ContactFilter2D);

        return this;
    }
    public StickmanFactory SetMovement(MovementSettings movementSettings)
    {
        IMovementCalculator entityMovementCalculator = new EntityMovementCalculator(movementSettings.MovementStatisticks);
        _motorHandler = new EntityMotorHandler(movementSettings.PushBody, _groundChecker, entityMovementCalculator, movementSettings.MovementFloat);

        _time.LaunchIFixedFrame(_motorHandler);

        return this;
    }
    public StickmanFactory SetHolder(PickUpSettings pickUpSettings)
    {
        IHand[] hands = new IHand[pickUpSettings.Components.Length];

        for (int index = 0; index < hands.Length; index++)
            hands[index] = new EntityHand(pickUpSettings.Components[index]);

        IItemHolder itemHolderController = new EntityItemHolder(hands);
        _itemHolderHandler = new EntityItemHolderHandler(_physics2D,
            itemHolderController,
            pickUpSettings.PlayerPosition,
            pickUpSettings.PickUpStatisticks.PickUpShape,
            pickUpSettings.PickUpStatisticks.MaxSqrPickUpDistance);

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
