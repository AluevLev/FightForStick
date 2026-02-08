using UnityEngine;
using VContainer;

public class FaceRotator : MonoBehaviour
{
    [SerializeField] private Transform _face;
    [SerializeField] private float _maxDistancing;

    private IPointProvider _curcorProvider;
    [Inject]
    public void Construct(IPointProvider cursor)
    {
        _curcorProvider = cursor;
    }
    private void Update()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (!_curcorProvider.TryGetPointSafe(out Vector2 mousePosition))
            return;

        Vector3 direction = (mousePosition - (Vector2)transform.position).normalized;
        Vector3 rotateDirection = Quaternion.Euler(Vector3.forward * -transform.eulerAngles.z) * direction;
        _face.localPosition = rotateDirection * _maxDistancing;
    }
}
