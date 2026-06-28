using IceFebruary.Physics;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public class StickmanBuilder
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;

    private StickmanConfig _stickmanConfig;
    private EntityMotorHandler _motorHandler;
    private EntityItemHolderHandler _itemHolderHandler;

    public StickmanBuilder(ITime time, IPhysics2D physics2D, StickmanConfig stickmanConfig)
    {
        _time = time;
        _physics2D = physics2D;
        _stickmanConfig = stickmanConfig;
    }
    public StickmanBuilder SetUp()
    {
        PhysicsLimbSettings[] limbsSettings = _stickmanConfig.RagdollSchema.PhysicsLimbSettings;

        for (int limb = 0; limb < limbsSettings.Length; limb++)
        {
            PhysicsLimbSettings physicsBalancer = limbsSettings[limb];
            PhysicsBalancerSettings physicsBalancerSettings = physicsBalancer.BalancerSettings;

            IRigidbody2D physicsBody = physicsBalancer.Rigidbody2D;
            IPhysicsBalancerCalculator physicsBalancerCalculator = new PhysicsBalancerCalculator(physicsBalancerSettings.Force);
            IFixedFrame balancer = new PhysicsBalancer(physicsBody, physicsBalancerCalculator, physicsBalancerSettings.Target);

            _time.LaunchIFixedFrame(balancer);
        }

        IOverlapper _groundChecker = new AreaScanner(_physics2D,
            _stickmanConfig.GroundDetectionSettings.GroundCheckSettings.GroundCheckShape,
            _stickmanConfig.GroundDetectionSettings.GroundDetectorPosition,
            _stickmanConfig.GroundDetectionSettings.GroundDetectorRotation,
            _stickmanConfig.GroundDetectionSettings.GroundCheckSettings.ContactFilter2D);

        IMovementCalculator entityMovementCalculator = new EntityMovementCalculator(_stickmanConfig.MovementSettings.MovementStatisticks);
        _motorHandler = new EntityMotorHandler(_stickmanConfig.MovementSettings.PushBody, _groundChecker, entityMovementCalculator, _stickmanConfig.MovementSettings.MovementFloat);

        _time.LaunchIFixedFrame(_motorHandler);

        IHand[] hands = new IHand[_stickmanConfig.PickUpSettings.Components.Length];

        for (int index = 0; index < hands.Length; index++)
            hands[index] = new EntityHand(_stickmanConfig.PickUpSettings.Components[index]);

        IItemHolder itemHolderController = new EntityItemHolder(hands);
        _itemHolderHandler = new EntityItemHolderHandler(_physics2D,
            itemHolderController,
            _stickmanConfig.PickUpSettings.PlayerPosition,
            _stickmanConfig.PickUpSettings.PickUpStatisticks.PickUpShape,
            _stickmanConfig.PickUpSettings.PickUpStatisticks.MaxSqrPickUpDistance);

        return this;
    }
    public void SetItemHolderControl(IInputProvider inputProvider, IVector2Provider cursor)
    {
        IFrame movementController = new PlayerMovementController(inputProvider, _motorHandler);
        IFrame itemHolderController = new PlayerItemHolderController(inputProvider, cursor, _itemHolderHandler);

        _time.LaunchIFrame(movementController);
        _time.LaunchIFrame(itemHolderController);
    }
}
