namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.AutoGeneration;
    using Rigidbody2D = UnityEngine.Rigidbody2D;

    [UnityAnalog(typeof(Rigidbody2D))]
    public class UnityRigidbody2D : IRigidbody2D, IUnityAnalog
    {
        public Rigidbody2D Rigidbody2D { get; private init; }
        public UnityEngine.Object Original { get; private init; }
        public UnityRigidbody2D(Rigidbody2D rigidbody2D)
        {
            Rigidbody2D = rigidbody2D;
            Original = rigidbody2D;
        }
        public Vector2 Position
        {
            get => Rigidbody2D.position.ToIce();
            set => Rigidbody2D.position = value.ToUnity2D();
        }
        public float Rotation
        {
            get => Rigidbody2D.rotation;
            set => Rigidbody2D.rotation = value;
        }
        public Vector2 LinearVelocity
        {
            get => Rigidbody2D.linearVelocity.ToIce();
            set => Rigidbody2D.linearVelocity = value.ToUnity2D();
        }
        public float AngularVelocity
        {
            get => Rigidbody2D.angularVelocity;
            set => Rigidbody2D.angularVelocity = value;
        }
        public void AddForce(Vector2 force, ForceMode2D forceMode) => Rigidbody2D.AddForce(force.ToUnity2D(), (UnityEngine.ForceMode2D)forceMode);
        public void AddTorque(float torque, ForceMode2D forceMode) => Rigidbody2D.AddTorque(torque, (UnityEngine.ForceMode2D)forceMode);
        public void MovePosition(Vector2 position) => Rigidbody2D.MovePosition(position.ToUnity2D());
        public void MoveRotation(float rotation) => Rigidbody2D.MoveRotation(rotation);
    }
}
