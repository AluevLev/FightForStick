using UnityEngine;
using VContainer;

public class HumanItemHolder : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _hand1;
    [SerializeField] private Rigidbody2D _hand2;

    [SerializeField] private float _maxPickUpRadius;

    private IPickable _itemInHand;

    private IInputProvider _inputProvider;
    private IScreenInWorld _screenToWorld;
    [Inject]
    public void Construct(IInputProvider inputProvider, IScreenInWorld screenInWorld)
    {
        _inputProvider = inputProvider;
        _screenToWorld = screenInWorld;
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
        Collider2D collider = Physics2D.OverlapPoint(_screenToWorld.MousePosition);

        if (!collider || Vector2.Distance(collider.transform.position, transform.position) > _maxPickUpRadius)
            return null;

        return collider.GetComponent<IPickable>();
    }
}
