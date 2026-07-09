using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public class EnemyMovementController : BaseEntity, IFrame
{
    private readonly IVector2Provider _positionDifferences;
    private readonly IMotorHandler _enemyMotorHandler;
    public EnemyMovementController(IVector2Provider positionDifferences, IMotorHandler enemyMotorHandler)
    {
        _positionDifferences = positionDifferences;
        _enemyMotorHandler = enemyMotorHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (!_positionDifferences.TryGetSafety(out Vector2 difference))
            return;

        _enemyMotorHandler.MovementDirection = difference.X.ClampNeg11();

        if (difference.Y > 0f)
            _enemyMotorHandler.Jump();
    }
}
