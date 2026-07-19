using IceFebruary.Space;

public sealed class EntityMovementCalculator : IMovementCalculator
{
    private readonly float _speed;
    private readonly float _jumpBoost;
    private readonly float _jumpForce;
    public EntityMovementCalculator(float speed, float jumpBoost, float jumpForce)
    {
        _speed = speed;
        _jumpBoost = jumpBoost;
        _jumpForce = jumpForce;
    }
    public Vector2 CalculateMovementVector(float movementDirection) => _speed * movementDirection * Vector2.Right;
    public Vector2 CalculateJumpVector(float movementDirection) => new(_jumpBoost * movementDirection, _jumpForce);
}
