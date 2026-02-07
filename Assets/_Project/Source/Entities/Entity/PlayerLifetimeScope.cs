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
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_groundCheckSettings);
        builder.RegisterInstance(_movementSettings);

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
        builder.Register<IAnimation, EntityAnimation>(Lifetime.Scoped).WithParameter(_animator);
        builder.RegisterEntryPoint<PlayerController>();
    }
}
