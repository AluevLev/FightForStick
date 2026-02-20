using VContainer;
using VContainer.Unity;
using UnityEngine;

public class PlayerLifetimeScope : LifetimeScope
{
    [Header("Settings")]
    [SerializeField] private GroundCheckSettings _groundCheckSettings;
    [SerializeField] private MovementSettings _movementSettings;
    [Header("Ground Checker")]
    [SerializeField] private Transform _groundCheck;
    [Header("Components")]
    [SerializeField] private Rigidbody2D _pushBody;
    [SerializeField] private Animator _animator;
    [Space(10)]
    [Header("Pick up item settings:")]
    [SerializeField] private Rigidbody2D[] _hands;
    [SerializeField] private float _maxPickUpDistance;
    [Space(10)]
    [Header("Body parts settings:")]
    [Header("Head")]
    [SerializeField] private PhysicsLimbSettings _head;
    [Header("Body")]
    [SerializeField] private PhysicsLimbSettings _body;
    [Header("Arm 1")]
    [SerializeField] private PhysicsLimbSettings _shoulder1;
    [SerializeField] private PhysicsLimbSettings _forearm1;
    [SerializeField] private PhysicsLimbSettings _hand1;
    [Header("Arm 2")]
    [SerializeField] private PhysicsLimbSettings _shoulder2;
    [SerializeField] private PhysicsLimbSettings _forearm2;
    [SerializeField] private PhysicsLimbSettings _hand2;
    [Header("Leg 1")]
    [SerializeField] private PhysicsLimbSettings _hip1;
    [SerializeField] private PhysicsLimbSettings _shin1;
    [SerializeField] private PhysicsLimbSettings _foot1;
    [Header("Leg 2")]
    [SerializeField] private PhysicsLimbSettings _hip2;
    [SerializeField] private PhysicsLimbSettings _shin2;
    [SerializeField] private PhysicsLimbSettings _foot2;

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
    }
    private void RegisterPhysics(IContainerBuilder builder)
    {
        PhysicsLimbSettings[] limbs = new PhysicsLimbSettings[] {
            _head,
            _body,
            _shoulder1, _forearm1, _hand1,
            _shoulder2, _forearm2, _hand2,
            _hip1, _shin1, _foot1,
            _hip2, _shin2, _foot2 };

        builder.RegisterEntryPoint<RagdollCore>(Lifetime.Scoped).WithParameter(limbs);
    }
    private void RegisterMovement(IContainerBuilder builder)
    {
        builder.Register<IAreaCaster>(container =>
        {
            GroundCheckSettings groundCheckSettings = container.Resolve<GroundCheckSettings>();

            IPointProvider position = new TransformPointProvider(_groundCheck);
            IPointProvider angleDirection = new SpacePointProvider(_groundCheck, new Vector2PointProvider(Vector2.up));

            return new BoxCaster(position, groundCheckSettings.GroundCheckSize, angleDirection, groundCheckSettings.ContactFilter2D);

        }, Lifetime.Scoped);

        builder.Register<IMovementCalculator, EntityMovementCalculator>(Lifetime.Scoped);
        builder.Register<IPhysicsBody, PhysicsBody>(Lifetime.Scoped).WithParameter(_pushBody);
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

        builder.Register<IItemHolderHandler, EntityItemHolderHandler>(Lifetime.Scoped).WithParameter(_maxPickUpDistance);
    }
    private void RegisterAnimation(IContainerBuilder builder)
    {
        builder.Register<IAnimation, EntityAnimation>(Lifetime.Scoped).WithParameter(_animator);
    }
    private void RegisterControllers(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerMovementController>();
        builder.RegisterEntryPoint<PlayerItemHolderController>();
    }
}
