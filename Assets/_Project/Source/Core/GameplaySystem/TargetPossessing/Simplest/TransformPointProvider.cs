using UnityEngine;

[System.Serializable]
public class TransformPointProvider : IPointProvider
{
    [SerializeField] private Transform _transform;
    public TransformPointProvider() { }
    public TransformPointProvider(Transform transform)
    {
        _transform = transform;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        bool hasValue = _transform;

        point = hasValue ? _transform.position : default;

        return hasValue;
    }
}
