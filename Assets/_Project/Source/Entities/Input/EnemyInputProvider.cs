using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class EnemyInputProvider : BaseEntity, IInputProvider, IFrame
{
    private readonly IVector2Provider _enemyPosition;
    private readonly IVector2Provider _targetPosition;
    public SetOnce<IItemHolderHandler> EnemyHolderHandler { get; private init; } = new();
    public EnemyInputProvider(IVector2Provider enemyPosition, IVector2Provider targetPosition)
    {
        _enemyPosition = enemyPosition;
        _targetPosition = targetPosition;
    }
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement { get; private set; }
    public Vector2 MousePosition { get; private set; }

    public bool IsDroppingItem { get; private set; }
    public bool IsUsing { get; private set; }
    public bool IsPickingUpItem { get; private set; }
    public void OnFrame(float frameLength)
    {
        bool itemInHandExists = EnemyHolderHandler.TryGetValue(out IItemHolderHandler itemHolderHandler) && itemHolderHandler.ItemInHand.Exists();

        Vector2 enemyPosition = default;
        Vector2 targetPosition = default;

        bool success = _enemyPosition.TryGetSafety(out enemyPosition) && _targetPosition.TryGetSafety(out targetPosition);

        if (success)
        {
            HorizontalMovement = targetPosition.X.CompareTo(enemyPosition.X);
            VerticalMovement = targetPosition.Y.CompareTo(enemyPosition.Y);
            MousePosition = targetPosition;
        }

        else
        {
            HorizontalMovement = 0f;
            VerticalMovement = 0f;
            MousePosition = enemyPosition;
        }

        IsUsing = itemInHandExists;
        IsPickingUpItem = !itemInHandExists;
        IsDroppingItem = false;
    }
}
