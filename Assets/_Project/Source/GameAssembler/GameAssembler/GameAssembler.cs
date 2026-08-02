using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;
using IceFebruary.Factories;

public sealed class GameAssembler
{
    private readonly GameAssemblerConfig _config;

    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;
    private readonly IInputProvider _playerInput;

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

        IVector2Provider playerCursorPosition = new ScreenToWorldVector2Provider(
            new MouseVector2Provider(_playerInput),
            _config.Camera);

        BuilderFactory<StickmanBuilder, StickmanConfig> stickmanFactory = new(_objectManager, () => new(Time, _physics2D));

        SpawnList spawnList = _config.SpawnList;
        SpawnSettings playerSpawnSettings = spawnList.PlayerSpawnsSetting;

        StickmanBuilder playerStickmanBuilder = stickmanFactory
            .Create(
            playerSpawnSettings.GameObject,
            playerSpawnSettings.Position,
            Rotor2.Default)
            .SetLimbs()
            .SetMovement()
            .SetItemHolder(playerCursorPosition)
            .SetInput(_playerInput);

        IVector2Provider playerStickmanPosition = playerStickmanBuilder.StickmanPosition;

        SpawnSettings[] enemiesSpawnList = spawnList.EnemiesSpawnSettings;

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

        ItemHolderSetterUp itemHolderSetterUp = new(Time);

        ItemSetterUp itemSetterUp = new(itemHolderSetterUp);
        Factory<ItemSetterUp, ItemConfig> itemFactory = new(_objectManager, itemSetterUp);

        CreateByList(spawnList.ItemsSpawnList, itemFactory);

        ShootingSetterUp shootingSetterUp = new(Time, _objectManager, itemHolderSetterUp);
        Factory<ShootingSetterUp, ShootingConfig> shootingFactory = new(_objectManager, shootingSetterUp);

        CreateByList(spawnList.ShootingSpawnList, itemFactory);
    }
    private void CreateByList<TSettableUp, TConfig>(SpawnSettings[] spawnList, Factory<TSettableUp, TConfig> factory) where TSettableUp : ISettableUp<TConfig> where TConfig : struct
    {
        for (int index = 0; index < spawnList.Length; index++)
        {
            SpawnSettings shootingSpawnSettings = spawnList[index];

            factory.Create(
                shootingSpawnSettings.GameObject,
                shootingSpawnSettings.Position,
                Rotor2.Default);
        }
    }
}
