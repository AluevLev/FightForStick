using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Shapes;
using IceFebruary.Space;
using IceFebruary.Space.PointProvider;

public class EntityItemHolderHandler<T> : IItemHolderHandler where T : struct, IShape
{
    private readonly IPhysics2D _physics2D;
    private readonly IItemHolder _entityItemHolder;
    private readonly IPointProvider _cursor;
    private readonly IPointProvider _humanPosition;
    private readonly T _overlapArea;
    private readonly float _maxPickUpDistance;

    private IPickable _itemInHand;
    public EntityItemHolderHandler(IPhysics2D physics2D, IItemHolder entityItemHolder, IPointProvider cursor, IPointProvider humanPosition, T overlapArea, float maxPickUpDistance)
    {
        _physics2D = physics2D;
        _entityItemHolder = entityItemHolder;
        _cursor = cursor;
        _humanPosition = humanPosition;
        _overlapArea = overlapArea;
        _maxPickUpDistance = maxPickUpDistance;
    }

    public void PickUp()
    {
        if (!_cursor.TryGetPointSafe(out Vector2 cursorPosition))
            return;
        if (!_humanPosition.TryGetPointSafe(out Vector2 entityPosition))
            return;
        if (_physics2D.Overlap(out IEntireComponent<ICollider2D>[] results, _overlapArea, cursorPosition) == 0)
            return;

        IPickable item = null;

        foreach (IEntireComponent<ICollider2D> result in results)
        {
            IGameObject gameObject = result.GameObject;

            if (Vector2.Distance(gameObject.Transform.Position, entityPosition) >= _maxPickUpDistance)
                continue;
            if (gameObject.TryGetComponent(out item))
                break;
        }

        if (item != null)
            return;

        if (_itemInHand != null)
            Drop();

        _entityItemHolder.PickUpItem(item);

        _itemInHand = item;
    }
    public void Drop()
    {
        _entityItemHolder.DropItemInHand();

        _itemInHand = null;
    }
}
