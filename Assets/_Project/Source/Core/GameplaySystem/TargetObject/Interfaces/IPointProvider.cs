using UnityEngine;

public interface IPointProvider
{
    Vector2? GetPoint();
    bool HasValue { get; }
}