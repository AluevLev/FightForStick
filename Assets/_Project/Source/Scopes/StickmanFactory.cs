using IceFebruary;
//using IceFebruary.Animation;
using IceFebruary.Physics;
using IceFebruary.Time;

public class StickmanFactory //TODO: this
{
    private readonly ITime _time;
    private readonly IPhysics2D _physics2D;
    private readonly IObjectManager _objectManager;

    private IGameObject _stickman;
    private IMotorHandler _motorHandler;
    public StickmanFactory(ITime time, IPhysics2D physics2D, IObjectManager objectManager)
    {
        _time = time;
        _physics2D = physics2D;
        _objectManager = objectManager;
    }
    public StickmanFactory Create(IGameObject stickman)
    {
        _stickman = _objectManager.Create(stickman);
        return this;
    }/*
    public StickmanFactory SetMovement(IRigidbody2D pushBody, IOverlapper groundCheck, MovementSettings movementCalculator, AnimatorVariable<float> movementFloat)
    {

    }*/
}
