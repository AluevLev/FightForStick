using UnityEngine;

public interface ITargetSetter
{
    float AdditionalAngle { get; set; }
    void SetTargetDirection(Vector2 direction);
    void SetTargetTransform(Transform direction);
    void SetTargetMousePosition();
    void ResetTarget();
}
