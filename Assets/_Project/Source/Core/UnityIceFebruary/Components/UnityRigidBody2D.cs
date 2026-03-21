namespace UnityIceFebruary.Components
{
    using IceFebruary.Space;
    using IceFebruary.Physics;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.AutoGeneration.Match;

    using Rigidbody2D = UnityEngine.Rigidbody2D;

    [UnityAnalog(typeof(Rigidbody2D))]
    public class UnityRigidbody2D : IRigidbody2D
    {
        public Rigidbody2D Rigidbody2D { get; private init; }
        public UnityRigidbody2D(Rigidbody2D rigidbody2D)
        {
            Rigidbody2D = rigidbody2D;
        }
        public bool Enabled
        {
            get => Rigidbody2D.simulated;
            set => Rigidbody2D.simulated = value;
        }
        public Vector2 Position
        {
            get => Rigidbody2D.position.ToIce();
            set
            {
                if (!Enabled)
                    return;

                Rigidbody2D.position = value.ToUnity2D();
            }
        }
        public float Rotation
        {
            get => Rigidbody2D.rotation;
            set
            {
                if (!Enabled)
                    return;

                Rigidbody2D.rotation = value;
            }
        }
        public Vector2 LinearVelocity
        {
            get => Rigidbody2D.linearVelocity.ToIce();
            set
            {
                if (!Enabled)
                    return;

                Rigidbody2D.linearVelocity = value.ToUnity2D();
            }
        }
        public float AngularVelocity
        {
            get => Rigidbody2D.angularVelocity;
            set
            {
                if (!Enabled)
                    return;

                Rigidbody2D.angularVelocity = value;
            }
        }
        public void AddForce(Vector2 force, ForceMode2D forceMode)
        {
            if (!Enabled)
                return;

            Rigidbody2D.AddForce(force.ToUnity2D(), (UnityEngine.ForceMode2D)forceMode);
        }
        public void AddTorque(float torque, ForceMode2D forceMode)
        {
            if (!Enabled)
                return;

            Rigidbody2D.AddTorque(torque, (UnityEngine.ForceMode2D)forceMode);
        }
        public void MovePosition(Vector2 position)
        {
            if (!Enabled)
                return;

            Rigidbody2D.MovePosition(position.ToUnity2D());
        }
        public void MoveRotation(float rotation)
        {
            if (!Enabled)
                return;

            Rigidbody2D.MoveRotation(rotation);
        }
    }
}
