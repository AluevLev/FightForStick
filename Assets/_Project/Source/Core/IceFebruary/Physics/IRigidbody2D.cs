namespace IceFebruary.Physics
{
    using IceFebruary.Space;
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IRigidbody2D : IBaseEntity
    {
        Vector2 LinearVelocity { get; set; }
        float AngularVelocity { get; set; }
        Vector2 Position { get; set; }
        Rotor2 Rotation { get; set; }
        void AddForce(Vector2 force, ForceMode2D forceMode);
        void AddTorque(float torque, ForceMode2D forceMode);
        void MovePosition(Vector2 position);
        void MoveRotation(Rotor2 rotation);
    }
}
