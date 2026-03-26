using IceFebruary;
using IceFebruary.Animation;
using IceFebruary.Physics;
using IceFebruary.Render;

public class Stickman
{
    private readonly GroundCheckSettings _groundCheckSettings;
    private readonly MovementSettings _movementSettings;
    private readonly PickUpSettings _pickUpSettings;
    private readonly GrimaceLibrary _grimaceLibrary;
    private readonly AnimatorTrigger _pulseFieldName;

    private readonly ITransform _groundCheck;
    private readonly IAnimator _face;
    private readonly IAnimator _physicsAnimator;
    private readonly IRigidbody2D _pushBody;
    private readonly IRigidbody2D[] _hands;
    private readonly ISpriteRenderer _eye1;
    private readonly ISpriteRenderer _eye2;
    private readonly ISpriteRenderer _mouth;

    private readonly RagdollScema _ragdollScema;

    public Stickman(GroundCheckSettings groundCheckSettings, MovementSettings movementSettings, PickUpSettings pickUpSettings, GrimaceLibrary grimaceLibrary, AnimatorTrigger pulseFieldName, ITransform groundCheck, IAnimator face, IAnimator physicsAnimator, IRigidbody2D pushBody, IRigidbody2D[] hands, ISpriteRenderer eye1, ISpriteRenderer eye2, ISpriteRenderer mouth, RagdollScema ragdollScema)
    {
        _groundCheckSettings = groundCheckSettings;
        _movementSettings = movementSettings;
        _pickUpSettings = pickUpSettings;
        _grimaceLibrary = grimaceLibrary;
        _pulseFieldName = pulseFieldName;

        _groundCheck = groundCheck;
        _face = face;
        _physicsAnimator = physicsAnimator;
        _pushBody = pushBody;
        _hands = hands;
        _eye1 = eye1;
        _eye2 = eye2;
        _mouth = mouth;

        _ragdollScema = ragdollScema;



        _ragdollCore = new RagdollCore(_ragdollScema.ToArray());
        //TODO: well...
    }
    private readonly IRagdollCore _ragdollCore;
    /*
    private void Initialize()
    {
        RegisterPhysics(builder);

        RegisterMovement(builder);

        RegisterItemHolder(builder);

        RegisterAnimation(builder);

        RegisterControllers(builder);
    }
    private void RegisterMovement(IContainerBuilder builder)
    {
        
        builder.Register<IAreaCaster>(container =>
        {
            GroundCheckSettings groundCheckSettings = container.Resolve<GroundCheckSettings>();

            IPointProvider position = new TransformPointProvider(new StandartTransform(_groundCheck));
            IPointProvider angleDirection = new SpacePointProvider(new Vector2PointProvider(UniversalVector2.Up), new StandartTransform(_groundCheck));

            return new BoxCaster(position, groundCheckSettings.GroundCheckSize, angleDirection, groundCheckSettings.ContactFilter2D);

        }, Lifetime.Scoped);

        builder.Register<IMovementCalculator, EntityMovementCalculator>(Lifetime.Scoped);
        builder.Register<IRigidbody2D, StandartRigidBody2D>(Lifetime.Scoped).WithParameter(_pushBody);
        builder.Register<IMotorHandler, EntityMotorHandler>(Lifetime.Scoped);
        
    }
    private void RegisterItemHolder(IContainerBuilder builder)
    {
        builder.Register<IItemHolder>(container =>
        {
            IHand[] hands = new IHand[_hands.Length];

            for (int hand = 0; hand < _hands.Length; hand++)
                hands[hand] = null;//new EntityHand(_hands[hand]);

            return new EntityItemHolder(hands);

        }, Lifetime.Scoped);

        builder.Register<IItemHolderHandler, EntityItemHolderHandler<Dot>>(Lifetime.Scoped);
    }
    private void RegisterAnimation(IContainerBuilder builder)
    {
        builder.Register<IAnimation, EntityAnimation>(Lifetime.Scoped).WithParameter(_physicsAnimator);
    }
    private void RegisterControllers(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerMovementController>();
        builder.RegisterEntryPoint<PlayerItemHolderController>();
    }
    */
}
