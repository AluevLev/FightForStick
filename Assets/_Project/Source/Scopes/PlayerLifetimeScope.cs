using VContainer;
using VContainer.Unity;
using UnityEngine;

public class PlayerLifetimeScope : LifetimeScope
{
    [Header("Settings")]
    [SerializeField] private GroundCheckSettings _groundCheckSettings;
    [SerializeField] private MovementSettings _movementSettings;
    [Header("Components")]
    [SerializeField] private Rigidbody2D _pushBody;
    [SerializeField] private Animator _animator;
    [Header("Ground Checker")]
    [SerializeField] private Transform _groundCheck;
    [Header("Body Parts")]
    [SerializeField] private Rigidbody2D[] _hands;
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterSettings(builder);

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
    private void RegisterMovement(IContainerBuilder builder)
    {
        builder.Register<IAreaCaster>(container =>
        {
            GroundCheckSettings groundCheckSettings = container.Resolve<GroundCheckSettings>();

            IPointProvider position = new TransformPointProvider(_groundCheck);
            IPointProvider angleDirection = new LocalSpacePointProvider(_groundCheck, new Vector2PointProvider(Vector2.up));

            return new BoxCaster(position, groundCheckSettings.GroundCheckSize, angleDirection, groundCheckSettings.ContactFilter2D);

        }, Lifetime.Scoped);

        builder.Register<IMovementCalculator, EntityMovementCalculator>(Lifetime.Scoped);
        builder.Register<IMotor, EntityMotor>(Lifetime.Scoped).WithParameter(_pushBody);
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
        builder.Register<IAnimation, EntityAnimation>(Lifetime.Scoped).WithParameter(_animator);
    }
    private void RegisterControllers(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerMovementController>();
        builder.RegisterEntryPoint<PlayerItemHolderController>();
    }
}
