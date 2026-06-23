using VContainer;
using VContainer.Unity;
using UnityEngine;

public sealed class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private MovementSettings _movementSettings;
    [SerializeField] private GroundCheckSettings _groundCheckSettings;
    [SerializeField] private Camera _mainCamera;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_movementSettings);
        builder.RegisterInstance(_groundCheckSettings);

        builder.RegisterComponent(_mainCamera);

        builder.Register<GameInputAction>(Lifetime.Singleton);
        
        builder.RegisterEntryPoint<UnityInputProvider>(Lifetime.Singleton);
        //builder.RegisterEntryPoint<CursorPointProvider>(Lifetime.Singleton).AsSelf();
    }
}
