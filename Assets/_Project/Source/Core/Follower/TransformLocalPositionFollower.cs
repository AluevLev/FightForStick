using UnityEngine;

public class TransformLocalPositionFollower : ITogglable, ITransformFollower
{
    private readonly IPointProvider _target;
    private readonly Transform _transform;
    private readonly float _distortion;
    public bool Enabled { get; set; } = true;
    public TransformLocalPositionFollower(Transform transform, IPointProvider target, float distortion)
    {
        _target = target;
        _transform = transform;
        _distortion = distortion;
    }
    public void Follow()
    {
        if (!Enabled)
            return;
        if (!_target.TryGetPointSafe(out Vector2 target))
            return;

        _transform.localPosition = target * _distortion;
    }
}
