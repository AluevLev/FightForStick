using UnityEngine;

public class TransformPointProvider : IPointProvider
{
    private readonly Transform _transform;
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
