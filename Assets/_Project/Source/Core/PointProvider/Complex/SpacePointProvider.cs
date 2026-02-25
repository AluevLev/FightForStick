using UnityEngine;

public class SpacePointProvider : IPointProvider
{
    private readonly IPointProvider _pointProvider;
    private readonly Transform _space;
    public SpacePointProvider(IPointProvider pointProvider, Transform space)
    {
        _space = space;
        _pointProvider = pointProvider;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        if (_space && _pointProvider.TryGetPointSafe(out Vector2 startPoint))
        {
            point = _space.TransformDirection(startPoint).normalized;
            return true;
        }

        point = default;
        return false;
    }
}
