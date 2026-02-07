using UnityEngine;

[System.Serializable]
public sealed class Vector2PointProvider : IPointProvider
{
    [SerializeField] private Vector2 _vector2;
    public Vector2PointProvider() { }
    public Vector2PointProvider(Vector2 vector2)
    {
        _vector2 = vector2;
    }
    public Vector2PointProvider(float x, float y)
    {
        _vector2 = new(x, y);
    }
    public bool TryGetPoint(out Vector2 point)
    {
        point = _vector2;
        return true;
    }
}
