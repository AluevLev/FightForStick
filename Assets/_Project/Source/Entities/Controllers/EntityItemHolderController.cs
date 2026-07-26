using IceFebruary;
using IceFebruary.Time;

public sealed class EntityItemHolderController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IItemHolderHandler _playerHolderHandler;
    public EntityItemHolderController(IInputProvider inputProvider, IItemHolderHandler playerHolderHandler)
    {
        _inputProvider = inputProvider;
        _playerHolderHandler = playerHolderHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (_inputProvider.IsPickingUpItem)
            _playerHolderHandler.PickUp();
        if (_inputProvider.IsDroppingItem)
            _playerHolderHandler.Drop();
    }
}
