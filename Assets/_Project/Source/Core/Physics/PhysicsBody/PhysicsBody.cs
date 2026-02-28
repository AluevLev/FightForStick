using UnityEngine;

public class PhysicsBody : ITogglable, IRigidbody2D
{
    private readonly Rigidbody2D _rigidbody2D;
    public Vector2 Position
    {
        get => _rigidbody2D.position;
        set
        {
            if (!Enabled)
                return;

            _rigidbody2D.position = value;
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
        get => _rigidbody2D.linearVelocity;
        set
        {
            if (!Enabled)
                return;

            _rigidbody2D.linearVelocity = value;
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
    public PhysicsBody(Rigidbody2D pushBody)
    {
        _rigidbody2D = pushBody;
    }
    public void AddForce(Vector2 force, ForceMode2D forceMode)
    {
        if (!Enabled)
            return;

        _rigidbody2D.AddForce(force, forceMode);
    }
    public void AddTorque(float torque, ForceMode2D forceMode)
    {
        if (!Enabled)
            return;

        _rigidbody2D.AddTorque(torque, forceMode);
    }
    public void MovePosition(Vector2 position)
    {
        if (!Enabled)
            return;

        _rigidbody2D.MovePosition(position);
    }
    public void MoveRotation(float rotation)
    {
        if (!Enabled)
            return;

        _rigidbody2D.MoveRotation(rotation);
    }
}
