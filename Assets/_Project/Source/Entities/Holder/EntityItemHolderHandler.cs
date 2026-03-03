using UnityEngine;
using February;
using February.Space;
using February.Space.PointProvider;
using February.Adaptation;
public class EntityItemHolderHandler : ITogglable, IItemHolderHandler
{
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
        if (!_cursor.TryGetPointSafe(out UniVector2 cursorPosition))
            return;
        
        Collider2D collider = Physics2D.OverlapPoint(cursorPosition.ToUnity2D());

        if (!collider)
            return;
        if (!_humanPosition.TryGetPointSafe(out UniVector2 entityPosition))
            return;
        if (Vector2.Distance(collider.transform.position, entityPosition.ToUnity2D()) >= _maxPickUpDistance)
            return;
        if (!collider.TryGetComponent(out IPickable item))
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
