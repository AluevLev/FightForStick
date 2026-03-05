namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Space;
    using IceFebruary.Components;
    using IceFebruary.Physics;
    using UnityIceFebruary.Adaptation;

    public class UnityRigidBody2D : ITogglable, IRigidbody2D
    {
        private readonly UnityEngine.Rigidbody2D _rigidbody2D;
        public Vector2 Position
        {
            get => _rigidbody2D.position.ToUniversal();
            set
            {
                if (!Enabled)
                    return;

                _rigidbody2D.position = value.ToUnity2D();
            }
        }
        public float Rotation
        {
            get => _rigidbody2D.rotation;
            set
            {
                if (!Enabled)
                    return;

                _rigidbody2D.rotation = value;
            }
        }
        public Vector2 LinearVelocity
        {
            get => _rigidbody2D.linearVelocity.ToUniversal();
            set
            {
                if (!Enabled)
                    return;

                _rigidbody2D.linearVelocity = value.ToUnity2D();
            }
        }
        public float AngularVelocity
        {
            get => _rigidbody2D.angularVelocity;
            set
            {
                if (!Enabled)
                    return;

                _rigidbody2D.angularVelocity = value;
            }
        }
        public bool Enabled { get; set; } = true;
        public UnityRigidBody2D(UnityEngine.Rigidbody2D pushBody)
        {
            _rigidbody2D = pushBody;
        }
        public void AddForce(Vector2 force, ForceMode2D forceMode)
        {
            if (!Enabled)
                return;

            _rigidbody2D.AddForce(force.ToUnity2D(), (UnityEngine.ForceMode2D)forceMode);
        }
        public void AddTorque(float torque, ForceMode2D forceMode)
        {
            if (!Enabled)
                return;

            _rigidbody2D.AddTorque(torque, (UnityEngine.ForceMode2D)forceMode);
        }
        public void MovePosition(Vector2 position)
        {
            if (!Enabled)
                return;

            _rigidbody2D.MovePosition(position.ToUnity2D());
        }
        public void MoveRotation(float rotation)
        {
            if (!Enabled)
                return;

            _rigidbody2D.MoveRotation(rotation);
        }
    }
}
