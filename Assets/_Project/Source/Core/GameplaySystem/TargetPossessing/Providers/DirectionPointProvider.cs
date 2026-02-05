using UnityEngine;

[System.Serializable]
public class DirectionPointProvider : IPointProvider
{
    [SerializeReference, InterfaceImplementation] private IPointProvider _from;
    [SerializeReference, InterfaceImplementation] private IPointProvider _to;
    public DirectionPointProvider() { }
    public DirectionPointProvider(IPointProvider from, IPointProvider to)
    {
        _from = from;
        _to = to;
    }
    public bool TryGetPoint(out Vector2 point)
    {
        if (_from.TryGetPointSafe(out Vector2 from) && _to.TryGetPointSafe(out Vector2 to))
        {
            point = (to - from).normalized;
            return true;
        }

        point = default;
        return false;
    }
}
