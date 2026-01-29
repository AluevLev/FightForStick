using UnityEngine;
using VContainer;

public class HumanItemHolder : MonoBehaviour
{
    [SerializeField] private Transform humanTransform;
    [SerializeField] private Rigidbody2D _hand1;
    [SerializeField] private Rigidbody2D _hand2;

    //[SerializeField] private TargetVector[] amrsParts;

    [SerializeField] private float _maxPickUpRadius;

    private IPickable _itemInHand;

    private IInputProvider _inputProvider;
    private IPointProvider _cursor;
    [Inject]
    public void Construct(IInputProvider inputProvider, IPointProvider cursor)
    {
        _inputProvider = inputProvider;
        _cursor = cursor;
    }
    private void Update()
    {
        if (_inputProvider.IsPickingUp)
            PickUpItem();
        if (_inputProvider.IsDroppingItem)
            DropItem();
    }
    private void PickUpItem()
    {
        if (_itemInHand != null)
            return;

        IPickable pickable = TryFindPickable();
        
        if (pickable != null)
        {
            pickable.PickUp(_hand1, _hand2, _cursor);
            _itemInHand = pickable;

            //foreach (ITargetSetter armPart in amrsParts)
            //    armPart.SetTarget(_cursor);
        }
    }
    private void DropItem()
    {
        if (_itemInHand != null)
        {
            _itemInHand.Drop();
            _itemInHand = null;

            //foreach (ITargetSetter armPart in amrsParts)
            //    armPart.ResetTarget();
        }
    }
    private IPickable TryFindPickable()
    {
        if (!_cursor.TryGetPointSafe(out Vector2 point))
            return null;

        Collider2D collider = Physics2D.OverlapPoint(point);

        if (!collider || Vector2.Distance(collider.transform.position, humanTransform.position) > _maxPickUpRadius)
            return null;

        return collider.GetComponent<IPickable>();
    }
}
