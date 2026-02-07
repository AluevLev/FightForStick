using UnityEngine;

public interface IMovementCalculator
{
    Vector2 CalculateMovementVector(float movementDirection);
    Vector2 CalculateJumpVector(float movementDirection);
}
