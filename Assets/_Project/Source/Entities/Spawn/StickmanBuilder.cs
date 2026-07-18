using IceFebruary.Physics;
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
            IFixedFrame balancer = new PhysicsBalancer(
                physicsBody,
                physicsBalancerCalculator,
                physicsBalancerSettings.Target);

            _time.LaunchIFixedFrame(balancer);
        }

        IOverlapper groundChecker = new AreaScanner(
            _physics2D,
            _stickmanConfig.GroundDetectionSettings.GroundCheckSettings.GroundCheckShape,
            _stickmanConfig.GroundDetectionSettings.GroundDetectorPosition,
            _stickmanConfig.GroundDetectionSettings.GroundDetectorRotation,
            1,
            _stickmanConfig.GroundDetectionSettings.GroundCheckSettings.ContactFilter2D);

        IEntityMotor entityMotor = new EntityMotor(
            _stickmanConfig.MovementSettings.PushBody,
            _stickmanConfig.MovementSettings.LeftHip,
            _stickmanConfig.MovementSettings.RightHip,
            _stickmanConfig.MovementSettings.Shins,
            _stickmanConfig.MovementSettings.MovementStatisticks.LegRest,
            _stickmanConfig.MovementSettings.MovementStatisticks.LegAmplitude);

        IMovementCalculator entityMovementCalculator = new EntityMovementCalculator(_stickmanConfig.MovementSettings.MovementStatisticks);

        _motorHandler = new EntityMotorHandler(
            entityMotor,
            groundChecker,
            entityMovementCalculator,
            _stickmanConfig.MovementSettings.MovementStatisticks.LegsChangeRotationPeriod);

        _time.LaunchIFixedFrame(_motorHandler);

        IHand[] hands = new IHand[_stickmanConfig.PickUpSettings.Components.Length];

        for (int index = 0; index < hands.Length; index++)
            hands[index] = new EntityHand(_stickmanConfig.PickUpSettings.Components[index]);

        IItemHolder itemHolderController = new EntityItemHolder(hands);
        IOverlapper pickUpChecker = new AreaScanner(
            _physics2D,
            _stickmanConfig.PickUpSettings.PickUpStatisticks.PickUpShape,
            _stickmanConfig.PickUpSettings.StickmanPosition,
            null,
            _stickmanConfig.PickUpSettings.PickUpStatisticks.MaxBufferForCheck);

        _itemHolderHandler = new EntityItemHolderHandler(
            pickUpChecker,
            itemHolderController,
            _stickmanConfig.PickUpSettings.StickmanPosition,
            _stickmanConfig.PickUpSettings.PickUpStatisticks.MaxSqrPickUpDistance);

        return this;
    }
    public void SetInput(IInputProvider inputProvider)
    {
        IFrame movementController = new EntityMovementController(inputProvider, _motorHandler);
        IFrame itemHolderController = new EntityItemHolderController(inputProvider, _itemHolderHandler);

        _time.LaunchIFrame(movementController);
        _time.LaunchIFrame(itemHolderController);
    }
}
