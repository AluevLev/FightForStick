using IceFebruary.Space;

public sealed class EntityMovementCalculator : IMovementCalculator
{
    private readonly float _jumpSpeed;
    private readonly float _jumpBoost;
    private readonly Vector2 _movementUnitVector;
    private readonly Vector2 _sneakVector;
    public EntityMovementCalculator(float speed, float jumpSpeed, float jumpBoost, float sneakBoost)
    {
        _jumpSpeed = jumpSpeed;
        _jumpBoost = jumpBoost;

        _movementUnitVector = speed * Vector2.Right;
        _sneakVector = sneakBoost * Vector2.Top;
    }
    public Vector2 GetMovementVector(float movementDirection) => movementDirection * _movementUnitVector;
    public Vector2 GetJumpVector(float movementDirection) => new(_jumpSpeed * movementDirection, _jumpBoost);
    public Vector2 GetSneakVector() => _sneakVector;
}
