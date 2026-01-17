public interface IMovable
{
    float CurrentDirection
    {
        get;
    }
    void SetMovementDirection(float direction);
    void Jump();
    void Sneak();
}
