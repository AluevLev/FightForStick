using UnityEngine;
using VContainer;
using System;

public class TargetPossessing : MonoBehaviour, ITargetSource, ITargetSetter
{
    [SerializeField] private TargetType _startTarget;
    [SerializeField] private float _startTargetAngle;
    [SerializeField] private Vector2 _startTargetDirection;
    [SerializeField] private Transform _startTargetTransform;
    private Func<Vector2> _targetDirection;
    private ICursorWorldProvider _cursorWorldProvider;
    [field : SerializeField] public float AdditionalAngle { get; set; }
    public bool HasTarget => _targetDirection != null;
    [Inject]
    public void Construct(ICursorWorldProvider cursorWorldProvider)
    {
        _cursorWorldProvider = cursorWorldProvider;
    }
    private void Start()
    {
        switch (_startTarget)
        {
            case TargetType.Angle:
                SetTargetDirection(_startTargetAngle.GetVector());
                break;

            case TargetType.Direction:
                SetTargetDirection(_startTargetDirection);
                break;

            case TargetType.Transform:
                SetTargetTransform(_startTargetTransform);
                break;

            case TargetType.Mouse:
                SetTargetMousePosition();
                break;
        }
    }
    public Vector2? GetTargetDirection()
    {
        if (!HasTarget)
            return null;

        return _targetDirection.Invoke().Rotate(AdditionalAngle);
    }
    public void SetTargetDirection(Vector2 direction) => _targetDirection = () => direction.normalized;
    public void SetTargetTransform(Transform transform) => _targetDirection = () => ((Vector2)this.transform.position).DirectionTo(transform.position);
    public void SetTargetMousePosition() => _targetDirection = () => ((Vector2)transform.position).DirectionTo(_cursorWorldProvider.MousePosition);
    public void ResetTarget() => _targetDirection = null;
}
public enum TargetType
{
    None,
    Angle,
    Direction,
    Transform,
    Mouse
}