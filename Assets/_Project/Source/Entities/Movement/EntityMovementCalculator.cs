using IceFebruary.Space;

public sealed class EntityMovementCalculator : IMovementCalculator
{
    private readonly float _speed;
    private readonly float _sneakSpeed;
    private readonly float _jumpSpeed;
    private readonly float _sneakBoost;
    private readonly float _jumpBoost;
    public EntityMovementCalculator(float speed, float sneakSpeed, float jumpSpeed, float sneakBoost, float jumpBoost)
    {
        _speed = speed;
        _sneakSpeed = sneakSpeed;
        _jumpSpeed = jumpSpeed;
        _sneakBoost = sneakBoost;
        _jumpBoost = jumpBoost;
    }
    public Vector2 CalculateMovementVector(float movementDirection) => _speed * movementDirection * Vector2.Right;
    public Vector2 CalculateSneakMovementVector(float movementDirection) => new(_sneakSpeed * movementDirection, _sneakBoost);
    public Vector2 CalculateJumpVector(float movementDirection) => new(_jumpSpeed * movementDirection, _jumpBoost);
}
