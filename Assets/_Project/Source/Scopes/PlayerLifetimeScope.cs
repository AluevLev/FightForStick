using VContainer;
using VContainer.Unity;
using UnityEngine;

public class PlayerLifetimeScope : LifetimeScope
{
    [Header("Scriptable Object Data")]
    [SerializeField] private GroundCheckSettings _groundCheckSettings;
    [SerializeField] private MovementSettings _movementSettings;
    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private GrimaceLibrary _grimaceLibrary;
    [SerializeField] private AnimatorFieldNameProxy _pulseFieldName;

    [Header("Scene Components")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Animator _face;
    [SerializeField] private Animator _physicsAnimator;
    [SerializeField] private Rigidbody2D _pushBody;
    [SerializeField] private Rigidbody2D[] _hands;
    [SerializeField] private SpriteRenderer _eye1;
    [SerializeField] private SpriteRenderer _eye2;
    [SerializeField] private SpriteRenderer _mouth;

    [Header("Body parts settings:")]
    [SerializeField] private RagdollScema _ragdollScema;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterSettings(builder);

        RegisterPhysics(builder);

        RegisterMovement(builder);

        RegisterItemHolder(builder);

        RegisterAnimation(builder);

        RegisterControllers(builder);
    }
    private void RegisterSettings(IContainerBuilder builder)
    {
        builder.RegisterInstance(_groundCheckSettings);
        builder.RegisterInstance(_movementSettings);
        builder.RegisterInstance(_pickUpSettings);
        builder.RegisterInstance(_grimaceLibrary);
    }
    private void RegisterPhysics(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<RagdollCore>(Lifetime.Scoped).WithParameter(_ragdollScema.ToArray());
    }
    private void RegisterMovement(IContainerBuilder builder)
    {
        builder.Register<IAreaCaster>(container =>
        {
            GroundCheckSettings groundCheckSettings = container.Resolve<GroundCheckSettings>();

            IPointProvider position = new TransformPointProvider(_groundCheck);
            IPointProvider angleDirection = new SpacePointProvider(new Vector2PointProvider(Vector2.up), _groundCheck);

            return new BoxCaster(position, groundCheckSettings.GroundCheckSize, angleDirection, groundCheckSettings.ContactFilter2D);

        }, Lifetime.Scoped);

        builder.Register<IMovementCalculator, EntityMovementCalculator>(Lifetime.Scoped);
        builder.Register<IRigidbody2D, PhysicsBody>(Lifetime.Scoped).WithParameter(_pushBody);
        builder.Register<IMotorHandler, EntityMotorHandler>(Lifetime.Scoped);
    }
    private void RegisterItemHolder(IContainerBuilder builder)
    {
        builder.Register<IItemHolder>(container =>
        {
            IHand[] hands = new IHand[_hands.Length];

            for (int hand = 0; hand < _hands.Length; hand++)
                hands[hand] = new EntityHand(_hands[hand]);

            return new EntityItemHolder(hands);

        }, Lifetime.Scoped);

        builder.Register<IItemHolderHandler, EntityItemHolderHandler>(Lifetime.Scoped);
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
}
