using IceFebruary;

public interface IMotorHandler : IBaseEntity
{
    float MovementDirection { get; set; }
    bool IsSneaking { get; set; }
    void Jump();
}
