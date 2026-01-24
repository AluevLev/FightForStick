using UnityEngine;
[RequireComponent(typeof(TargetPossessing))]
public class FaceRotator : MonoBehaviour
{
    [SerializeField] private Transform _face;
    [SerializeField] private float _maxDistancing;
    private TargetPossessing _targetPossessing;
    private void Awake()
    {
        _targetPossessing = GetComponent<TargetPossessing>();
    }
    private void Start()
    {
        _targetPossessing.SetTargetMousePosition();
    }
    private void Update()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (!_targetPossessing.HasTarget)
            return;

        Vector2 targetPosition = _targetPossessing.GetTargetDirection().Value;
        Vector3 rotateDirection = Quaternion.Euler(Vector3.forward * -transform.eulerAngles.z) * targetPosition;
        _face.localPosition = rotateDirection * _maxDistancing;
    }
}
