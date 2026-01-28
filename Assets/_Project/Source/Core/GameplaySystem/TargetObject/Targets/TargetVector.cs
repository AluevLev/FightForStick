using System;
using UnityEngine;

public class TargetVector : MonoBehaviour, ITargetSetter, IPointProvider
{
    [SerializeField] private float _additionalAngle;
    public Func<Vector2?> _target = () => null;
    public void SetTarget(IPointProvider pointProvider)
    {
        _target = () =>
        {
            if (pointProvider.Exists())
                return pointProvider.GetPoint().Value.Rotate(_additionalAngle);
            return null;
        };
    }
    public bool HasValue => _target != null && _target.Invoke() != null;
    public Vector2? GetPoint() => _target?.Invoke();
    public void ResetTarget() => _target = () => null;
}
