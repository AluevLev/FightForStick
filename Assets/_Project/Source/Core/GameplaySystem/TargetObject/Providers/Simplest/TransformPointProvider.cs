using UnityEngine;

public class TransformPointProvider : IPointProvider
{
    private readonly Transform _transform;
    public TransformPointProvider(Transform transform)
    {
        _transform = transform;
    }
    public bool HasValue => _transform;
    public Vector2? GetPoint() => HasValue ? _transform.position : null;
}
