using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBalance : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float _force;
    private ITargetSource _targetPossessing;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _targetPossessing = GetComponent<ITargetSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (!_targetPossessing.HasTarget)
            return;

        float targetAngle = _targetPossessing.GetTargetDirection().Value.GetAngle();

        _rigidbody2D.MoveRotation(Mathf.Lerp(_rigidbody2D.rotation, targetAngle, _force));
    }
}
