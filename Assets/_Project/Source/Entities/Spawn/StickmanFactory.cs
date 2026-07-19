using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Time;

public sealed class StickmanFactory
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;
    private readonly IGameObject _stickmanPrefab;
    public StickmanFactory(ITime time, IPhysics2D physics2D, IObjectManager objectManager, IGameObject stickmanPrefab)
    {
        _time = time;
        _physics2D = physics2D;
        _objectManager = objectManager;
        _stickmanPrefab = stickmanPrefab;
    }
    public StickmanBuilder Create(Vector2 position)
    {
        _objectManager.Create(_stickmanPrefab, position).TryGetInstantiateInfo(out StickmanConfig stickmanConfig);

        return new(_time, _physics2D, stickmanConfig);
    }
}
