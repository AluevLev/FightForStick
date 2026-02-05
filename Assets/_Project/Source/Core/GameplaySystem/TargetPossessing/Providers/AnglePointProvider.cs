using UnityEngine;

[System.Serializable]
public sealed class AnglePointProvider : IPointProvider
{
    [SerializeField] private float _angle;
    public AnglePointProvider() { }
    public AnglePointProvider(float angle)
    {
        _angle = angle;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        point = _angle.GetVector();
        return true;
    }
}
