using UnityEngine;

public class Vector2PointProvider : IPointProvider
{
    private readonly Vector2? _vector2;
    public Vector2PointProvider(Vector2? vector2)
    {
        _vector2 = vector2;
    }
    public bool HasValue => _vector2.HasValue;
    public Vector2? GetPoint() => _vector2;
}
