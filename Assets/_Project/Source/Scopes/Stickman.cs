using IceFebruary;
using IceFebruary.Animation;
using IceFebruary.Physics;
using IceFebruary.Shapes;
using IceFebruary.Space;
using IceFebruary.Space.PointProvider;
using IceFebruary.Time;

public sealed class Stickman //TODO: fixx this bruh
{/*
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;
    private readonly IPointProvider _cursorPointProvider;
    private readonly IInputProvider _inputProvider;

    private readonly RagdollScema _ragdollSchema;
    private readonly GroundCheckSettings _groundCheckSettings;
    private readonly MovementSettings _movementSettings;
    private readonly PickUpSettings _pickUpSettings;
    private readonly AnimatorVariable<float> _movementField;

    private readonly IDestroyable<ITransform> _groundCheck;
    private readonly IDestroyable<IRigidbody2D> _pushBody;
    private readonly IDestroyable<IRigidbody2D>[] _handsPhysics;

    public Stickman(IPhysics2D physics2D, IPointProvider cursorPointProvider, IInputProvider inputProvider, ITime time,
        RagdollScema ragdollSchema, GroundCheckSettings groundCheckSettings, MovementSettings movementSettings,
        PickUpSettings pickUpSettings, AnimatorVariable<float> movementField,
        IDestroyable<ITransform> groundCheck, IDestroyable<IRigidbody2D> pushBody,
        IDestroyable<IRigidbody2D>[] handsPhysics)
    {
        _time = time;
        _physics2D = physics2D;
        _cursorPointProvider = cursorPointProvider;
        _inputProvider = inputProvider;
        
        _groundCheckSettings = groundCheckSettings;
        _movementSettings = movementSettings;
        _pickUpSettings = pickUpSettings;
        _movementField = movementField;

        _groundCheck = groundCheck;
        _pushBody = pushBody;
        _handsPhysics = handsPhysics;
        _ragdollSchema = ragdollSchema;

        _ragdollCore = new(new RagdollCore(_ragdollSchema.ToArray()));

        TransformPointProvider groundCheckPointProvider = new(_groundCheck);

        _areaCaster = new AreaScanner(
            _physics2D,
            _groundCheckSettings.GroundCheckShape,
            groundCheckPointProvider,
            new SpacePointProvider(
                new Vector2PointProvider(Vector2.Up),
                _groundCheck),
            _groundCheckSettings.ContactFilter2D);

        _movementCalculator = new EntityMovementCalculator(_movementSettings);
        //_motorHandler = new EntityMotorHandler(_pushBody, _areaCaster, _movementCalculator); I will delete this

        IHand[] hands = new IHand[_handsPhysics.Length];

        for (int handIndex = 0; handIndex < hands.Length; handIndex++)
            hands[handIndex] = new EntityHand(_handsPhysics[handIndex]);

        _itemHolder = new EntityItemHolder(hands);
        _itemHolderHandler = new EntityItemHolderHandler(
            _physics2D, 
            _itemHolder,
            _cursorPointProvider,
            groundCheckPointProvider,
            Dot.Instance,
            _pickUpSettings.MaxPickUpDistance);

        _animation = new(new EntityBoneAnimation(_motorHandler, _movementField));
        _playerController = new(new PlayerMovementController(_inputProvider, _motorHandler));
        _itemHolderController = new(new PlayerItemHolderController(_inputProvider, _itemHolderHandler));

        _time.LaunchIFixedFrame(_ragdollCore);
        _time.LaunchIFixedFrame(_animation);
        _time.LaunchIFrame(_playerController);
        _time.LaunchIFrame(_itemHolderController);
    }
    private readonly Entity<RagdollCore> _ragdollCore;
    private readonly AreaScanner _areaCaster;
    private readonly EntityMovementCalculator _movementCalculator;
    private readonly EntityMotorHandler _motorHandler;
    private readonly EntityItemHolder _itemHolder;
    private readonly EntityItemHolderHandler _itemHolderHandler;
    private readonly Entity<EntityBoneAnimation> _animation;
    private readonly Entity<PlayerMovementController> _playerController;
    private readonly Entity<PlayerItemHolderController> _itemHolderController;*/
}
