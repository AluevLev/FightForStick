using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;

public sealed class EntityItemHolderHandler : BaseEntity, IItemHolderHandler
{
    private readonly IOverlapper _pickUpChecker;
    private readonly IItemHolder _entityItemHolder;
    private readonly IVector2Provider _stickmanPosition;
    private readonly IVector2Provider _cursorPosition;
    private readonly IRotor2Provider _targetItemRotation;
    private readonly float _sqrMaxPickUpDistance;
    public IPickable ItemInHand { get; private set; }
    public EntityItemHolderHandler(IOverlapper pickUpChecker, IItemHolder entityItemHolder, IVector2Provider stickmanPosition, IVector2Provider cursorPosition, IRotor2Provider targetItemRotation, float sqrMaxPickUpDistance)
    {
        _pickUpChecker = pickUpChecker;
        _entityItemHolder = entityItemHolder;
        _stickmanPosition = stickmanPosition;
        _cursorPosition = cursorPosition;
        _targetItemRotation = targetItemRotation;
        _sqrMaxPickUpDistance = sqrMaxPickUpDistance;
    }
    public void PickUp()
    {
        if (!_stickmanPosition.TryGetSafety(out Vector2 entityPosition) || !_cursorPosition.TryGetSafety(out Vector2 cursorPosition) || Vector2.SqrDistance(cursorPosition, entityPosition) > _sqrMaxPickUpDistance)
            return;

        _pickUpChecker.Overlap();

        if (!_pickUpChecker.Succes)
            return;

        IPickable item = null;
        IGameObject gameObject = null;

        for (int index = 0; index < _pickUpChecker.Colliders2DActualLength; index++)
        {
            gameObject = _pickUpChecker.Colliders2D[index].GameObject;

            if (gameObject.MainComponent.Value is IPickable pickable)
            {
                item = pickable;
                break;
            }
        }

        if (!item.Exists())
            return;

        if (ItemInHand.Exists())
            Drop();

        _entityItemHolder.PickUpItem(item);

        ItemInHand = item;

        ItemInHand.PhysicsBalancer.SetTarget(_targetItemRotation);
    }
    public void Drop()
    {
        _entityItemHolder.DropItemInHand();

        ItemInHand.PhysicsBalancer.ResetTarget();

        ItemInHand = null;
    }
}
