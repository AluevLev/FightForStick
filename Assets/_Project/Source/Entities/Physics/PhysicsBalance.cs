using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBalance : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float _force;
    [SerializeField] private float _startAngle;

    private IPointProvider _targetPoint;
    private Rigidbody2D _rigidbody2D;

    [field: SerializeField] public float AdditionalAngle { get; set; }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        SetTarget(new AnglePointProvider(_startAngle));
    }
    public void SetTarget(IPointProvider targetProvider) => _targetPoint = targetProvider;
    private void FixedUpdate()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (_targetPoint.TryGetPointSafe(out Vector2 point))
            return;

        float targetAngle = point.GetAngle() + AdditionalAngle;

        _rigidbody2D.MoveRotation(Mathf.LerpAngle(_rigidbody2D.rotation, targetAngle, _force));
    }
}
