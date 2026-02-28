using UnityEngine;

public interface IRigidbody2D
{
    Vector2 LinearVelocity { get; set; }
    float AngularVelocity { get; set; }
    Vector2 Position { get; set; }
    float Rotation { get; set; }
    void AddForce(Vector2 force, ForceMode2D forceMode);
    void AddTorque(float torque, ForceMode2D forceMode);
    void MovePosition(Vector2 position);
    void MoveRotation(float rotation);
}
