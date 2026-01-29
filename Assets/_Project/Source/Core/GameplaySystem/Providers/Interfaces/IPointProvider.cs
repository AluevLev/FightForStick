using UnityEngine;

public interface IPointProvider
{
    /// <summary>
    /// ATTENTION: Use .TryGetPointSafe(), if you are unsure whether IPointProvider is null.
    /// </summary>
    bool TryGetPoint(out Vector2 point);
}