using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class EnemyInputProvider : BaseEntity, IInputProvider, IFrame
{
    private readonly IVector2Provider _enemyPosition;
    private readonly IVector2Provider _targetPosition;
    public IItemHolderHandler EnemyHolderHandler { get; set; }
    public EnemyInputProvider(IVector2Provider enemyPosition, IVector2Provider targetPosition)
    {
        _enemyPosition = enemyPosition;
        _targetPosition = targetPosition;
    }
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public float MouseScrolldown => 0f;

    public bool IsDroppingItem => false;
    public bool IsUsing { get; private set; }
    public bool IsPickingUpItem { get; private set; }
    public void OnFrame(float frameLength)
    {
        bool itemInHandExists = EnemyHolderHandler.Item.Exists();

        Vector2 targetPosition = default;

        bool success = _enemyPosition.TryGetSafety(out Vector2 enemyPosition) && _targetPosition.TryGetSafety(out targetPosition);

        HorizontalMovement = success ? targetPosition.X.CompareTo(enemyPosition.X) : 0f;
        VerticalMovement = success ? targetPosition.Y.CompareTo(enemyPosition.Y) : 0f;
        MousePosition = success && itemInHandExists ? targetPosition : enemyPosition;

        IsUsing = itemInHandExists;
        IsPickingUpItem = !itemInHandExists;
    }
}
