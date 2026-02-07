using UnityEngine;

public class EntityMotor : ITogglable, IMotor
{
    private readonly Rigidbody2D _pushBody;
    private readonly IAreaCaster _areaCaster;
    private readonly IMovementCalculator _movementCalculator;
    public bool Enabled { get; set; }
    public EntityMotor(Rigidbody2D pushBody, IAreaCaster groundCheckSettings, IMovementCalculator movementSettings)
    {
        _pushBody = pushBody;
        _areaCaster = groundCheckSettings;
        _movementCalculator = movementSettings;
    }
    public void Jump(float movementDirection)
    {
        if (!Enabled || !_areaCaster.Cast())
            return;

        _pushBody.linearVelocity = _pushBody.linearVelocity.x * Vector2.right;
        _pushBody.AddForce(_movementCalculator.CalculateJumpVector(movementDirection), ForceMode2D.Impulse);
    }
    public void Move(float movementDirection)
    {
        if (!Enabled)
            return;

        _pushBody.AddForce(_movementCalculator.CalculateMovementVector(movementDirection), ForceMode2D.Force);
    }
}
