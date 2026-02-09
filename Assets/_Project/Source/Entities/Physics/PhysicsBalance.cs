using System;
using UnityEngine;
using VContainer.Unity;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBalance : ITogglable, ITargetPossessing, IFixedTickable
{
    private readonly float _force;
    private readonly Rigidbody2D _rigidbody2D;

    private readonly IPointProvider _defaultPointProvider;
    private IPointProvider _targetPoint;

    public float AdditionalAngle { get; set; }
    public bool Enabled { get; set; }
    public PhysicsBalance(Rigidbody2D rigidbody2D, float force, IPointProvider defaultPointProvider = null)
    {
        _rigidbody2D = rigidbody2D;
        _force = force;
        _defaultPointProvider = defaultPointProvider;

        SetTarget(_defaultPointProvider);
    }
    public void SetTarget(IPointProvider targetProvider) => _targetPoint = targetProvider;
    public void ResetTarget() => _targetPoint = _defaultPointProvider;
    public void Relax() => _targetPoint = null;
    public void FixedTick()
    {
        LookAtTarget();
    }
    private void LookAtTarget()
    {
        if (!Enabled)
            return;
        if (!_targetPoint.TryGetPointSafe(out Vector2 point))
            return;

        float targetAngle = point.GetAngle() + AdditionalAngle;

        _rigidbody2D.MoveRotation(Mathf.LerpAngle(_rigidbody2D.rotation, targetAngle, _force));
    }
}
