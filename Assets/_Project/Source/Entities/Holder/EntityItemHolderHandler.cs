using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.PointProvider;
using IceFebruary.Components;
using IceFebruary.Physics;
using IceFebruary.Shapes;
public class EntityItemHolderHandler : ITogglable, IItemHolderHandler
{
    private readonly IPhysics2D _physics;
    private readonly IItemHolder _entityItemHolder;
    private readonly IPointProvider _cursor;
    private readonly IPointProvider _humanPosition;
    private readonly float _maxPickUpDistance;

    private IPickable _itemInHand;
    public bool Enabled { get; set; } = true;
    public EntityItemHolderHandler(IItemHolder entityItemHolder, IPointProvider cursor, IPointProvider humanPosition, float maxPickUpDistance)
    {
        _entityItemHolder = entityItemHolder;
        _cursor = cursor;
        _humanPosition = humanPosition;
        _maxPickUpDistance = maxPickUpDistance;
    }

    public void PickUp()
    {
        if (!Enabled)
            return;
        if (!_cursor.TryGetPointSafe(out Vector2 cursorPosition))
            return;

        ICollider2D collider = null;//_physics.Overlap(new Dot(cursorPosition));

        if (collider == null)
            return;
        if (!_humanPosition.TryGetPointSafe(out Vector2 entityPosition))
            return;
        
        if (Vector2.Distance(collider.GameObject.Transform.Position, entityPosition) >= _maxPickUpDistance)
            return;
        if (!collider.GameObject.TryGetComponent(out IPickable item))
            return;

        if (_itemInHand != null)
            Drop();

        _entityItemHolder.PickUpItem(item);

        _itemInHand = item;
    }
    public void Drop()
    {
        if (!Enabled)
            return;

        _entityItemHolder.DropItemInHand();

        _itemInHand = null;
    }
}
