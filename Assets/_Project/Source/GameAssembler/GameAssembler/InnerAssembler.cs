using IceFebruary;
using IceFebruary.Factories;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class InnerAssembler : IInnerAssembler
{
    private readonly SpawnList _spawnList;

    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;
    private readonly IInputProvider _playerInput;

    private bool _assembled;

    public ITime Time { get; private init; }
    public InnerAssembler(SpawnList spawnList, ITime time, IPhysics2D physics2D, IObjectManager objectManager, IInputProvider playerInput)
    {
        _spawnList = spawnList;

        _physics2D = physics2D;
        _objectManager = objectManager;
        _playerInput = playerInput;

        Time = time;
    }
    public void Assemble()
    {
        if (_assembled)
            return;

        _assembled = true;

        BuilderFactory<StickmanBuilder, StickmanConfig> stickmanFactory = new(_objectManager, () => new(Time, _physics2D));

        CreateLevel();

        CameraConfig cameraConfig = CreateCamera();
        IVector2Provider playerStickmanPosition = SetUpPlayer(stickmanFactory, cameraConfig);

        SetUpCamera(playerStickmanPosition, cameraConfig);
        CreateEnemies(stickmanFactory, playerStickmanPosition);
        CreateItems();
    }
    private void CreateLevel()
    {
        SpawnSettings spawnSettings = _spawnList.LevelSpawnSettings;

        _objectManager.Create(
            spawnSettings.GameObject,
            spawnSettings.Position,
            Rotor2.Default);
    }
    private CameraConfig CreateCamera()
    {
        SpawnSettings spawnSettings = _spawnList.CameraSpawnSettings;

        return _objectManager
            .Create(spawnSettings.GameObject, spawnSettings.Position, Rotor2.Default)
            .TryGetRootConfig(out CameraConfig rootConfig) ? rootConfig : null;
    }
    private void SetUpCamera(IVector2Provider playerStickmanPosition, CameraConfig cameraConfig)
    {
        CameraSettings settings = cameraConfig.Settings;

        IVector2Provider target = new LerpVector2Provider(
            new TransformVector2Provider(cameraConfig.Transform),
            playerStickmanPosition,
            settings.Interpolation);

        CameraFollow follow = new(cameraConfig.Transform);

        CameraSizeChanger sizeChanger = new(
            _playerInput,
            cameraConfig.Camera,
            settings.MinSize,
            settings.MaxSize,
            settings.Sensitivity);

        follow.SetTarget(target);

        Time.LaunchIFrame(follow);
        Time.LaunchIFrame(sizeChanger);
    }
    private IVector2Provider SetUpPlayer(BuilderFactory<StickmanBuilder, StickmanConfig> stickmanFactory, CameraConfig cameraConfig)
    {
        SpawnSettings spawnSettings = _spawnList.PlayerSpawnsSetting;

        IVector2Provider playerCursorPosition = new ScreenToWorldVector2Provider(
            new MouseVector2Provider(_playerInput),
            cameraConfig.Camera);

        StickmanBuilder playerStickmanBuilder = stickmanFactory
            .Create(
            spawnSettings.GameObject,
            spawnSettings.Position,
            Rotor2.Default)
            .SetLimbs()
            .SetMovement()
            .SetItemHolder(playerCursorPosition)
            .SetInput(_playerInput);

        return playerStickmanBuilder.StickmanPosition;
    }
    private void CreateEnemies(BuilderFactory<StickmanBuilder, StickmanConfig> stickmanFactory, IVector2Provider playerStickmanPosition)
    {
        SpawnSettings[] spawnList = _spawnList.EnemiesSpawnList;

        for (int index = 0; index < spawnList.Length; index++)
        {
            SpawnSettings spawnSettings = spawnList[index];

            StickmanBuilder stickmanBuilder = stickmanFactory.Create(
                spawnSettings.GameObject,
                spawnSettings.Position,
                Rotor2.Default);

            EnemyInputProvider input = new(
                stickmanBuilder.StickmanPosition,
                playerStickmanPosition);

            Time.LaunchIFrame(input);

            IVector2Provider cursor = new MouseVector2Provider(input);

            stickmanBuilder
                .SetLimbs()
                .SetMovement()
                .SetItemHolder(cursor)
                .SetInput(input);

            input.EnemyHolderHandler = stickmanBuilder.ItemHolderHandler;
        }
    }
    private void CreateItems()
    {
        SpawnSettings[] spawnList = _spawnList.ItemsSpawnList;

        ItemHolderSetterUp itemHolderSetterUp = new(Time);

        ItemSetterUp itemSetterUp = new(itemHolderSetterUp);
        ShootingSetterUp shootingSetterUp = new(Time, _objectManager, itemHolderSetterUp);
        SawSetterUp sawSetterUp = new(itemHolderSetterUp);

        for (int index = 0; index < spawnList.Length; index++)
        {
            SpawnSettings spawnSettings = spawnList[index];

            if (!_objectManager.Create(spawnSettings.GameObject, spawnSettings.Position, Rotor2.Default).TryGetRootConfig(out IRootConfig rootConfig))
                return;

            switch (rootConfig)
            {
                case ItemConfig itemConfig:
                    itemSetterUp.SetUp(itemConfig);
                    break;

                case ShootingConfig shootingConfig:
                    shootingSetterUp.SetUp(shootingConfig);
                    break;

                case SawConfig sawConfig:
                    sawSetterUp.SetUp(sawConfig);
                    break;
            }
        }
    }
}
