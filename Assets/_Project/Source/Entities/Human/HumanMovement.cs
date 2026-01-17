using UnityEngine;
using VContainer;
[RequireComponent(typeof(Rigidbody2D))]
public class HumanMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Transform _groundCheck;

    private GroundCheckSettings _groundCheckSettings;
    private MovementSettings _movementSettings;
    private Rigidbody2D _rigidbody2D;

    private static readonly RaycastHit2D[] _singleHitBuffer = new RaycastHit2D[1];

    public bool IsGrounded { get; private set; }
    public float CurrentDirection { get; private set; }
    [Inject]
    public void Construct(GroundCheckSettings groundCheckSettings, MovementSettings movementSettings)
    {
        _groundCheckSettings = groundCheckSettings;
        _movementSettings = movementSettings;
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
        IsGrounded = CheckGround();
    }
    public void SetMovementDirection(float direction) => CurrentDirection = direction;
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
        if (!IsGrounded)
            return;

        _rigidbody2D.linearVelocity = new(_rigidbody2D.linearVelocity.x, 0);
        Vector2 jumpForce = new(_movementSettings.JumpBoost * CurrentDirection, _movementSettings.JumpForce);
        _rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
    }
    public void Sneak()
    {

    }
    private void OnDrawGizmos()
    {
        if (!_groundCheck || !_movementSettings || !_groundCheckSettings)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSettings.GroundCheckSize);
    }
}
