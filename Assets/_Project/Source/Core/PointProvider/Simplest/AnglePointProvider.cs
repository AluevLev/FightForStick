using UnityEngine;

public class AnglePointProvider : IPointProvider
{
    private readonly Vector2 _vectorAngle;
    public AnglePointProvider(float angle)
    {
        _vectorAngle = angle.GetVector();
    }
    public bool TryGetPoint(out Vector2 point)
    {
        point = _vectorAngle;
        return true;
    }
}
