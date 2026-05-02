using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Shapes;
using IceFebruary.Space;
using IceFebruary.Space.PointProvider;

public sealed class EntityItemHolderHandler : IItemHolderHandler
{
    private readonly Component<ICollider2D>[] _itemBuffer = new Component<ICollider2D>[8];

    private readonly IPhysics2D _physics2D;
    private readonly IItemHolder _entityItemHolder;
    private readonly IPointProvider _cursor;
    private readonly IPointProvider _humanPosition;
    private readonly IShape _overlapArea;
    private readonly float _sqrMaxPickUpDistance;

    private IPickable _itemInHand;
    public EntityItemHolderHandler(IPhysics2D physics2D, IItemHolder entityItemHolder, IPointProvider cursor, IPointProvider humanPosition, IShape overlapArea, float maxPickUpDistance)
    {
        _physics2D = physics2D;
        _entityItemHolder = entityItemHolder;
        _cursor = cursor;
        _humanPosition = humanPosition;
        _overlapArea = overlapArea;
        _sqrMaxPickUpDistance = maxPickUpDistance * maxPickUpDistance;
    }
    public void PickUp()
    {
        if (!_cursor.TryGetPointSafe(out Vector2 cursorPosition))
            return;
        if (!_humanPosition.TryGetPointSafe(out Vector2 entityPosition))
            return;
        if (_physics2D.Overlap(_overlapArea, cursorPosition) == 0)
            return;

        IPickable item = null;

        foreach (Component<ICollider2D> result in _itemBuffer)
        {
            IGameObject gameObject = result.GameObject;

            if (Vector2.SqrDistance(gameObject.Transform.Position, entityPosition) >= _sqrMaxPickUpDistance)
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
