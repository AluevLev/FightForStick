namespace February.Components.UnityStandart
{
    using UnityEngine;
    using February.Space;
    using February.Components;
    using February.Adaptation;

    public class StandartRigidBody2D : ITogglable, IRigidbody2D
    {
        private readonly Rigidbody2D _rigidbody2D;
        public UniVector2 Position
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
        public UniVector2 LinearVelocity
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
        public StandartRigidBody2D(Rigidbody2D pushBody)
        {
            _rigidbody2D = pushBody;
        }
        public void AddForce(UniVector2 force, UniversalForceMode2D forceMode)
        {
            if (!Enabled)
                return;

            _rigidbody2D.AddForce(force.ToUnity2D(), (ForceMode2D)forceMode);
        }
        public void AddTorque(float torque, UniversalForceMode2D forceMode)
        {
            if (!Enabled)
                return;

            _rigidbody2D.AddTorque(torque, (ForceMode2D)forceMode);
        }
        public void MovePosition(UniVector2 position)
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
