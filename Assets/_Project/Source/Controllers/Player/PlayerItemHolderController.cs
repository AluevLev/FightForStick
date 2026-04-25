using IceFebruary;
using IceFebruary.Time;

public sealed class PlayerItemHolderController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IItemHolderHandler _playerHolderHandler;
    public PlayerItemHolderController(IInputProvider inputProvider, IItemHolderHandler playerHolderHandler) : base()
    {
        _inputProvider = inputProvider;
        _playerHolderHandler = playerHolderHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (_inputProvider.IsPickingUp)
            _playerHolderHandler.PickUp();
        if (_inputProvider.IsDroppingItem)
            _playerHolderHandler.Drop();
    }
}
