using UnityEngine;
using VContainer;

[RequireComponent(typeof(ITargetSetter))]
[RequireComponent(typeof(IPointProvider))]
public class FaceRotator : MonoBehaviour
{
    [SerializeField] private Transform _face;
    [SerializeField] private float _maxDistancing;

    private ITargetSetter _targetSetter;
    private IPointProvider _pointProvider;

    private IPointProvider _cursor;
    [Inject]
    public void Construct(IPointProvider cursor)
    {
        _cursor = cursor;
    }
    private void Awake()
    {
        _targetSetter = GetComponent<ITargetSetter>();
        _pointProvider = GetComponent<IPointProvider>();
    }
    private void Start()
    {
        var direction = new TransformPointProvider(transform).DirectionTo(_cursor);
        _targetSetter.SetTarget(direction);
    }
    private void Update()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (_pointProvider.Exists())
            return;

        Vector2 targetPosition = _pointProvider.GetPoint().Value;
        Vector3 rotateDirection = Quaternion.Euler(Vector3.forward * -transform.eulerAngles.z) * targetPosition;
        _face.localPosition = rotateDirection * _maxDistancing;
    }
}
