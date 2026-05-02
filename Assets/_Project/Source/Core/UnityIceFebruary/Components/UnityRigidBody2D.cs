namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.AutoGeneration;
    using Rigidbody2D = UnityEngine.Rigidbody2D;

    [UnityAnalog(typeof(Rigidbody2D))]
    public sealed class UnityRigidbody2D : UnityBaseEntity<Rigidbody2D>, IRigidbody2D
    {
        public UnityRigidbody2D(Rigidbody2D rigidbody2D) : base(rigidbody2D) { }
        public Vector2 Position
        {
            get => Original.position.ToIce();
            set => Original.position = value.ToUnity();
        }
        public Rotor2 Rotation
        {
            get => Original.transform.rotation.ToIce();
            set => Original.SetRotation(Rotation.ToUnity());
        }
        public Vector2 LinearVelocity
        {
            get => Original.linearVelocity.ToIce();
            set => Original.linearVelocity = value.ToUnity();
        }
        public float AngularVelocity
        {
            get => Original.angularVelocity;
            set => Original.angularVelocity = value;
        }
        public void AddForce(Vector2 force, ForceMode2D forceMode) => Original.AddForce(force.ToUnity(), (UnityEngine.ForceMode2D)forceMode);
        public void AddTorque(float torque, ForceMode2D forceMode) => Original.AddTorque(torque, (UnityEngine.ForceMode2D)forceMode);
        public void MovePosition(Vector2 position) => Original.MovePosition(position.ToUnity());
        public void MoveRotation(Rotor2 rotation) => Original.MoveRotation(rotation.ToUnity());
    }
}
