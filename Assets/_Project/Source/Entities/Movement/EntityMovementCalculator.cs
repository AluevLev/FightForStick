using IceFebruary.Space;

public sealed class EntityMovementCalculator : IMovementCalculator
{
    private readonly MovementSettings _movementSettings;
    public EntityMovementCalculator(MovementSettings movementSettings)
    {
        _movementSettings = movementSettings;
    }
    public Vector2 CalculateMovementVector(float movementDirection) => _movementSettings.Speed * movementDirection * Vector2.Right;
    public Vector2 CalculateJumpVector(float movementDirection) => new(_movementSettings.JumpBoost * movementDirection, _movementSettings.JumpForce);
}
