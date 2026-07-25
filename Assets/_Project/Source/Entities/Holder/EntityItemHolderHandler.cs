using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;

public sealed class EntityItemHolderHandler : BaseEntity, IItemHolderHandler
{
    private readonly IOverlapper _pickUpChecker;
    private readonly IItemHolder _entityItemHolder;
    private readonly IVector2Provider _humanPosition;
    private readonly float _sqrMaxPickUpDistance;

    public IPickable ItemInHand { get; private set; }
    public EntityItemHolderHandler(IOverlapper pickUpChecker, IItemHolder entityItemHolder, IVector2Provider humanPosition, float sqrMaxPickUpDistance)
    {
        _pickUpChecker = pickUpChecker;
        _entityItemHolder = entityItemHolder;
        _humanPosition = humanPosition;
        _sqrMaxPickUpDistance = sqrMaxPickUpDistance;
    }
    public void PickUp()
    {
        if (!_humanPosition.TryGetSafety(out Vector2 entityPosition))
            return;

        _pickUpChecker.Overlap();

        if (!_pickUpChecker.Succes)
            return;

        IPickable item = null;

        for (int index = 0; index < _pickUpChecker.Colliders2DActualLength; index++)
        {
            IGameObject gameObject = _pickUpChecker.Colliders2D[index].GameObject;

            if (Vector2.SqrDistance(gameObject.Transform.Position, entityPosition) > _sqrMaxPickUpDistance)
                continue;
            if (gameObject.MainComponent.Value is IPickable pickable)
                item = pickable;
        }

        if (!item.Exists())
            return;

        if (ItemInHand.Exists())
            Drop();

        _entityItemHolder.PickUpItem(item);

        ItemInHand = item;
    }
    public void Drop()
    {
        _entityItemHolder.DropItemInHand();

        ItemInHand = null;
    }
}
