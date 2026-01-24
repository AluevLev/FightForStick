using UnityEngine;

public interface ITargetSource
{
    bool HasTarget { get; }
    Vector2? GetTargetDirection();
}
