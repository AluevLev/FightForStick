using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IPointProvider))]
public class PhysicsBalance : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float _force;
    private IPointProvider _pointProvider;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _pointProvider = GetComponent<IPointProvider>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (!_pointProvider.Exists())
            return;

        float targetAngle = _pointProvider.GetPoint().Value.GetAngle();

        _rigidbody2D.MoveRotation(Mathf.LerpAngle(_rigidbody2D.rotation, targetAngle, _force));
    }
}
