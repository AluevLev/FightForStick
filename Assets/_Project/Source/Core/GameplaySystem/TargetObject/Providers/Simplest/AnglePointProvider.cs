using UnityEngine;

public class AnglePointProvider : IPointProvider
{
    private readonly float? _angle;
    public AnglePointProvider(float? angle)
    {
        _angle = angle;
    }
    public bool HasValue => _angle.HasValue;
    public Vector2? GetPoint() => _angle?.GetVector();
}
