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
    private readonly IPointProvider _humanPosition;
    private readonly IShape _overlapArea;
    private readonly float _sqrMaxPickUpDistance;

    private IPickable _itemInHand;
    public EntityItemHolderHandler(IPhysics2D physics2D, IItemHolder entityItemHolder, IPointProvider humanPosition, IShape overlapArea, float sqrMaxPickUpDistance)
    {
        _physics2D = physics2D;
        _entityItemHolder = entityItemHolder;
        _humanPosition = humanPosition;
        _overlapArea = overlapArea;
        _sqrMaxPickUpDistance = sqrMaxPickUpDistance;
    }
    public void PickUp(Vector2 cursorPosition)
    {
        if (!_humanPosition.TryGetPointSafe(out Vector2 entityPosition))
            return;
        if (_physics2D.Overlap(_overlapArea, cursorPosition, null, null, _itemBuffer) == 0)
            return;

        IPickable item = null;

        for (int index = 0; index < _itemBuffer.Length; index++)
        {
            IGameObject gameObject = _itemBuffer[index].GameObject;

            if (Vector2.SqrDistance(gameObject.Transform.Position, entityPosition) > _sqrMaxPickUpDistance)
                continue;
            if (gameObject.TryGetComponent(out item))
                break;
        }

        if (item == null)
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
