using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Physics;

public sealed class EntityItemHolderHandler : BaseEntity, IItemHolderHandler
{
    private readonly IOverlapper _pickUpChecker;
    private readonly IItemHolder _entityItemHolder;
    private readonly IVector2Provider _stickmanPosition;
    private readonly IVector2Provider _cursorPosition;
    private readonly IRotor2Provider _targetItemRotation;
    private readonly float _sqrMaxPickUpDistance;
    private readonly int _entityLayer;
    public IPickable Item { get; private set; }
    private ItemHolder _itemHolder;
    private IUsable _itemUsable;
    private IReleasable _itemReleasable;
    private int _itemLayer;
    public EntityItemHolderHandler(IOverlapper pickUpChecker, IItemHolder entityItemHolder, IVector2Provider stickmanPosition, IVector2Provider cursorPosition, IRotor2Provider targetItemRotation, float sqrMaxPickUpDistance, int entityLayer)
    {
        _pickUpChecker = pickUpChecker;
        _entityItemHolder = entityItemHolder;
        _stickmanPosition = stickmanPosition;
        _cursorPosition = cursorPosition;
        _targetItemRotation = targetItemRotation;
        _sqrMaxPickUpDistance = sqrMaxPickUpDistance;
        _entityLayer = entityLayer;
    }
    public void PickUp()
    {
        if (!_stickmanPosition.TryGetSafety(out Vector2 entityPosition) || !_cursorPosition.TryGetSafety(out Vector2 cursorPosition) || Vector2.SqrDistance(cursorPosition, entityPosition) > _sqrMaxPickUpDistance)
            return;

        _pickUpChecker.Overlap();

        if (!_pickUpChecker.Success)
            return;

        IPickable item = null;
        IGameObject itemGameObject = null;

        for (int index = 0; index < _pickUpChecker.Colliders2DActualLength; index++)
        {
            itemGameObject = _pickUpChecker.Colliders2D[index].GameObject;

            if (itemGameObject.MainComponent is IPickable pickable)
            {
                item = pickable;
                break;
            }
        }

        if (!item.Exists())
            return;

        if (Item.Exists())
            Drop();

        _entityItemHolder.PickUpItem(item);

        Item = item;

        _itemHolder = Item.ItemHolder;
        _itemUsable = Item as IUsable;
        _itemReleasable = Item as IReleasable;
        _itemLayer = _itemHolder.GameObject.Layer;

        _itemHolder.GameObject.Layer = _entityLayer;

        _itemHolder.PhysicsBalancer.SetTarget(_targetItemRotation);
    }
    public void Use()
    {
        if (_itemUsable.Exists())
            _itemUsable.Use();
    }
    public void Release()
    {
        if (_itemReleasable.Exists())
            _itemReleasable.Release();
    }
    public void Drop()
    {
        if (!Item.Exists())
            return;

        _entityItemHolder.DropItemInHand();

        _itemHolder.PhysicsBalancer.ResetTarget();

        _itemHolder.GameObject.Layer = _itemLayer;

        Item = null;

        _itemHolder = null;
        _itemUsable = null;
        _itemReleasable = null;
        _itemLayer = 0;
    }
}
