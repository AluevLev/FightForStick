using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class StickmanBuilder : IBuilder<StickmanConfig>
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;

    private StickmanConfig StickmanConfig => _stickmanConfig.Value;
    private readonly SetOnce<StickmanConfig> _stickmanConfig = new();

    public IVector2Provider StickmanPosition => _stickmanPosition.Value;
    private readonly SetOnce<IVector2Provider> _stickmanPosition = new();
    
    private EntityMotorHandler _motorHandler;
    private EntityItemHolderHandler _itemHolderHandler;

    private IPhysicsBalancer _hip1Balancer;
    private IPhysicsBalancer _shin1Balancer;

    private IPhysicsBalancer _hip2Balancer;
    private IPhysicsBalancer _shin2Balancer;

    

    public StickmanBuilder(ITime time, IPhysics2D physics2D)
    {
        _time = time;
        _physics2D = physics2D;
    }
    public void SetConfig(StickmanConfig config)
    {
        _stickmanConfig.Value = config;
        _stickmanPosition.Value = config.StickmanPosition;
    }
    public StickmanBuilder SetLimbs()
    {
        RagdollConfig ragdollConfig = StickmanConfig.RagdollConfig;

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
        MovementConfig movementConfig = StickmanConfig.MovementConfig;
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

        _motorHandler = new EntityMotorHandler(
            _time,
            entityMotor,
            groundChecker,
            entityMovementCalculator,
            trigger,
            movementSettings.LegsChangeRotationPeriod);

        _time.LaunchIFixedFrame(_motorHandler);

        return this;
    }
    public StickmanBuilder SetItemHolder(IVector2Provider cursorPosition, IRotor2Provider rotation = null)
    {
        PickUpConfig pickUpConfig = StickmanConfig.PickUpConfig;
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

        _itemHolderHandler = new EntityItemHolderHandler(
            pickUpChecker,
            itemHolderController,
            StickmanPosition,
            cursorPosition,
            targetItemRotation,
            pickUpSettings.MaxSqrPickUpDistance);

        return this;
    }
    public StickmanBuilder SetInput(IInputProvider inputProvider)
    {
        IFrame movementController = new EntityMovementController(inputProvider, _motorHandler);
        IFrame itemHolderController = new EntityItemHolderController(inputProvider, _itemHolderHandler);

        _time.LaunchIFrame(movementController);
        _time.LaunchIFrame(itemHolderController);

        return this;
    }
}
