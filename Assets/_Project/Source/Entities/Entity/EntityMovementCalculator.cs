using UnityEngine;

public class EntityMovementCalculator : IMovementCalculator
{
    private readonly MovementSettings _movementSettings;
    public EntityMovementCalculator(MovementSettings movementSettings)
    {
        _movementSettings = movementSettings;
    }
    public Vector2 CalculateMovementVector(float movementDirection)
    {
        return _movementSettings.Speed * movementDirection * Vector2.right;
    }
    public Vector2 CalculateJumpVector(float movementDirection)
    {
        return new(_movementSettings.JumpBoost * movementDirection, _movementSettings.JumpForce);
    }
}
