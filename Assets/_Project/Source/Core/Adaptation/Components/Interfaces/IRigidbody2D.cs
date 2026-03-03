namespace February.Components
{
    using February.Space;

    public interface IRigidbody2D
    {
        UniVector2 LinearVelocity { get; set; }
        float AngularVelocity { get; set; }
        UniVector2 Position { get; set; }
        float Rotation { get; set; }
        void AddForce(UniVector2 force, UniversalForceMode2D forceMode);
        void AddTorque(float torque, UniversalForceMode2D forceMode);
        void MovePosition(UniVector2 position);
        void MoveRotation(float rotation);
    }
}
