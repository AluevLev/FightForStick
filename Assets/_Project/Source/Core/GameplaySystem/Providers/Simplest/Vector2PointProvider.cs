using UnityEngine;

public sealed class Vector2PointProvider : IPointProvider
{
    private readonly Vector2? _vector2;
    private readonly bool _hasValue;
    public Vector2PointProvider(Vector2? vector2)
    {
        _vector2 = vector2;
        _hasValue = _vector2.HasValue;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        point = _hasValue ? _vector2.Value : default;

        return _hasValue;
    }
}
