using IceFebruary.Physics;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public class StickmanBuilder
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;

    private readonly StickmanConfig _stickmanConfig;
    
    private EntityMotorHandler _motorHandler;
    private EntityItemHolderHandler _itemHolderHandler;

    private IPhysicsBalancer _headBalancer;
    private IPhysicsBalancer _bodyBalancer;

    private IPhysicsBalancer _hip1Balancer;
    private IPhysicsBalancer _shin1Balancer;
    private IPhysicsBalancer _foot1Balancer;

    private IPhysicsBalancer _hip2Balancer;
    private IPhysicsBalancer _shin2Balancer;
    private IPhysicsBalancer _foot2Balancer;

    public IVector2Provider StickmanPosition { get; private init; }
    public StickmanBuilder(ITime time, IPhysics2D physics2D, StickmanConfig stickmanConfig)
    {
        _time = time;
        _physics2D = physics2D;

        _stickmanConfig = stickmanConfig;

        StickmanPosition = stickmanConfig.StickmanPosition;
    }
    public StickmanBuilder SetUp()
    {
        SetLimbs();

        SetMovement();

        SetItemHolder(null); //TODO: FINISH HIM!!

        return this;
    }
    private StickmanBuilder SetLimbs()
    {
        RagdollConfig ragdollConfig = _stickmanConfig.RagdollConfig;

        _headBalancer = SetLimb(ragdollConfig.Head);
        _bodyBalancer = SetLimb(ragdollConfig.Body);

        _hip1Balancer = SetLimb(ragdollConfig.Hip1);
        _shin1Balancer = SetLimb(ragdollConfig.Shin1);
        _foot1Balancer = SetLimb(ragdollConfig.Foot1);

        _hip2Balancer = SetLimb(ragdollConfig.Hip2);
        _shin2Balancer = SetLimb(ragdollConfig.Shin2);
        _foot2Balancer = SetLimb(ragdollConfig.Foot2);

        return this;
    }
    private IPhysicsBalancer SetLimb(PhysicsLimbConfig physicsLimbSettings)
    {
        PhysicsBalancerSettings physicsBalancerSettings = physicsLimbSettings.Settings;

        PhysicsBalancerCalculator physicsBalancerCalculator = new(physicsBalancerSettings.Force);

        PhysicsBalancer physicsBalancer = new(
            physicsLimbSettings.Rigidbody2D,
            physicsBalancerCalculator,
            physicsBalancerSettings.Target);

        _time.LaunchIFixedFrame(physicsBalancer);

        return physicsBalancer;
    }
    private StickmanBuilder SetMovement()
    {
        MovementConfig movementConfig = _stickmanConfig.MovementConfig;
        MovementSettings movementSettings = movementConfig.Settings;

        AreaScannerConfig groundAreaScannerConfig = movementConfig.GroundAreaScannerConfig;
        AreaScannerSettings groundAreaScannerSettings = groundAreaScannerConfig.Settings;

        IOverlapper groundChecker = new AreaScanner(
            _physics2D,
            groundAreaScannerSettings.Shape,
            groundAreaScannerConfig.Position,
            groundAreaScannerConfig.Rotation,
            groundAreaScannerSettings.CollidersMaxCount,
            groundAreaScannerSettings.ContactFilter2D);

        IEntityMotor entityMotor = new EntityMotor(
            movementConfig.PushBody,
            movementConfig.Hip1,
            movementConfig.Hip2,
            movementConfig.Shins,
            movementSettings.LegRest,
            movementSettings.LegAmplitude);

        IMovementCalculator entityMovementCalculator = new EntityMovementCalculator(
            movementSettings.Speed,
            movementSettings.JumpBoost,
            movementSettings.JumpForce);

        _motorHandler = new EntityMotorHandler(
            _time,
            entityMotor,
            groundChecker,
            entityMovementCalculator,
            movementSettings.LegsChangeRotationPeriod);

        _time.LaunchIFixedFrame(_motorHandler);

        return this;
    }
    public StickmanBuilder SetItemHolder(IVector2Provider cursor)
    {
        PickUpConfig pickUpConfig = _stickmanConfig.PickUpConfig;
        PickUpSettings pickUpSettings = pickUpConfig.Settings;

        AreaScannerSettings itemAreaScannerSettings = pickUpConfig.ItemAreaScannerSettings;

        IHand[] hands = new IHand[pickUpConfig.EntityHands.Length];

        for (int index = 0; index < hands.Length; index++)
            hands[index] = new EntityHand(pickUpConfig.EntityHands[index]);

        IItemHolder itemHolderController = new EntityItemHolder(hands);

        IOverlapper pickUpChecker = new AreaScanner(
            _physics2D,
            itemAreaScannerSettings.Shape,
            cursor,
            null,
            itemAreaScannerSettings.CollidersMaxCount,
            itemAreaScannerSettings.ContactFilter2D);

        _itemHolderHandler = new EntityItemHolderHandler(
            pickUpChecker,
            itemHolderController,
            StickmanPosition,
            pickUpSettings.MaxSqrPickUpDistance);

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
