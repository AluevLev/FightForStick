using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Physics.Balancer;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;
using IceFebruary.Factories;

public sealed class StickmanBuilder : ISettableUp<StickmanConfig>
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;

    private StickmanConfig _stickmanConfig;
    public IVector2Provider StickmanPosition { get; private set; }
    
    public EntityMotorHandler MotorHandler { get; private set; }
    public EntityItemHolderHandler ItemHolderHandler { get; private set; }

    private IPhysicsBalancer _hip1Balancer;
    private IPhysicsBalancer _shin1Balancer;

    private IPhysicsBalancer _hip2Balancer;
    private IPhysicsBalancer _shin2Balancer;

    public StickmanBuilder(ITime time, IPhysics2D physics2D)
    {
        _time = time;
        _physics2D = physics2D;
    }
    public void SetUp(StickmanConfig config)
    {
        _stickmanConfig = config;
        StickmanPosition = config.StickmanPosition;
    }
    public StickmanBuilder SetLimbs()
    {
        RagdollConfig ragdollConfig = _stickmanConfig.RagdollConfig;

        SetLimb(ragdollConfig.Head);
        SetLimb(ragdollConfig.Body);
        SetLimb(ragdollConfig.Foot1);
        SetLimb(ragdollConfig.Foot2);

        _hip1Balancer = SetLimb(ragdollConfig.Hip1);
        _hip2Balancer = SetLimb(ragdollConfig.Hip2);
        _shin1Balancer = SetLimb(ragdollConfig.Shin1);
        _shin2Balancer = SetLimb(ragdollConfig.Shin2);

        return this;
    }
    private IPhysicsBalancer SetLimb(PhysicsBalancerConfig physicsLimbSettings)
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
    public StickmanBuilder SetMovement()
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
            groundAreaScannerSettings.ContactFilter2D,
            groundAreaScannerSettings.CollidersMaxCount);

        IPhysicsBalancer[] shins = new IPhysicsBalancer[] { _shin1Balancer, _shin2Balancer };

        IEntityMotor entityMotor = new EntityMotor(
            movementConfig.PushBody,
            _hip1Balancer,
            _hip2Balancer,
            shins,
            movementSettings.LegRest,
            movementSettings.LegAmplitude);

        IMovementCalculator entityMovementCalculator = new EntityMovementCalculator(
            movementSettings.Speed,
            movementSettings.JumpSpeed,
            movementSettings.JumpBoost,
            movementSettings.SneakBoost);

        Trigger trigger = new();

        _time.LaunchIFixedFrame(trigger);

        Timer hipsTimer = new(
            _time,
            movementSettings.LegsChangeRotationPeriod);

        MotorHandler = new EntityMotorHandler(
            entityMotor,
            groundChecker,
            entityMovementCalculator,
            hipsTimer,
            trigger);

        _time.LaunchIFixedFrame(MotorHandler);

        return this;
    }
    public StickmanBuilder SetItemHolder(IVector2Provider cursorPosition, IRotor2Provider rotation = null)
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
            cursorPosition,
            rotation,
            itemAreaScannerSettings.ContactFilter2D,
            itemAreaScannerSettings.CollidersMaxCount);

        IRotor2Provider targetItemRotation = new DirectionRotor2Provider(StickmanPosition, cursorPosition);

        ItemHolderHandler = new EntityItemHolderHandler(
            pickUpChecker,
            itemHolderController,
            StickmanPosition,
            cursorPosition,
            targetItemRotation,
            pickUpSettings.MaxSqrPickUpDistance,
            pickUpSettings.EntityLayer);

        return this;
    }
    public StickmanBuilder SetInput(IInputProvider inputProvider)
    {
        IFrame movementController = new EntityMovementController(inputProvider, MotorHandler);
        IFrame itemHolderController = new EntityItemHolderController(inputProvider, ItemHolderHandler);

        _time.LaunchIFrame(movementController);
        _time.LaunchIFrame(itemHolderController);

        return this;
    }
}
