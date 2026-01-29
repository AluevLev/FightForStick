using UnityEngine;

public sealed class AnglePointProvider : IPointProvider
{
    private readonly float? _angle;
    private readonly bool _hasValue;
    public AnglePointProvider(float? angle)
    {
        _angle = angle;
        _hasValue = _angle.HasValue;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        point = _hasValue ? _angle.Value.GetVector() : default;

        return _hasValue;
    }
}
