using IceFebruary.Space;

public interface IMovementCalculator
{
    Vector2 GetMovementVector(float movementDirection);
    Vector2 GetJumpVector(float movementDirection);
    Vector2 GetSneakVector();
}
