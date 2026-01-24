using UnityEngine;
using VContainer;

public class HumanItemHolder : MonoBehaviour
{
    [SerializeField] private Transform humanTransform;
    [SerializeField] private Rigidbody2D _hand1;
    [SerializeField] private Rigidbody2D _hand2;

    [SerializeField] private float _maxPickUpRadius;

    private IPickable _itemInHand;

    private IInputProvider _inputProvider;
    private ICursorWorldProvider _cursorWorldProvider;
    [Inject]
    public void Construct(IInputProvider inputProvider, ICursorWorldProvider screenInWorld)
    {
        _inputProvider = inputProvider;
        _cursorWorldProvider = screenInWorld;
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
            pickable.PickUp(_hand1, _hand2);
            _itemInHand = pickable;
        }
    }
    private void DropItem()
    {
        if (_itemInHand != null)
        {
            _itemInHand.Drop();
            _itemInHand = null;
        }
    }
    private IPickable TryFindPickable()
    {
        Collider2D collider = Physics2D.OverlapPoint(_cursorWorldProvider.MousePosition);

        print(Vector2.Distance(collider.transform.position, transform.position) > _maxPickUpRadius);

        if (!collider || Vector2.Distance(collider.transform.position, humanTransform.position) > _maxPickUpRadius)
            return null;

        return collider.GetComponent<IPickable>();
    }
}
