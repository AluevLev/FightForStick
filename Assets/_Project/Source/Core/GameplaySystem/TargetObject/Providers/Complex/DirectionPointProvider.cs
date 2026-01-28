using UnityEngine;

public class DirectionPointProvider : IPointProvider 
{
    private readonly IPointProvider _origin;
    private readonly IPointProvider _target;
    public DirectionPointProvider(IPointProvider origin, IPointProvider target)
    {
        _origin = origin;
        _target = target;
    }
    public bool HasValue => _origin.Exists() && _target.Exists();
    public Vector2? GetPoint() => HasValue ? _target.GetPoint().Value - _origin.GetPoint().Value : null;
}
