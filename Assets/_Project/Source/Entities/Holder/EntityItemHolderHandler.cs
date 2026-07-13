using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;

public sealed class EntityItemHolderHandler : IItemHolderHandler
{
    private readonly IOverlapper _overlapper;
    private readonly IItemHolder _entityItemHolder;
    private readonly IVector2Provider _humanPosition;
    private readonly float _sqrMaxPickUpDistance;

    public IPickable ItemInHand { get; private set; }
    public EntityItemHolderHandler(IItemHolder entityItemHolder, IVector2Provider humanPosition, float sqrMaxPickUpDistance)
    {
        _entityItemHolder = entityItemHolder;
        _humanPosition = humanPosition;
        _sqrMaxPickUpDistance = sqrMaxPickUpDistance;
    }
    public void PickUp()
    {
        if (!_humanPosition.TryGetSafety(out Vector2 entityPosition))
            return;

        _overlapper.Overlap();

        if (!_overlapper.Succes)
            return;

        IPickable item = null;

        for (int index = 0; index < _overlapper.Colliders2DActualLength; index++)
        {
            IGameObject gameObject = _overlapper.Colliders2D[index].GameObject;

            if (Vector2.SqrDistance(gameObject.Transform.Position, entityPosition) > _sqrMaxPickUpDistance)
                continue;
            if (gameObject.TryGetComponent(out item))
                break;
        }

        if (item.Exists())
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
