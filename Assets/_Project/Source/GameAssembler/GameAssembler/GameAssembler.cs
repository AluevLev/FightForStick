using IceFebruary;
using IceFebruary.Factories;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class GameAssembler
{
    private readonly GameAssemblerConfig _config;

    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;
    private readonly IInputProvider _playerInput;

    private CameraConfig _cameraConfig;

    private bool _assembled;

    public ITime Time { get; private init; }
    public GameAssembler(GameAssemblerConfig config, ITime time, IPhysics2D physics2D, IObjectManager objectManager, IInputProvider playerInput)
    {
        _config = config;

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

        CreateCamera();

        IVector2Provider playerStickmanPosition = SetUpPlayer(stickmanFactory);

        SetUpCamera(playerStickmanPosition);
        SetUpEnemies(stickmanFactory, playerStickmanPosition);
        SetUpItems();
    }
    private void CreateCamera()
    {
        SpawnSettings cameraSpawnSettings = _config.SpawnList.CameraSpawnSettings;

        IGameObject gameObject = _objectManager.Create(
            cameraSpawnSettings.GameObject,
            cameraSpawnSettings.Position,
            Rotor2.Default);

        ITransform transform = gameObject.Transform;

        _cameraConfig = gameObject.GetRootConfig() as CameraConfig;
    }
    private void SetUpCamera(IVector2Provider playerStickmanPosition)
    {
        IVector2Provider cameraTarget = new LerpVector2Provider(
            new TransformVector2Provider(_cameraConfig.Transform),
            playerStickmanPosition,
            _cameraConfig.Interpolation);

        CameraFollow cameraFollow = new(_cameraConfig.Transform);

        CameraSizeChanger cameraSizeChanger = new(
            _playerInput,
            _cameraConfig.Camera,
            _cameraConfig.MinSize,
            _cameraConfig.MaxSize);

        cameraFollow.SetTarget(cameraTarget);

        Time.LaunchIFrame(cameraFollow);
        Time.LaunchIFrame(cameraSizeChanger);
    }
    private IVector2Provider SetUpPlayer(BuilderFactory<StickmanBuilder, StickmanConfig> stickmanFactory)
    {
        SpawnList spawnList = _config.SpawnList;
        SpawnSettings playerSpawnSettings = spawnList.PlayerSpawnsSetting;

        IVector2Provider playerCursorPosition = new ScreenToWorldVector2Provider(
            new MouseVector2Provider(_playerInput),
            _cameraConfig.Camera);

        StickmanBuilder playerStickmanBuilder = stickmanFactory
            .Create(
            playerSpawnSettings.GameObject,
            playerSpawnSettings.Position,
            Rotor2.Default)
            .SetLimbs()
            .SetMovement()
            .SetItemHolder(playerCursorPosition)
            .SetInput(_playerInput);

        return playerStickmanBuilder.StickmanPosition;
    }
    private void SetUpEnemies(BuilderFactory<StickmanBuilder, StickmanConfig> stickmanFactory, IVector2Provider playerStickmanPosition)
    {
        SpawnSettings[] enemiesSpawnList = _config.SpawnList.EnemiesSpawnSettings;

        for (int index = 0; index < enemiesSpawnList.Length; index++)
        {
            SpawnSettings enemySpawnSettings = enemiesSpawnList[index];

            StickmanBuilder enemyStickmanBuilder = stickmanFactory.Create(
                enemySpawnSettings.GameObject,
                enemySpawnSettings.Position,
                Rotor2.Default);

            EnemyInputProvider enemyInput = new(
                enemyStickmanBuilder.StickmanPosition,
                playerStickmanPosition);

            Time.LaunchIFrame(enemyInput);

            IVector2Provider enemyCursorProvider = new MouseVector2Provider(enemyInput);

            enemyStickmanBuilder
                .SetLimbs()
                .SetMovement()
                .SetItemHolder(enemyCursorProvider)
                .SetInput(enemyInput);
        }
    }
    private void SetUpItems()
    {
        SpawnSettings[] itemsSpawnList = _config.SpawnList.ItemsSpawnList;

        ItemHolderSetterUp itemHolderSetterUp = new(Time);

        ItemSetterUp itemSetterUp = new(itemHolderSetterUp);
        ShootingSetterUp shootingSetterUp = new(Time, _objectManager, itemHolderSetterUp);
        SawSetterUp sawSetterUp = new(itemHolderSetterUp);

        for (int index = 0; index < itemsSpawnList.Length; index++)
        {
            SpawnSettings spawnSettings = itemsSpawnList[index];

            IRootConfig rootConfig = _objectManager.Create(
                spawnSettings.GameObject,
                spawnSettings.Position,
                Rotor2.Default)
                .GetRootConfig();

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
