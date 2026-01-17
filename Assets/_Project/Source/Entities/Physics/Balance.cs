using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float _force;
    [SerializeField] private float _additionalRotation;
    private float _targetRotation;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _targetRotation = transform.eulerAngles.z;
    }
    private void FixedUpdate()
    {
        _rigidbody2D.MoveRotation(Mathf.LerpAngle(_rigidbody2D.rotation, _targetRotation + _additionalRotation, _force));
    }
}