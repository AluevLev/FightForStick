using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Follow;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class CameraFollow : BaseEntity, IFrame, ITargetPossessing<IVector2Provider>
{
    private readonly ITransform _cameraPosition;
    private IVector2Provider _targetPosition;
    public CameraFollow(ITransform cameraPosition)
    {
        _cameraPosition = cameraPosition;
    }
    public void SetTarget(IVector2Provider target) => _targetPosition = target;
    public void ResetTarget() => _targetPosition = null;
    public void OnFrame(float frameLength)
    {
        if (_cameraPosition.Exists() && _targetPosition.TryGetSafety(out Vector2 targetPosition))
            _cameraPosition.Position = targetPosition;
    }
}
