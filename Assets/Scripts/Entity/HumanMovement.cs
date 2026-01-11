using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMovement : MonoBehaviour, IMovable
{
    [SerializeField] private MovementSettings _movementSettings;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private GroundCheckSettings _groundCheckSettings;

    private static readonly RaycastHit2D[] _singleHitBuffer = new RaycastHit2D[1];

    private Rigidbody2D _rigidbody2D;
    private bool IsGrounded => CheckGround();
    public float CurrentDirection
    {
        get;
        private set;
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetMovementDirection(float direction) => CurrentDirection = direction;
    private void FixedUpdate()
    {
        Move();
    }
    private bool CheckGround()
    {
        int count = Physics2D.BoxCast(_groundCheck.position, _groundCheckSettings.GroundCheckSize, 0f, Vector2.zero, _groundCheckSettings.ContactFilter2D, _singleHitBuffer);
        return count > 0;
    }
    private void Move()
    {
        _rigidbody2D.AddForce(_movementSettings.Speed * CurrentDirection * Vector2.right, ForceMode2D.Force);
    }
    public void Jump()
    {
        if (IsGrounded)
        {
            _rigidbody2D.linearVelocity = Vector2.right * _rigidbody2D.linearVelocity.x;
            _rigidbody2D.AddForce(new(_movementSettings.JumpBoost * CurrentDirection, _movementSettings.JumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        if (!_groundCheck || !_movementSettings || !_groundCheckSettings)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSettings.GroundCheckSize);
    }
}
