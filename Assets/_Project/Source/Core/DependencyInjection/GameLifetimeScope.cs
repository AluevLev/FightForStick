using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private MovementSettings _movementSettings;
    [SerializeField] private GroundCheckSettings _groundCheckSettings;
    [SerializeField] private HumanMovement _playerMovement;
    [SerializeField] private HumanAnimation _playerAnimation;
    [SerializeField] private HumanItemHolder _playerItemHolder;
    [SerializeField] private FacialExpressions _playerFace;
    [SerializeField] private Camera _mainCamera;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_playerAnimation);
        builder.RegisterInstance(_movementSettings);
        builder.RegisterInstance(_groundCheckSettings);

        builder.RegisterComponent(_playerFace);
        builder.RegisterComponent(_playerItemHolder);
        builder.RegisterComponent(_mainCamera);

        builder.Register<GameInputAction>(Lifetime.Singleton);
        
        builder.RegisterEntryPoint<InputProvider>(Lifetime.Singleton);
        builder.RegisterEntryPoint<CursorWorldProvider>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerInputHandler>();

        builder.RegisterComponent(_playerMovement).AsImplementedInterfaces();
    }
}
