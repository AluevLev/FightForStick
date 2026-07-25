using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Time;

public sealed class StickmanFactory
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;
    public StickmanFactory(ITime time, IPhysics2D physics2D, IObjectManager objectManager)
    {
        _time = time;
        _physics2D = physics2D;
        _objectManager = objectManager;
    }
    public StickmanBuilder Create(IGameObject stickman, Vector2 position)
    {
        bool success = _objectManager.Create(stickman, position, Rotor2.Default).TryGetInstantiateInfo(out StickmanConfig stickmanConfig);

        return success ? new(_time, _physics2D, stickmanConfig) : null;
    }
}
