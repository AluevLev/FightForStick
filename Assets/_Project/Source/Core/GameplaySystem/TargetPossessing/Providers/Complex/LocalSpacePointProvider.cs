using UnityEngine;

[System.Serializable]
public class LocalSpacePointProvider : IPointProvider
{
    [SerializeReference, InterfaceImplementation] private IPointProvider _pointProvider;
    [SerializeField] private Transform _space;
    public LocalSpacePointProvider() { }
    public LocalSpacePointProvider(Transform space, IPointProvider pointProvider)
    {
        _space = space;
        _pointProvider = pointProvider;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        if (_pointProvider.TryGetPointSafe(out Vector2 to))
        {
            point = _space.TransformDirection(to).normalized;
            return true;
        }

        point = default;
        return false;
    }
}
