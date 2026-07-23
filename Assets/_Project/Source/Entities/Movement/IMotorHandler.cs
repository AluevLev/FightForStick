public interface IMotorHandler
{
    float MovementDirection { get; set; }
    bool IsSneaking { get; set; }
    void Jump();
}
