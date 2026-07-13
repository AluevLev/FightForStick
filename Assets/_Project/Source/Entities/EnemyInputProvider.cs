using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public class EnemyInputProvider : BaseEntity, IInputProvider, IFrame
{
    private readonly ITime _time;
    private readonly IVector2Provider _targetPosition;
    private readonly IVector2Provider _enemyPosition;
    private readonly IItemHolderHandler _enemyHolderHandler;
    private readonly float _pickableCheckerPeriod;
    private float _cooldownEnd;
    public EnemyInputProvider(ITime time, IVector2Provider targetPosition, IVector2Provider enemyPosition, IItemHolderHandler enemyItemHolderHandler, float pickableCheckerPeriod)
    {
        _time = time;
        _targetPosition = targetPosition;
        _enemyPosition = enemyPosition;
        _enemyHolderHandler = enemyItemHolderHandler;
        _pickableCheckerPeriod = pickableCheckerPeriod;
    }
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement { get; private set; }
    public bool IsDroppingItem { get; private set; }

    public Vector2 MousePosition { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsPickingUp { get; private set; }
    public void OnFrame(float frameLength)
    {
        bool itemInHandExists = _enemyHolderHandler.ItemInHand.Exists();

        Vector2 enemyPosition = default;
        Vector2 targetPosition = default;

        bool success = _enemyPosition.TryGetSafety(out enemyPosition) && _targetPosition.TryGetSafety(out targetPosition);

        HorizontalMovement = success ? targetPosition.X.CompareTo(enemyPosition.X) : 0f;
        VerticalMovement = success ? targetPosition.Y.CompareTo(enemyPosition.Y) : 0f;

        MousePosition = success ? targetPosition : enemyPosition;

        IsAttacking = itemInHandExists;
        IsPickingUp = !itemInHandExists;
        IsDroppingItem = false;
    }
}
